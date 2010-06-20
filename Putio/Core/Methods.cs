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

namespace Putio.Core
{
    internal static class Methods
    {
        private static readonly Method listFiles;
        private static readonly Method createDirectory;
        private static readonly Method searchFiles;
        private static readonly Method mapDirectories;
        private static readonly Method renameFile;
        private static readonly Method moveFile;
        private static readonly Method deleteFile;
        private static readonly Method getFileInfo;

        private static readonly Method listMessages;
        private static readonly Method deleteMessage;

        private static readonly Method listSubscriptions;
        private static readonly Method createSubscription;
        private static readonly Method editSubscription;
        private static readonly Method deleteSubscription;
        ////private static readonly Method pauseSubscription;
        ////private static readonly Method getSubscriptionInfo;

        private static readonly Method listTransfers;
        ////private static readonly Method cancelTransfer;
        ////private static readonly Method addTransfer;

        ////private static readonly Method analyzeUrls;
        ////private static readonly Method extractUrls;

        private static readonly Method getUserInfo;
        private static readonly Method getUserToken;
        private static readonly Method getUserFriends;

        static Methods()
        {
            // Files:
            listFiles = new Method(Paths.Files, "list");
            createDirectory = new Method(Paths.Files, "create_dir");
            searchFiles = new Method(Paths.Files, "search");
            mapDirectories = new Method(Paths.Files, "dirmap");
            renameFile = new Method(Paths.Files, "rename");
            moveFile = new Method(Paths.Files, "move");
            deleteFile = new Method(Paths.Files, "delete");
            getFileInfo = new Method(Paths.Files, "info");

            // Dashboard Messages:
            listMessages = new Method(Paths.Messages, "list");
            deleteMessage = new Method(Paths.Messages, "delete");

            // Subscriptions:
            listSubscriptions = new Method(Paths.Subscriptions, "list");
            createSubscription = new Method(Paths.Subscriptions, "create");
            editSubscription = new Method(Paths.Subscriptions, "edit");
            deleteSubscription = new Method(Paths.Subscriptions, "delete");
            ////pauseSubscription = new Method(Paths.Subscriptions, "pause");
            ////getSubscriptionInfo = new Method(Paths.Subscriptions, "info");

            // Active Transfers:
            listTransfers = new Method(Paths.Transfers, "list");
            ////cancelTransfer = new Method(Paths.Transfers, "cancel");
            ////addTransfer = new Method(Paths.Transfers, "add");

            // URL Handler:
            ////analyzeUrls = new Method(Paths.Urls, "analyze");
            ////extractUrls = new Method(Paths.Urls, "extracturls");

            // User:
            getUserInfo = new Method(Paths.User, "info");
            getUserToken = new Method(Paths.User, "acctoken");
            getUserFriends = new Method(Paths.User, "friends");
        }

        public static Method ListFiles
        {
            get { return listFiles; }
        }

        public static Method CreateDirectory
        {
            get { return createDirectory; }
        }

        public static Method SearchFiles
        {
            get { return searchFiles; }
        }

        public static Method MapDirectories
        {
            get { return mapDirectories; }
        }

        public static Method RenameFile
        {
            get { return renameFile; }
        }

        public static Method MoveFile
        {
            get { return moveFile; }
        }

        public static Method DeleteFile
        {
            get { return deleteFile; }
        }

        public static Method GetFileInfo
        {
            get { return getFileInfo; }
        }

        public static Method ListMessages
        {
            get { return listMessages; }
        }

        public static Method DeleteMessage
        {
            get { return deleteMessage; }
        }

        public static Method ListSubscriptions
        {
            get { return listSubscriptions; }
        }

        public static Method CreateSubscription
        {
            get { return createSubscription; }
        }

        public static Method EditSubscription
        {
            get { return editSubscription; }
        }

        public static Method DeleteSubscription
        {
            get { return deleteSubscription; }
        }

        ////public static Method PauseSubscription
        ////{
        ////    get { return pauseSubscription; }
        ////}

        ////public static Method GetSubscriptionInfo
        ////{
        ////    get { return getSubscriptionInfo; }
        ////}

        public static Method ListTransfers
        {
            get { return listTransfers; }
        }

        ////public static Method CancelTransfer
        ////{
        ////    get { return cancelTransfer; }
        ////}

        ////public static Method AddTransfer
        ////{
        ////    get { return addTransfer; }
        ////}

        ////public static Method AnalyzeUrls
        ////{
        ////    get { return analyzeUrls; }
        ////}

        ////public static Method ExtractUrls
        ////{
        ////    get { return extractUrls; }
        ////}

        public static Method GetUserInfo
        {
            get { return getUserInfo; }
        }

        public static Method GetUserToken
        {
            get { return getUserToken; }
        }

        public static Method GetUserFriends
        {
            get { return getUserFriends; }
        }
    }
}