namespace Web_Api.Utils
{
    
    internal static class Authorizations
    {
        public const string Admin = "Admin";
        public const string Manager = "Manager";
        public const string Standard = "Standard";

        public const string RequireAdminOrManagerRole = "RequireAdminOrManagerRole";
    }
}