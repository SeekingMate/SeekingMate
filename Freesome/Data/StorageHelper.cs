namespace Freesome.Data
{
    public static class StorageHelper
    {
        public static async Task UpdateValue(string name, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                SecureStorage.Default.Remove(name);
            else
                await SecureStorage.Default.SetAsync(name, value);
        }
    }
}
