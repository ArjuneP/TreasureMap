using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreasureMap;
using System.IO;

namespace TreasureMap.Tests
{
    [TestFixture]
    public class TreasureHuntTests
    {
        [SetUp]
        public void Setup()
        {
            string testFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tests");
            if (!Directory.Exists(testFolder))
            {
                Directory.CreateDirectory(testFolder);
            }
        }
        [TearDown]
        public void TearDown()
        {
            string testFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tests");
            if (Directory.Exists(testFolder))
            {
                Directory.Delete(testFolder, true);
            }
        }
        [Test]
        public void Go_InputFileOutputFile_ShouldBeCorrect()
        {
            //Arrange
            string inputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tests", "Go_InputFile_Correct.txt");
            string outputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tests", "Go_OutputFile_Correct.txt");
            File.WriteAllText(inputFilePath, Properties.Resources.Go_InputFile_Correct);
            TreasureHunt treasureHunt = new TreasureHunt(inputFilePath, outputFilePath);
            string[] expectedResult = new List<string>()
            {
                "C - 3 - 4",
                "M - 1 - 0",
                "M - 2 - 1",
                "T - 1 - 3 - 2",
                "A - Lara - 0 - 3 - S - 3"
            }.ToArray();
            //Act
            treasureHunt.Go();
            string[] actualResult = System.IO.File.ReadAllLines(outputFilePath);
            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
