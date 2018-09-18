using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTask
{
    class Citrus : Fruit
    {
        private double vitaminC;

        public double VitaminC { get; set; }



        public Citrus(string _name, string _color, double _vitaminC) : base(_name, _color)
        {
            this.vitaminC = _vitaminC;
        }

        override public void Print()
        {
            Console.WriteLine("Mame: {0} Color: {1} Vitamin C {2}", base.Name, base.Color, this.vitaminC );
        }

        public override void Input()
        {
            base.Input();
            Console.WriteLine("enter the gram of vitamin С");
            vitaminC = double.Parse(Console.ReadLine());
        }





    }
}
