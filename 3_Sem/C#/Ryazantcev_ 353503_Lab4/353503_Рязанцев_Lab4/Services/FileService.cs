using _353503_Рязанцев_Lab4.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _353503_Рязанцев_Lab4.Services
{
    internal class FileService<T> : IFileService<Person>
    {
        public IEnumerable<Person> ReadFile(string fileName)
        {
            using var fi = File.OpenRead(fileName);
            using var binReader = new BinaryReader(fi);
            string name = "";
            int flatNum = 0;
            bool isSold = false;
            while (binReader.PeekChar() != -1)
            {
                try
                {
                    flatNum = binReader.ReadInt32();
                    name = binReader.ReadString();
                    isSold = binReader.ReadBoolean();

                }
                catch
                {
                    Console.WriteLine("Couldn't read file");
                }
                yield return new Person(name, flatNum, isSold);
            }
            binReader.Close();
            fi.Close();
        }
        public void SaveData(IEnumerable<Person> data, string fileName)
        {
            using var fi = File.OpenWrite(fileName);
            using var binWriter = new BinaryWriter(fi);
            foreach (var obj in data)
            {
                try
                {
                    binWriter.Write(obj.FlatNum);
                    binWriter.Write(obj.Name);
                    binWriter.Write(obj.IsOwner);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            binWriter.Close();
            fi.Close();
        }
    }
}
