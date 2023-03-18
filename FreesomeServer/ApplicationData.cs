using K4os.Compression.LZ4.Streams;
using System.Text;

namespace FreesomeServer
{
    public class User
    {

    }
    public class ApplicationData
    {
        #region Properties
        public List<User> Users { get; set; } = new();
        #endregion

        #region Methods
        public static void Save(string filepath, ApplicationData data)
        {
            using LZ4EncoderStream stream = LZ4Stream.Encode(File.Create(filepath));
            using BinaryWriter writer = new(stream, Encoding.UTF8, false);
            WriteToStream(writer, data);
        }
        public static ApplicationData Load(string filepath)
        {
            using LZ4DecoderStream source = LZ4Stream.Decode(File.OpenRead(filepath));
            using BinaryReader reader = new(source, Encoding.UTF8, false);
            return ReadFromStream(reader);
        }
        #endregion

        #region Routines
        private static void WriteToStream(BinaryWriter writer, ApplicationData data)
        {
            writer.Write(data.Users.Count);
            foreach (User user in data.Users)
            {
            }
        }
        private static ApplicationData ReadFromStream(BinaryReader reader)
        {
            ApplicationData applicationData = new();

            {
                var userCount = reader.ReadInt32();
                for (int i = 0; i < userCount; i++)
                {
                    var user = new User()
                    {
                    };
                    applicationData.Users.Add(user);
                }
            }

            return applicationData;
        }
        #endregion
    }
}
