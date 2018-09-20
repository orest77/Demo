using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using DemoTask;
using System.IO;
using System.Reflection;

namespace FruitTests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void ConversionLiterTest()
        {
            //Arrange           
            string expected = "banana" + ": " + "yellow";

            //Act
            Fruit actual = new Fruit("Banana", "Yellow");

            //Assert
            Assert.AreEqual(actual, expected);
        }
        [Test]
        public void InputTest()
        {
            //Arrange
            string stringConsole = "Banana\n" + "Yellow";
            string name = "Banana";
            string color = "Yellow";
            Fruit actual = new Fruit(name, color);
            string expected = "banana" + ": " + "yellow";

            //Act        
            using (StringReader stringReader = new StringReader(stringConsole))
            {
                Console.SetIn(stringReader);
                actual.Input();
           
            }

            //Assert
            String.Equals(actual, expected);
        }
        [Test]
        public void InputFileTest()
        {
            //Arrange           
            string texts;

            //Act
            Fruit actual = new Fruit("Banana", "Yellow");
           
            var assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream("Project.txt"))
            using (var reader = new StreamReader(stream))
            {
                texts = reader.ReadToEnd();
            }

            //Assert
            Assert.AreEqual(actual, texts);
        }
       
    }
}
