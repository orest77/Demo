using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DemoTask
{
    class Program
    {
        //Утворити List фруктів і додати до нього 5 різних фруктів і цитрусів.
        //- Видрукувати дані про ті фрукти, колір яких є 'жовтий'.
        //- Посортувати список фруктів за назвою і результат вивести у файл
        //- Передбачити перехоплення виняткових ситуацій
        //- Сериалізувати-десериалізувати список у Xml форматі
        //- Написати юніт-тести на методи класів

        static void Main(string[] args)
        {
            List<Fruit> fruits = new List<Fruit>();


            if (File.Exists("fruit.txt") &&
                new FileInfo("fruit.txt").Length > 0)
            {
                fruits = LoadFruitsFromFile("fruit.txt");
            }
            else if (File.Exists("XmlSerialize.xml") &&
                new FileInfo("XmlSerialize.xml").Length > 0)
            {
                fruits = DeserializeXmlFormat("XmlSerialize.xml");
            }
            else
            {
                try
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
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    SerializeInXmlFormat(fruits, "XmlSerialize.xml");                    
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

        public static void SerializeInXmlFormat(List<Fruit> fruits, string fileName)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Fruit>));
            try
            {
                using (FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
                {
                    xmlFormat.Serialize(fileStream, fruits);
                }
                Console.WriteLine("--> Save object in XML-format");
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }

        }

        public static List<Fruit> DeserializeXmlFormat(string fileName)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Fruit>));
            try
            {
                using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    return  (List<Fruit>)xmlFormat.Deserialize(fileStream);
                }              
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Failed not found of deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                Console.WriteLine("--> Deserialize object of XML-format");
            }
        }
    }
}
