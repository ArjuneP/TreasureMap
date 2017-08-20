using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureMap.Map
{
    public class Mountain : IMapElement
    {
        public int PosX { get; private set; }
        public int PosY { get; private set; }

        public Mountain(int posX, int posY)
        {
            this.PosX = posX;
            this.PosY = posY;
        }

        public MapElementType GetMapElementType()
        {
            return MapElementType.M;
        }
    }
}
