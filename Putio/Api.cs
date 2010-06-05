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
            return this.GetResults<Friend>(Methods.GetUserFriends, null);
        }

        public string GetAccessToken()
        {
            var requestString = this.SendRequest(Methods.GetUserToken, null);
            var tokenObject = JObject.Parse(requestString);

            var error = tokenObject["error"].Value<bool>();

            if (error)
            {
                var errorMessage = tokenObject["error_message"].Value<string>();

                throw new PutioException(errorMessage, Methods.GetUserToken.GetUrl(), null);
            }

            return tokenObject["response"]["results"]["token"].Value<string>();
        }

        public Item GetItemById(string id)
        {
            var parameters = new Dictionary<string, object>
            { 
                { "id", id },
            };

            return GetFirstResultOrDefault<Item>(Methods.ListFiles, parameters);
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
            return this.GetResults<Transfer>(Methods.ListTransfers, null);
        }

        public Subscription[] GetSubscriptions()
        {
            return this.GetResults<Subscription>(Methods.ListSubscriptions, null);
        }

        public Message[] GetMessages()
        {
            return this.GetResults<Message>(Methods.ListMessages, null);
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

        private Item[] GetItemsCore(IDictionary<string, object> parameters)
        {
            return this.GetResults<Item>(Methods.ListFiles, parameters);
        }

        private T GetFirstResultOrDefault<T>(Method method, IDictionary<string, object> parameters)
        {
            var results = this.GetResults<T>(method, parameters);

            return results.Length > 0 ? results[0] : default(T);
        }

        private T[] GetResults<T>(Method method, IDictionary<string, object> parameters)
        {
            var requestString = this.SendRequest(method, parameters);

            var response = JsonConvert.DeserializeObject<Response<T>>(requestString);

            if (response.Error)
            {
                throw new PutioException(response.ErrorMessage, method.GetUrl(), parameters);
            }

            return response.Contents.Results;
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