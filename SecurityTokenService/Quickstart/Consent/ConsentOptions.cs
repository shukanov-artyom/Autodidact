namespace SecurityTokenService.Quickstart.Consent
{
    public class ConsentOptions
    {
        private static bool enableOfflineAccess = true;

        public static string OfflineAccessDisplayName
        {
            get
            {
                return "Offline Access";
            }
        }

        public static string OfflineAccessDescription
        {
            get
            {
                return "Access to your applications and resources, even when you are offline";
            }
        }

        public static string MustChooseOneErrorMessage
        {
            get
            {
                return "You must pick at least one permission";
            }
        }

        public static string InvalidSelectionErrorMessage
        {
            get
            {
                return "Invalid selection";
            }
        }

        public static bool EnableOfflineAccess
        {
            get => enableOfflineAccess;
            set => enableOfflineAccess = value;
        }
    }
}
