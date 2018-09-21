using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DemoTask
{
    // Утворити клас Фрукт, який містить:
    //- поля назва та колір,
    //- визначити конструктор з параметрами,
    //- віртуальні методи Input() та Print(), для зчитування даних з консолі та виведення даних на консоль, а також перевантажити варіанти введення-виведення з файлу.
    //- властивості для полів, 
    //- перевизначити метод ToString(). 
    [Serializable]
    [XmlInclude(typeof(Citrus))]
    public class Fruit : IComparable<Fruit>
    {
        private string name;
        private string color;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value.ToLower();
            }
        }
        public string Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value.ToLower();
            }
        }

        public Fruit()
        { }

        public Fruit(string _name , string _color)
        {
            Name = _name;
            Color = _color;
        }
        /// <summary>
        /// Input method from console
        /// </summary>
        public virtual void Input()
        {
            Console.WriteLine("Input some fruit");
            Name = Console.ReadLine();
            Console.WriteLine($"Input color {name}");
            Color = Console.ReadLine();
        }
        /// <summary>
        /// Overload  options from a file
        /// </summary>
        /// <param name="fruit"></param>
        public virtual void Input(string[] fruit)
        {
            name = fruit[0];
            color = fruit[1];           
        }
        /// <summary>
        /// Print metod from console
        /// </summary>
        public virtual void Print()
        {
            Console.WriteLine(this);
        }
        /// <summary>
        /// Method of writing data into a file
        /// </summary>
        /// <param name="pathToFile"></param>
        public virtual void Print(string pathToFile)
        {
            using (StreamWriter sw = new StreamWriter(pathToFile, true))
            {
                sw.WriteLine(this);
            }
        }
        /// <summary>
        /// Override to string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name + ": " + Color;
        }
        /// <summary>
        /// Sort data by name
        /// </summary>
        /// <param name="otherFruit"></param>
        /// <returns></returns>
        public int CompareTo(Fruit otherFruit)
        {          
            return this.Name.CompareTo(otherFruit.Name);
        }
    }
}
