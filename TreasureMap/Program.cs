using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreasureMap.Helpers;
using TreasureMap.Map;

namespace TreasureMap
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFilePath = @"F:\Work\TreasureMap\inputFile2.txt";
            string outputFilePath = @"F:\Work\TreasureMap\outputFile.txt";
            TreasureHunt hunt = new TreasureHunt(inputFilePath, outputFilePath);

            hunt.Go();
        }
    }
}
