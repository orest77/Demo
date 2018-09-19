using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            foreach(Fruit ColorFruit in fruits.Where(x => x.Color == "yellow" ) )
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
    }
}
