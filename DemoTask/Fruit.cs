using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTask
{
    
    class Fruit
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
                name = value;
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
                color = value;
            }
        }

        public Fruit()
        { }

        public Fruit(string _name , string _color)
        {
            this.name = _name;
            this.color = _color;
        }

        virtual public void Input()
        {
            Console.WriteLine("Input some fruit");
            name = Console.ReadLine();
            Console.WriteLine($"Input color {name}");
            color = Console.ReadLine();
        }

        virtual public void Print()
        {
            Console.WriteLine("Mame: {0} Color: {1}", this.name, this.color);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
