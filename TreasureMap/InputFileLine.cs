using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreasureMap.Exceptions;
using TreasureMap.Map;

namespace TreasureMap
{
    public class InputFileLine
    {
        public int LineNumber { get; set; }
        public string[] Content { get; set; }
        public IMapElement MapElement { get; set; }

        public InputFileLine(int lineNumber, string[] content)
        {
            this.LineNumber = lineNumber;
            this.Content = content.Select(x => x.Trim()).ToArray();


            string mapElement = this.Content.FirstOrDefault();
            if (this.Content.FirstOrDefault() == null)
            {
                throw new InputFileException(string.Format("No map element in content: {0}", mapElement));
            }
            MapElementType mapElementType;
            if (!Enum.TryParse(mapElement, out mapElementType))
            {
                throw new InputFileException(string.Format("Wrong map element type: {0}", mapElement));
            }

            this.MapElement = MapFactory.CreateElement(mapElementType, this.Content, lineNumber);
        }
    }
}
