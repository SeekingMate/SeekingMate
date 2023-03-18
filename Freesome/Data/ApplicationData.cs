namespace Freesome.Data
{
    internal class ApplicationData
    {
        private string _Username = SecureStorage.Default.GetAsync(nameof(Username)).Result;
        public string Username
        {
            get => _Username;
            set
            {
                _Username = value;
                SecureStorage.Default.SetAsync(nameof(Username), value ?? string.Empty);
            }
        }
        public bool IsLoggedIn 
        { 
            get => bool.Parse(SecureStorage.Default.GetAsync(nameof(IsLoggedIn)).Result); 
            set => SecureStorage.Default.SetAsync(nameof(IsLoggedIn), IsLoggedIn.ToString());
        }
    }
}
