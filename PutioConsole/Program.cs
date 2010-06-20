namespace Putio.Console
{
    using System;
    using Putio;

    public static class Program
    {
        public static void Main(string[] args)
        {
            // !!! Set your own Put.io API key/secret here !!!
            var key = "huseyin";
            var secret = System.IO.File.ReadAllText(@"\putioapisecret.txt");

            // Initialize API
            var api = new Api(key, secret);

            // User methods (for currently authenticated user)
            var user = api.GetUserInfo();
            var friends = api.GetFriends();
            var token = api.GetAccessToken();

            // Item retrieval methods
            var itemsRoot = api.GetRootItems();
            var itemsPartial = api.GetItems(10, 20, "15");
            var itemsChild = api.GetItems("108");

            try
            {
                var itemsException = api.GetItems("42");
            }
            catch (PutioException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Directory methods
            var dir = api.CreateDirectory("Foo");
            var subDir = api.CreateDirectory("Bar", dir.Id);

            // Folder list (recursive)
            var folderList = api.GetFolderList();

            //Get Item info
            var itemInfo = api.GetItemInfo("6035693");

            // Delete Item
            api.DeleteItem(subDir.Id);

            // Rename Item
            var renamedItem = api.RenameItem("6035650", "New Name " + DateTime.Now.Ticks);

            // Move Item
            var movedItem = api.MoveItem("6035693", "6035650");

            // Search Items
            var searchResults = api.SearchItems("'bunny' from:'me' type:'video'");

            // Transfer methods
            var transfers = api.GetTransfers();

            // Subscription methods
            var subscriptions = api.GetSubscriptions();
            var newSubscription = api.CreateSubscription("My LegalTorrents Subscription", "http://www.legaltorrents.com/rss.xml");
            var editedSubscription = api.EditSubscription("2513", "My subscription pimped", "http://www.legaltorrents.com/rss.xml");
            api.DeleteSubscription("424242");
            var toggledSubscription = api.ToggleSubscriptionStatus("2671");

            // Message methods
            var messages = api.GetMessages();
            api.DeleteMessage("5313536");
        }
    }
}