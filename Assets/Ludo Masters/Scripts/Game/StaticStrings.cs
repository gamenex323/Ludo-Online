/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

namespace AssemblyCSharp
{
    public static class StaticStrings
    {

        public static string AndroidPackageName = "com.ludo.chupamobile";
        public static string ITunesAppID = "11111111111";



        // Notifications
        public static string notificationTitle = "Ludo Masters";
        public static string notificationMessage = "Get your FREE fortune spin!";

        // Game configuration
        public static float WaitTimeUntilStartWithBots = 5.0f; // Time in seconds. If after that time new player doesnt join room game will start with bots

        // Services configration IDS
        public static string PlayFabTitleID = "ECED8";
        public static string PhotonAppID = "b0e1ab8d-c48c-447f-8917-a193846a85e3";
        public static string PhotonChatID = "a408d45c-e02d-4cb7-8854-223dd8088449";

        // Admob Ads IDS
        public static string adMobAndroidID = "ca-app-pub-4150875028712336/345325345";
        public static string adMobiOSID = "ca-app-pub-4150875028712336/253535234";

        // Facebook share variables
        public static string facebookShareLinkTitle = "I'm playing Ludo Masters!. Available on Android and iOS.";

        // Share private room code
        public static string SharePrivateLinkMessage = "Join me in Ludo Masters. My PRIVATE ROOM CODE is:";
        public static string SharePrivateLinkMessage2 = "Download Ludo Masters from:";
        public static string ShareScreenShotText = "I finished game in Ludo Masters. It's my score :-) Join me and download Ludo Masters:";


        // Initial coins count for new players
        // When logged as Guest
        public static int initCoinsCountGuest = 5000;
        //When logged via Facebook
        public static int initCoinsCountFacebook = 20000;
        //When logged as Guest and then link to Facebook
        public static int CoinsForLinkToFacebook = 15000;

        // Unity Ads - reward coins count for watching video
        public static int rewardForVideoAd = 250;

        // Facebook Invite variables
        public static string facebookInviteMessage = "Come play this great game!";
        public static int rewardCoinsForFriendInvite = 250;
        public static int rewardCoinsForShareViaFacebook = 50;

        // String to add coins for testing - To add coins start game, click "Edit" button on your avatar and put that string
        // It will add 1 000 000 coins so you can test tables, buy items etc.
        public static string addCoinsHackString = "Cheat:AddCoins";



        // Hide Coins tab in shop (In-App Purchases)
        public static bool hideCoinsTabInShop = false;
        public static string runOutOfTime = "ran out of time";
        public static string waitingForOpponent = "Waiting for your opponent";

        // Other strings
        public static string youAreBreaking = "You start, good luck";
        public static string opponentIsBreaking = "is starting";
        public static string IWantPlayAgain = "I want to play again!";
        public static string cantPlayRightNow = "Can't play right now";

        // Players names for training mode
        public static string offlineModePlayer1Name = "Player 1";
        public static string offlineModePlayer2Name = "Player 2";

        // Photon configuration
        // Timeout in second when player will be disconnected when game in background
        public static float photonDisconnectTimeout = 0.2f; // In game scene - its better to don't change it. Player that loose focus on app will be immediately disconnected
        public static float photonDisconnectTimeoutLong = 300.0f; // In menu scene etc. 

        // Bids Values
        public static int[] bidValues = new int[] { 500, 2000, 10000, 50000, 250000, 1000000, 2000000, 5000000 };
        public static string[] bidValuesStrings = new string[] { "500", "2000", "10k", "50k", "250k", "1M", "2M", "5M" };

        public static bool isFourPlayerModeEnabled = true;

        // Settings PlayerPrefs keys
        public static string SoundsKey = "EnableSounds";
        public static string VibrationsKey = "EnableVibrations";
        public static string NotificationsKey = "EnableNotifications";
        public static string FriendsRequestesKey = "EnableFriendsRequestes";
        public static string PrivateRoomKey = "EnablePrivateRoomRequestes";
        public static string PrefsPlayerRemovedAds = "UserRemovedAds";


        // Standard chat messages
        public static string[] chatMessages = new string[] {
            "Please don't kill",
            "Play Fast",
            "I will eat you",
            "You are good",
            "Well played",
            "Today is your day",
            "Hehehe",
            "Unlucky",
            "Thanks",
            "Yeah",
            "Remove Blockade",
            "Good Game",
            "Oops",
            "Today is my day",
            "All the best",
            "Hi",
            "Hello",
            "Nice move"
        };

        // Additional chat messages
        // Prices for chat packs
        public static int[] chatPrices = new int[] { 1000, 5000, 10000, 50000, 100000, 250000 };
        public static int[] emojisPrices = new int[] { 1000, 5000, 10000, 50000, 100000 };

        // Chat packs names
        public static string[] chatNames = new string[] { "Motivate", "Emoticons", "Cheers", "Gags", "Laughing", "Talking" };

        // Chat packs strings
        public static string[][] chatMessagesExtended = new string[][] {
            new string[] {
                "Never give up",
                "You can do it",
                "I know you have it in you!",
                "You play like a pro!",
                "You can win now!",
                "You're great!"
            },
            new string[] {
                ":)",
                ":(",
                ":o",
                ";D",
                ":P",
                ":|"
            },
            new string[] {
                "Keep it going",
                "Go opponents!",
                "Fabulastic",
                "You're awesome",
                "Best shot ever",
                "That was amazing",
            },
            new string[] {
                "OMG",
                "LOL",
                "ROFL",
                "O'RLY?!",
                "CYA",
                "YOLO"
            },
            new string[] {
                "Hahaha!!!",
                "Ho ho ho!!!",
                "Mwhahahaa",
                "Jejeje",
                "Booooo!",
                "Muuuuuuuhhh!"
            },
            new string[] {
                "Yes",
                "No",
                "I don't know",
                "Maybe",
                "Definitely",
                "Of course"
            }
        };

    }
}

