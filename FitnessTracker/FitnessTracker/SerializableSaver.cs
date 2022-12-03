using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FitnessTracker
{
    public class SerializableSaver : IDataSaver
    {
        public void Save<T>(List<T> values) where T : class
        {
            var fileName = typeof(T).Name;
            fileName += ".json";

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(fs, values, options);
            }
        }

        public List<T> GetInfo<T>() where T : class
        {
            var fileName = typeof(T).Name;
            fileName += ".json";

            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && JsonSerializer.Deserialize<List<T>>(fs) is List<T> items)
                {
                    return items;
                }
                else
                {
                    return new List<T>();
                }
            }
        }
    }
}
