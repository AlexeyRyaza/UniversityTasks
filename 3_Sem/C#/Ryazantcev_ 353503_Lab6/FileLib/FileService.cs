using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using Ryazantcev__353503_Lab6.Class;
using Ryazantcev__353503_Lab6.Interfaces;

namespace FileLib
{
    internal class FileService<T> : IFileService<T> where T : class
    {
        public IEnumerable<T> ReadFile(string fileName)
        {
            try
            {
                return JsonSerializer.Deserialize<List<T>>(File.ReadAllText(fileName));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error ocurred while Json derialization\nError message:" + ex.Message);
            }

            return new List<T>();
        }

        public void SaveData(IEnumerable<T> data, string fileName)
        {
            try
            {
                string json = JsonSerializer.Serialize(data);

                File.WriteAllText(fileName, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error ocurred while Json serialization\nError message:" + ex.Message);

            }
        }
    }
}
