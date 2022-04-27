using System.IO;
using Newtonsoft.Json;


namespace LoadImage
{
    public class FileHelper
    {
        private string _filePath;

        public FileHelper(string filePath)
        {
            _filePath = filePath;
        }

        public void SerializeToFile(string path)
        {
            var serializer = new JsonSerializer();

            using(var streamWriter = new StreamWriter(_filePath))
            {
                serializer.Serialize(streamWriter, path);
                streamWriter.Close();
            }

        }

        public string DeserializeFromFile()
        {
            if (!File.Exists(_filePath))
                return null;

            var serializer = new JsonSerializer();

            using(var streamReader = new StreamReader(_filePath))
            {
                var jsonReader = new JsonTextReader(streamReader);
                var path = serializer.Deserialize<string>(jsonReader);
                streamReader.Close();
                return path;
            }
        }

    }
}
