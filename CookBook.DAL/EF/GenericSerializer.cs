using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CookBook.DAL.EF
{
    public static class GenericSerializer
    {
        public static void Serialize<T>(IEnumerable<T> listForSerialize)
        {
            var serializer = new XmlSerializer(typeof(List<T>));
            using (FileStream fs = new FileStream(typeof(T).Name + ".xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, listForSerialize);
            }
        }

        public static List<T> Deserialize<T>()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<T>));
            List<T> list = new List<T>();
            if (File.Exists(typeof(T).Name + ".xml"))
            {
                using (FileStream fs = new FileStream(typeof(T).Name + ".xml", FileMode.Open))
                {
                    list = (List<T>)formatter.Deserialize(fs);
                }
            }
            return list;
        }
    }
}
