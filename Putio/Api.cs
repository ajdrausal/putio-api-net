// <copyright>
//   Copyright (c) 2010 Huseyin Tufekcilerli. All rights reserved.
//   
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//   
//       http://www.apache.org/licenses/LICENSE-2.0
//   
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
// <author>Huseyin Tufekcilerli</author>

namespace Putio
{
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Text;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Putio.Core;

    public class Api
    {
        private const string RpcUrl = "http://api.put.io/v1";
        private const string UserAgent = "putio-api-net";

        public Api(string key, string secret)
        {
            this.Key = key;
            this.Secret = secret;
        }

        public string Key { get; set; }

        public string Secret { get; set; }

        public User GetUserInfo()
        {
            return GetFirstResultOrDefault<User>(Methods.GetUserInfo, null);
        }

        public Friend[] GetFriends()
        {
            return this.GetResultsArray<Friend>(Methods.GetUserFriends, null);
        }

        public string GetAccessToken()
        {
            return this.GetResultsObject<TokenResult>(Methods.GetUserToken, null).Token;
        }

        public Item[] GetRootItems()
        {
            return this.GetItems("0");
        }

        public Item[] GetItems(string parentId)
        {
            return this.GetItems(20, 0, parentId, null, null);
        }

        public Item[] GetItems(int limit, int offset, string parentId)
        {
            return this.GetItems(limit, offset, parentId, null, null);
        }

        public Item[] GetItems(int limit, int offset, string parentId, string type, string orderBy)
        {
            var parameters = new Dictionary<string, object>
            { 
                { "limit", limit },
                { "offset", offset },
                { "parent_id", parentId },
            };

            if (type != null)
            {
                parameters["type"] = type;
            }

            if (orderBy != null)
            {
                parameters["orderby"] = orderBy;
            }

            return this.GetItemsCore(parameters);
        }

        public Transfer[] GetTransfers()
        {
            return this.GetResultsArray<Transfer>(Methods.ListTransfers, null);
        }

        /// <summary>
        /// Gets subscriptions.
        /// </summary>
        /// <returns>Subscriptions of authenticated user</returns>
        public Subscription[] GetSubscriptions()
        {
            return this.GetResultsArray<Subscription>(Methods.ListSubscriptions, null);
        }

        /// <summary>
        /// Creates a new subscription.
        /// </summary>
        /// <param name="title">Title for the new subscription</param>
        /// <param name="url">Url address to subscribe</param>
        /// <returns>New subscription, if succeeds.</returns>
        public Subscription CreateSubscription(string title, string url)
        {
            var parameters = new Dictionary<string, object>
            {
                { "title", title ?? "New Subscription" },
                { "url", url },
            };

            return this.GetFirstResultOrDefault<Subscription>(Methods.CreateSubscription, parameters);
        }

        /// <summary>
        /// Changes values of any given subscription attribute.
        /// </summary>
        /// <param name="id">Id of an existing subscription to be edited</param>
        /// <param name="newTitle">New title for the subscription</param>
        /// <param name="newUrl">New url address for the subscription</param>
        /// <returns>Edited subscription, if succeeds.</returns>
        /// <exception cref="PutioException">If <paramref name="id"/> is wrong</exception>
        /// <exception cref="PutioException">If <paramref name="newTitle"/> or <paramref name="newUrl"/> is null</exception>
        public Subscription EditSubscription(string id, string newTitle, string newUrl)
        {
            var parameters = new Dictionary<string, object>
            {
                { "id", id },
                { "title", newTitle },
                { "url", newUrl },
            };

            return this.GetFirstResultOrDefault<Subscription>(Methods.EditSubscription, parameters);
        }

        /// <summary>
        /// Deletes subscription with specified id.
        /// </summary>
        /// <param name="id">Id of subscription to be deleted.</param>
        public void DeleteSubscription(string id)
        {
            var parameters = new Dictionary<string, object>
            {
                { "id", id },
            };

            this.GetResultsArray<object>(Methods.DeleteSubscription, parameters);
        }

