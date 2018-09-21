using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using DemoTask;
using System.IO;
using System.Reflection;
using System.Collections.Generic;

namespace FruitTests
{
    [TestFixture]
    public class UnitTest1
    {
        /// <summary>
        /// Verify lowercase
        /// </summary>
        [Test]
        public void ConversionLiterTest()
        {
            //Arrange           
            string expected = "banana: yellow";

            //Act
            Fruit actual = new Fruit("Banana", "Yellow");

            //Assert
            AssertionException.Equals(actual, expected);
        }
        /// <summary>
        /// Verify consove input
        /// </summary>
        [Test]
        public void InputToConsoleTest()
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
        public void TestPrintToConsole()
        {
            //Arrange
            Fruit fruit = new Fruit("banana", "yellow");
            string expected = "banana" +": " + "yellow\r\n";
            string result;

            //Act            
            using (StringWriter writer = new StringWriter())
            {
                Console.SetOut(writer);
                Console.SetError(writer);
                fruit.Print();
                result = writer.ToString();
            }

            //Assert
            Assert.AreEqual(expected, result);
        }
        /// <summary>
        /// Testing file and Frui data
        /// </summary>
        [Test]        
        public void TestPrintToFile()
        {
            // Arrange
           
            List<Fruit> expected = new List<Fruit>();
            expected.Add(new Fruit( "banana", "yellow"));
            expected.Add(new Fruit("apple", "green"));
            expected.Add(new Fruit("strawberries", "red"));
            expected.Add(new Citrus("tangerine", "orange", 19.5));
            expected.Add(new Citrus("lime", "green" , 19.6));
            expected.Add(new Citrus("orange", "orange", 14.2));
            
            string result = String.Empty;
            //Act
          
            using (var reader = new StreamReader(@"C:\Users\Orest\source\repos\DemoTask\Project.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {

                    result += line + "\r\n";
                }
            }

            //Accert     
            String.Equals(expected, result);

        }
        [Test]
        public void TestToString()
        {
            //Arrange
            Fruit fruit = new Fruit("banana", "yellow");
            string expected = "banana: yellow";

            //Act
            string result = fruit.ToString();

            //Accert     
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void TestPrintConsole()
        {
            //Arrange
            string expected = "banana: yellow";
            Fruit actual = new Fruit("banana","yellow");
            //Act
            
            string result;

            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                actual.Print();
                result = stringWriter.ToString();
            }

            //Assert
            String.Equals(expected, result);
        }

    }
}
