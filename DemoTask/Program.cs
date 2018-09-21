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


            /// <summary>
            /// Provide interception of exceptional situations
            /// Check for files to read
            /// If there are no files, run the console input
            /// </summary>   
            if (File.Exists(Constants.FileTxtforLoad) &&
                new FileInfo(Constants.FileTxtforLoad).Length > 0)
            {
                fruits = LoadFruitsFromFile(Constants.FileTxtforLoad);
            }
            else if (File.Exists(Constants.FileXmlSerialize) &&
                new FileInfo(Constants.FileXmlSerialize).Length > 0)
            {
                fruits = DeserializeXmlFormat(Constants.FileXmlSerialize);
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
                        fruit.Print(Constants.FileTxtforLoad);
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    SerializeInXmlFormat(fruits, Constants.FileXmlSerialize);                    
                }
            }

            fruits.Sort();

            foreach (Fruit fruit in fruits)
            {
                fruit.Print();
            }
            /// <summary>
            ///Print fruits of yellow color
            /// <summary>
            Console.WriteLine("__Yellow fruits__");
            foreach (Fruit ColorFruit in fruits.Where(x => x.Color == "yellow"))
            {
                ColorFruit.Print();
            }

           

            Console.ReadKey();

        }
        /// <summary>
        /// Method to load data 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Method for Serialize
        /// </summary>
        /// <param name="fruits"></param>
        /// <param name="fileName"></param>
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
        /// <summary>
        /// method for Deserialize
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
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