        /// <summary>
        /// Toggles subscription status, that is pauses if not and vice versa.
        /// </summary>
        /// <remarks>
        /// You may also change this value by editing the subscription item. 
        /// This is just a shortcut we use.
        /// </remarks>
        /// <param name="id">Id of subscription to be paused/continued.</param>
        /// <returns>Toggled subscription, if succeeds.</returns>
        /// <exception cref="PutioException">Wrong subscription id specified.</exception>
        public Subscription ToggleSubscriptionStatus(string id)
        {
            var parameters = new Dictionary<string, object>
            {
                { "id", id },
            };

            return this.GetFirstResultOrDefault<Subscription>(Methods.PauseSubscription, parameters);
        }

        /// <summary>
        /// Gets a single subscription with specified id.
        /// </summary>
        /// <param name="id">Id of subscription.</param>
        /// <returns><see cref="Subscription"/> object, if exists.</returns>
        public Subscription GetSubscription(string id)
        {
            var parameters = new Dictionary<string, object>
            {
                { "id", id },
            };

            return GetFirstResultOrDefault<Subscription>(Methods.GetSubscriptionInfo, parameters);
        }

        /// <summary>
        /// Gets dashboard messages.
        /// </summary>
        /// <returns>Dashboard messages of authenticated user</returns>
        public Message[] GetMessages()
        {
            return this.GetResultsArray<Message>(Methods.ListMessages, null);
        }

        /// <summary>
        /// Deletes dashboard message with specified id.
        /// </summary>
        /// <param name="id">Id of message to be deleted.</param>
        public void DeleteMessage(string id)
        {
            var parameters = new Dictionary<string, object>
            {
                { "id", id },
            };

            this.GetResultsArray<object>(Methods.DeleteMessage, parameters);
        }

        public Item CreateDirectory(string name)
        {
            return this.CreateDirectory(name, "0");
        }

        public Item CreateDirectory(string name, string parentId)
        {
            var parameters = new Dictionary<string, object>
            {
                { "name", name ?? "New Folder" },
                { "parent_id", parentId ?? "0" },
            };

            return this.GetFirstResultOrDefault<Item>(Methods.CreateDirectory, parameters);
        }

        /// <summary>
        /// Deletes an item.
        /// </summary>
        /// <param name="id">The id of item to be deleted.</param>
        /// <exception cref="PutioException">Invalid item id specified.</exception>
        public void DeleteItem(string id)
        {
            var parameters = new Dictionary<string, object> { { "id", id } };
            var responseString = this.SendRequest(Methods.DeleteFile, parameters);
            var response = JObject.Parse(responseString);

            this.CheckResponseErrorAndThrow(response, Methods.DeleteFile, parameters);
        }

        /// <summary>
        /// Rename an existing item.
        /// </summary>
        /// <param name="id">The id of item to be renamed.</param>
        /// <param name="name">The new name of the item</param>
        /// <returns>Renamed item, if succeeds.</returns>
        /// <exception cref="PutioException">Invalid item id specified.</exception>
        public Item RenameItem(string id, string name)
        {
            var parameters = new Dictionary<string, object>
            { 
                { "id", id },
                { "name", name },
            };

            return GetFirstResultOrDefault<Item>(Methods.RenameFile, parameters);
        }

        /// <summary>
        /// Move an existing item.
        /// </summary>
        /// <param name="id">The id of item to be moved.</param>
        /// <param name="targetParentId">Target parent folder id the item to be moved, "0" for root folder.</param>
        /// <returns>Moved item, if succeeds.</returns>
        /// <exception cref="PutioException">Invalid item/parent id specified.</exception>
        public Item MoveItem(string id, string targetParentId)
        {
            var parameters = new Dictionary<string, object>
            { 
                { "id", id },
                { "parent_id", targetParentId },
            };

            return GetFirstResultOrDefault<Item>(Methods.MoveFile, parameters);
        }

