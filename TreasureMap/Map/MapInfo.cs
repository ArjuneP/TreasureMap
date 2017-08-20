using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureMap.Map
{
    public class MapInfo : IMapElement
    {
        public int PosX { get; set; }
        public int PosY { get; set; }

        public MapInfo(int posX, int posY)
        {
            this.PosX = posX;
            this.PosY = posY;
        }

        public MapElementType GetMapElementType()
        {
            return MapElementType.C;
        }
    }
}
