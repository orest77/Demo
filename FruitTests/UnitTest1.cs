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
        public void InputFileTest()
        {
            //Arrange           
            string texts;
            string result;
            //Act
            Fruit actual = new Fruit("banana", "yellow");

            var assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream("Project.txt"))
            using (var reader = new StreamReader(stream))
            using (StringWriter stringWriter = new StringWriter())

            {
                Console.SetOut(stringWriter);
                texts = reader.ReadToEnd();
                actual.Print();
                result = stringWriter.ToString();
            }

            //Assert
            String.Equals(texts.ToString(), result);
        
       
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
        [Test]        
        public void TestPrintToFile()
        {
            // Arrange
            Fruit fruit1 = new Fruit("banana", "yellow");
            Fruit fruit2 = new Fruit("apple", "green");
            Fruit fruit3 = new Fruit("strawberries", "red");
            Fruit[] expected = new Fruit[] { fruit1, fruit2, fruit3 };
            string result = String.Empty;
            //Act
            var assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream("Project.txt"))
            using (var reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    result += line + "\n";
                }
            }

            //Accert     
            CollectionAssert.Equals(expected.ToString(), result);

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
