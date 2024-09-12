namespace MauiAppCountryISO
{
    public static class GlobalProperties
    {
        public static async Task<string> GetTokenAsync()
        {
            return await SecureStorage.GetAsync("auth_token");
        }

        public static async Task SetTokenAsync(string token)
        {
            await SecureStorage.SetAsync("auth_token", token);
        }
    }
}