        /// <summary>
        /// Returns a single item with given id.
        /// </summary>
        /// <param name="id">The id of the item to be retrieved.</param>
        /// <returns>Requested item, if succeeds.</returns>
        /// <exception cref="PutioException">Invalid item id specified.</exception>
        public Item GetItemInfo(string id)
        {
            var parameters = new Dictionary<string, object>
            { 
                { "id", id },
            };

            return GetFirstResultOrDefault<Item>(Methods.GetFileInfo, parameters);
        }

        /// <summary>
        /// Searches items in your storage.
        /// </summary>
        /// <param name="query">A Put.io search query string.</param>
        /// <returns>Items matching the specified query.</returns>
        /// <remarks>
        /// You may add search parameters to the string such as:
        ///     "from:'me'"      (from:shares|jack|all|etc.)
        ///     "type:'video'"   (audio|image|iphone|all|etc.)
        ///     "ext:'mp3'"      (avi|jpg|mp4|all|etc.)
        ///     "time:'today'"   (yesterday|thismonth|thisweek|all|etc.)
        /// </remarks>
        public Item[] SearchItems(string query)
        {
            var parameters = new Dictionary<string, object>
            { 
                { "query", query },
            };

            return this.GetResultsArray<Item>(Methods.SearchFiles, parameters);
        }

        /// <summary>
        /// Gets hierchical list of folders.
        /// </summary>
        /// <returns>Root folder with its sub directories listed recursively</returns>
        public Folder GetFolderList()
        {
            return this.GetResultsObject<Folder>(Methods.MapDirectories, null);
        }

        private void CheckResponseErrorAndThrow(JObject response, Method method, Dictionary<string, object> parameters)
        {
            var hasError = response["error"].Value<bool>();

            if (hasError)
            {
                var errorMessage = response["error_message"].Value<string>();

                throw new PutioException(errorMessage, method.GetUrl(), parameters);
            }
        }

        private Item[] GetItemsCore(IDictionary<string, object> parameters)
        {
            return this.GetResultsArray<Item>(Methods.ListFiles, parameters);
        }

        private T GetFirstResultOrDefault<T>(Method method, IDictionary<string, object> parameters)
        {
            var results = this.GetResultsArray<T>(method, parameters);

            return results.Length > 0 ? results[0] : default(T);
        }

        private T[] GetResultsArray<T>(Method method, IDictionary<string, object> parameters)
        {
            return this.GetResultsCore<ArrayResponseContents<T>>(method, parameters).Results;
        }

        private T GetResultsObject<T>(Method method, IDictionary<string, object> parameters)
        {
            return this.GetResultsCore<ObjectResponseContents<T>>(method, parameters).Results;
        }

        private T GetResultsCore<T>(Method method, IDictionary<string, object> parameters)
        {
            var responseString = this.SendRequest(method, parameters);

            var response = JsonConvert.DeserializeObject<Response<T>>(responseString);

            if (response.Error)
            {
                throw new PutioException(response.ErrorMessage, method.GetUrl(), parameters);
            }

            return response.Contents;
        }

        private string SendRequest(Method method, IDictionary<string, object> parameters)
        {
            var request = new Request(this.Key, this.Secret, parameters);

            var requestString = "request=" + JsonConvert.SerializeObject(request);

            var url = RpcUrl + method.GetUrl();

            return this.Send(url, requestString);
        }

        private string Send(string url, string data)
        {
            var httpRequest = WebRequest.Create(url) as HttpWebRequest;

            var postDataBytes = Encoding.UTF8.GetBytes(data);

            httpRequest.AllowAutoRedirect = false;
            httpRequest.ProtocolVersion = HttpVersion.Version11;
            httpRequest.Method = "POST";
            httpRequest.Accept = "application/json";
            httpRequest.UserAgent = UserAgent;
            httpRequest.ContentType = "application/x-www-form-urlencoded";
            httpRequest.ContentLength = postDataBytes.Length;

            using (var newStream = httpRequest.GetRequestStream())
            {
                newStream.Write(postDataBytes, 0, postDataBytes.Length);
            }

            using (var httpResponse = httpRequest.GetResponse())
            using (var reader = new StreamReader(httpResponse.GetResponseStream()))
            {
                return reader.ReadToEnd();
            }
        }
    }
}