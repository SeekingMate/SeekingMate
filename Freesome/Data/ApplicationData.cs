namespace Freesome.Data
{
    internal class ApplicationData
    {
        public string Username
        {
            get => SecureStorage.Default.GetAsync(nameof(Username)).Result;
            set => SecureStorage.Default.SetAsync(nameof(Username), Username);
        }
        public bool IsLoggedIn 
        { 
            get => bool.Parse(SecureStorage.Default.GetAsync(nameof(IsLoggedIn)).Result); 
            set => SecureStorage.Default.SetAsync(nameof(IsLoggedIn), IsLoggedIn.ToString());
        }
    }
}
