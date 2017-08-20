using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureMap.Map
{
    public class Treasure : IMapElement
    {
        public int PosX { get; private set; }
        public int PosY { get; private set; }
        public int Count { get; set; }

        public Treasure(int posX, int posY, int count)
        {
            this.PosX = posX;
            this.PosY = posY;
            this.Count = count;
        }

        public MapElementType GetMapElementType()
        {
            return MapElementType.T;
        }
    }
}
