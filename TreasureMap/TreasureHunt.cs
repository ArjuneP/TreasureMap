using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreasureMap.Helpers;
using TreasureMap.Map;

namespace TreasureMap
{
    public class TreasureHunt
    {
        public string InputFilePath { get; private set; }
        public string OutputFilePath { get; private set; }

        public TreasureHunt(string inputFilePath, string outputFilePath)
        {
            this.InputFilePath = inputFilePath;
            this.OutputFilePath = outputFilePath;
        }

        public void Go()
        {
            try
            {
                Console.WriteLine("GO");
                MapGlobal map = InputFileHelper.ProcessInputFile(this.InputFilePath);
                Console.WriteLine("Input File OK");
                Simulator hunt = new Simulator(map);
                hunt.SimulateMovements();
                Console.WriteLine("Simulate Movements OK");
                OutputFileHelper.ProcessOutputFile(map, this.OutputFilePath);
                Console.WriteLine("Output File OK");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
