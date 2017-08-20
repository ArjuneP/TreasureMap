using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreasureMap.Exceptions;
using TreasureMap.Map;

namespace TreasureMap.Helpers
{
    public static class InputFileHelper
    {
        //public List<InputFileLine> InputFileLines { get; set; }
        //public MapGlobal Map { get; set; }

        public static MapGlobal ProcessInputFile(string filePath)
        {
            //var fileInfos = File.ReadAllLines(filePath).Where(x => !x.StartsWith("#"));
            var fileInfos = File.ReadAllLines(filePath);
            int i = 0;
            List<InputFileLine> inputFileLines = new List<InputFileLine>();
            foreach (string line in fileInfos)
            {
                i++;
                if (line.StartsWith("#"))
                {
                    continue;
                }

                string[] lineInfos = line.Split('-');
                if (lineInfos.FirstOrDefault() == null)
                {
                    throw new InputFileException(string.Format("No element on line {0}", i));
                }
                InputFileLine inputFileLine = new InputFileLine(i, lineInfos);
                inputFileLines.Add(inputFileLine);
            }
            if (!CheckIntegrity(inputFileLines))
            {
                throw new InputFileException("Duplicate element (posX, posY)");
            }
            return new MapGlobal(inputFileLines.Select(x => x.MapElement).ToList());
        }

        private static bool CheckIntegrity(List<InputFileLine> inputFileLines)
        {
            var mapElements = inputFileLines.Select(x => x.MapElement);
            var grouped = mapElements.GroupBy(x => new { x.PosX, x.PosY });

            if (grouped.Any(g => g.Count() > 1))
            {
                return false;
            }
            return true;
        }
        //public InputFile(string filePath)
        //{
        //    //var fileInfos = File.ReadAllLines(filePath).Where(x => !x.StartsWith("#"));
        //    var fileInfos = File.ReadAllLines(filePath);
        //    int i = 0;
        //    this.InputFileLines = new List<InputFileLine>();
        //    foreach (string line in fileInfos)
        //    {
        //        i++;
        //        if (line.StartsWith("#"))
        //        {
        //            continue;
        //        }

        //        string[] lineInfos = line.Split('-');
        //        if (lineInfos.FirstOrDefault() == null)
        //        {
        //            throw new InputFileException(string.Format("No element on line {0}", i));
        //        }
        //        InputFileLine inputFileLine = new InputFileLine(i, lineInfos);
        //        this.InputFileLines.Add(inputFileLine);
        //    }
        //    this.Map = new MapGlobal(this.InputFileLines.Select(x => x.MapElement).ToList());
        //}

        //public void SimulateMovements()
        //{

        //}

        //public void WriteOutputFile()
        //{

        //}
    }
}
