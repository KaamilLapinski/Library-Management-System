using Library_Management_System.App.Abstract;
using Library_Management_System.Domain.Common;
using Library_Management_System.Domain.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.App.Common
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        public static List<T> Elements { get; set; }

        public BaseService()
        {
            Elements = new List<T>();
        }

        public void AddElement(T element)
        {
            Elements.Add(element);
        }

        public List<T> GetAllElements()
        {
            return Elements;
        }

        public void RemoveElement(T element)
        {
            Elements.Remove(element);
        }

        public int GetLastId() 
        {
            int lastId;
            if (Elements.Any())
            {
                lastId = Elements.Last().Id;
            }
            else
            {
                lastId = 0;
            }
            return lastId;
        }

        public T GetElementById(int id)
        {
            var el = Elements.First(p => p.Id == id);
            return el;
        }
        public void saveDataToFile(string path)
        {
            using StreamWriter sw = new StreamWriter(@$"C:\temp\{path}.json");
            using JsonWriter writer = new JsonTextWriter(sw);

            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(writer, Elements);

        }
        public void loadDataFromFile(string path)
        {
            if (File.Exists(@$"C:\temp\{path}.json"))
            {
                string json = File.ReadAllText(@$"C:\temp\{path}.json");
                var elements = JsonConvert.DeserializeObject<List<T>>(json);
                Elements = elements;               
            }          
        }
    }
}
