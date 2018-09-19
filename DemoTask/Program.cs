using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DemoTask
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Fruit> fruits = new List<Fruit>();


            if (File.Exists("fruit.txt") && File.ReadAllText("fruit.txt").Length != 0)
            {
                fruits = LoadFruitsFromFile("fruit.txt");
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    fruits.Add(new Fruit());
                    fruits.Add(new Citrus());
                }


                foreach (Fruit fruit in fruits)
                {
                    fruit.Input();
                    fruit.Print();
                    fruit.Print("fruit.txt");
                }
            }
            fruits.Sort();
            foreach (Fruit fruit in fruits)
            {
                fruit.Print();
            }

            Console.WriteLine("__Yellow fruits__");
            foreach (Fruit ColorFruit in fruits.Where(x => x.Color == "yellow"))
            {
                ColorFruit.Print();
            }

            SaveInXmlFormat(fruits, "XmlSerialize.xml");
            DeserializeXmlFormat(fruits,"XmlSerialize.xml");

            Console.ReadKey();

        }

        private static List<Fruit> LoadFruitsFromFile(string path)
        {
            List<Fruit> resultList = new List<Fruit>();
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] resultFruit = sr.ReadLine().Split(new char[] { ':' });

                        switch (resultFruit.Length)
                        {
                            case 2:
                                Fruit fruit = new Fruit();
                                resultList.Add(fruit);
                                fruit.Input(resultFruit);
                                break;
                            case 3:
                                Fruit citrus = new Citrus();
                                resultList.Add(citrus);
                                citrus.Input(resultFruit);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return resultList;
        }

        public static void SaveInXmlFormat(List<Fruit> fruits, string fileName)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Fruit>));
            using (FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
            {
                xmlFormat.Serialize(fileStream, fruits);
            }
            Console.WriteLine("--> Save object in XML-format");

        }
        public static void DeserializeXmlFormat(List<Fruit> fruits, string fileName)
        {

            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Fruit>));
            using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
            {
                fruits = (List<Fruit>)xmlFormat.Deserialize(fileStream);
            }
            Console.WriteLine("--> Deserialize object of XML-format");
        }
    }
}
