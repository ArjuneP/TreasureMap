using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreasureMap.Map;
using TreasureMap.Utils;

namespace TreasureMap.Helpers
{
    public static class OutputFileHelper
    {
        public static void ProcessOutputFile(MapGlobal map, string filePath)
        {
            List<string> content = new List<string>();
            foreach (IMapElement elmt in map.MapElements)
            {
                string newLine = GetLineByIMapElement(elmt);
                if (!string.IsNullOrEmpty(newLine))
                {
                    content.Add(newLine);
                }
            }
            File.WriteAllLines(filePath, content);
        }

        private static string GetLineByIMapElement(IMapElement elmt)
        {
            string line = string.Empty;
            new Switch(elmt)
                .Case<MapInfo>(e => { line = string.Join(" - ", MapElementType.C, e.PosX, e.PosY); })
                .Case<Mountain>(e => { line = string.Join(" - ", MapElementType.M, e.PosX, e.PosY); })
                .Case<Treasure>(e => { line = (e.Count > 0) ? string.Join(" - ", MapElementType.T, e.PosX, e.PosY, e.Count) : null; })
                .Case<Adventurer>(e => { line = string.Join(" - ", MapElementType.A, e.Name, e.PosX, e.PosY, e.Orientation.ToString(), e.TreasureCount); });
            return line;
        }
    }
}
