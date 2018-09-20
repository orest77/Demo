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
            this.Name = _name;
            this.Color = _color;
        }

        public virtual void Input()
        {
            Console.WriteLine("Input some fruit");
            Name = Console.ReadLine();
            Console.WriteLine($"Input color {name}");
            Color = Console.ReadLine();
        }

        public virtual void Input(string[] fruit)
        {
            Name = fruit[0];
            Color = fruit[1];           
        }

        public virtual void Print()
        {
            Console.WriteLine(this);
        }

        public virtual void Print(string pathToFile)
        {
            using (StreamWriter sw = new StreamWriter(pathToFile, true))
            {
                sw.WriteLine(this);
            }
        }

        public override string ToString()
        {
            return Name + ": " + Color;
        }

        public int CompareTo(Fruit otherFruit)
        {          
            return this.Name.CompareTo(otherFruit.Name);
        }
    }
}
