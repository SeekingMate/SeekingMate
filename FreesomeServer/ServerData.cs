using K4os.Compression.LZ4.Streams;
using System.Text;

namespace FreesomeServer
{
    public class User
    {
        public int ID { get; set; }
        public string AccessCodeHash { get;set; }
        public string PassphraseHash { get;set; }
        public string LoginCredential { get; set; }
    }
    public class ServerData
    {
        #region Properties
        public List<User> Users { get; set; } = new();
        #endregion

        #region Methods
        public static void Save(string filepath, ServerData data)
        {
            using LZ4EncoderStream stream = LZ4Stream.Encode(File.Create(filepath));
            using BinaryWriter writer = new(stream, Encoding.UTF8, false);
            WriteToStream(writer, data);
        }
        public static ServerData Load(string filepath)
        {
            using LZ4DecoderStream source = LZ4Stream.Decode(File.OpenRead(filepath));
            using BinaryReader reader = new(source, Encoding.UTF8, false);
            return ReadFromStream(reader);
        }
        #endregion

        #region Routines
        private static void WriteToStream(BinaryWriter writer, ServerData data)
        {
            writer.Write(data.Users.Count);
            foreach (User user in data.Users)
            {
                writer.Write(user.ID);
                writer.Write(user.AccessCodeHash);
                writer.Write(user.PassphraseHash);
            }
        }
        private static ServerData ReadFromStream(BinaryReader reader)
        {
            ServerData applicationData = new();

            {
                var userCount = reader.ReadInt32();
                for (int i = 0; i < userCount; i++)
                {
                    var user = new User()
                    {
                        ID = reader.ReadInt32(),
                        AccessCodeHash = reader.ReadString(),
                        PassphraseHash = reader.ReadString(),
                    };
                    applicationData.Users.Add(user);
                }
            }

            return applicationData;
        }
        #endregion
    }
}
