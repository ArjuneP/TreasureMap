using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureMap.Map
{
    public class Adventurer : IMapElement
    {
        public int PosX { get; private set; }
        public int PosY { get; private set; }
        public string Name { get; set; }
        public Orientation Orientation { get; set; }
        public Dictionary<int, Movement> Movements { get; set; }
        public int TreasureCount { get; set; }

        public Adventurer(int posX, int posY, string name, Orientation orientation, Dictionary<int, Movement> movements)
        {
            this.PosX = posX;
            this.PosY = posY;
            this.Name = name;
            this.Orientation = orientation;
            this.Movements = movements;
            this.TreasureCount = 0;
        }

        public MapElementType GetMapElementType()
        {
            return MapElementType.A;
        }

        public void ProcessMovement(int tour, MapGlobal map)
        {
            Movement move = this.Movements[tour];
            switch (move)
            {
                case Movement.A:
                    this.HandleA(map);
                    break;
                case Movement.G:
                    this.HandleG();
                    break;
                case Movement.D:
                    this.HandleD();
                    break;
                default:
                    break;
            }
        }
        
        private void HandleA(MapGlobal map)
        {
            int newPosX = 0;
            int newPosY = 0;
            //Get new coordinates
            switch (this.Orientation)
            {
                case Orientation.N:
                    newPosY = this.PosY - 1;
                    newPosX = this.PosX;
                    break;
                case Orientation.S:
                    newPosY = this.PosY + 1;
                    newPosX = this.PosX;
                    break;
                case Orientation.E:
                    newPosY = this.PosY;
                    newPosX = this.PosX + 1;
                    break;
                case Orientation.O:
                    newPosY = this.PosY;
                    newPosX = this.PosX - 1;
                    break;
                default:
                    break;
            }
            if (map.CheckIfCoordsAreInMap(newPosX, newPosY) && map.CheckIfWayIsFree(newPosX, newPosY))
            {
                //Handle Movement
                this.PosX = newPosX;
                this.PosY = newPosY;
                //Check Treasure
                if (map.CheckIfAvailableTreasureIsThere(newPosX, newPosY))
                {
                    Treasure treasure = map.GetTreasureByPosition(newPosX, newPosY);
                    this.TreasureCount++;
                    treasure.Count--;
                }
            }
        }

        private void HandleG()
        {
            switch (this.Orientation)
            {
                case Orientation.N:
                    this.Orientation = Orientation.O;
                    break;
                case Orientation.S:
                    this.Orientation = Orientation.E;
                    break;
                case Orientation.E:
                    this.Orientation = Orientation.N;
                    break;
                case Orientation.O:
                    this.Orientation = Orientation.S;
                    break;
                default:
                    break;
            }
        }

        private void HandleD()
        {
            switch (this.Orientation)
            {
                case Orientation.N:
                    this.Orientation = Orientation.E;
                    break;
                case Orientation.S:
                    this.Orientation = Orientation.O;
                    break;
                case Orientation.E:
                    this.Orientation = Orientation.S;
                    break;
                case Orientation.O:
                    this.Orientation = Orientation.N;
                    break;
                default:
                    break;
            }
        }
    }
    public enum Orientation
    {
        N,
        S,
        E,
        O
    }

    public enum Movement
    {
        A,
        G,
        D
    }
}
