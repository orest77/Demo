using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DemoTask
{
    //Утворити похідний від нього клас Цитрус, який має:
    //- поле - вміст вітаміну С в грамах, 
    //- конструктор з параметрами, 
    //- властивість, 
    //- перевизначені методи Input() та Print().

    [Serializable]
    public class Citrus : Fruit
    {
        private double vitaminC;

        public double VitaminC { get { return vitaminC; } set { vitaminC = value; } }

        public Citrus()
        {

        }

        public Citrus(string _name, string _color, double _vitaminC) : base(_name, _color)
        {
            this.vitaminC = _vitaminC;
        }

        public override void Input()
        {
            Console.WriteLine("Input some citrus");
            Name = Console.ReadLine();
            Console.WriteLine($"Input color {Name}");
            Color = Console.ReadLine();
            Console.WriteLine("Enter the gram of vitamin С");
            try
            {
                vitaminC = Convert.ToDouble(Console.ReadLine().Replace(".", ","));
            }
            catch
            {
                throw new Exception("Wrong string-to-double format");
            }
        }

        public override void Input(string[] fruit)
        {
            Name = fruit[0];
            Color = fruit[1];
            try
            {
                vitaminC = Convert.ToDouble(fruit[2].Replace(".", ","));
            }
            catch
            {
                throw new Exception("Wrong string-to-double format");
            }
        }

        public override void Print()
        {
            Console.WriteLine(this);
        }

        public override void Print(string pathToFile)
        {
            using (StreamWriter sw = new StreamWriter(pathToFile, true))
            {
                sw.WriteLine($"{this.Name}: {this.Color}: {this.vitaminC}");
                
            }
        }

        public override string ToString()
        {           
            return base.Name.ToString() + ": " + this.Color + ": " + this.vitaminC;
        }
    }
}
