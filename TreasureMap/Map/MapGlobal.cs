using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureMap.Map
{
    public class MapGlobal
    {
        public List<IMapElement> MapElements { get; set; }
        public List<Tuple<MapElementType, IMapElement>> MapElementsTuple { get; set; }

        public MapGlobal(List<IMapElement> mapElements)
        {
            this.MapElements = mapElements;
            this.MapElementsTuple = mapElements.Select(
                iMapElmt => new Tuple<MapElementType, IMapElement>(iMapElmt.GetMapElementType(), iMapElmt))
                .ToList();
        }

        public bool CheckIfMapElementIsThere<T>(int posX, int posY) where T : IMapElement
        {
            var element = this.MapElements.FirstOrDefault(
                elmt => elmt.PosX == posX
                && elmt.PosY == posY
                && elmt.GetType() == typeof(T));
            return (element != null) ? true : false;
        }

        public bool CheckIfWayIsFree(int posX, int posY)
        {
            var element = this.MapElements.FirstOrDefault(
                elmt => elmt.PosX == posX
                && elmt.PosY == posY
                && (elmt.GetType() == typeof(Mountain) || elmt.GetType() == typeof(Adventurer))
                );
            return (element == null) ? true : false;
        }

        public bool CheckIfCoordsAreInMap(int posX, int posY)
        {
            var element = this.MapElements.FirstOrDefault(x => x.GetType() == typeof(MapInfo));
            if (element == null)
            {
                throw new Exception();
            }
            else
            {
                MapInfo mapInfo = (MapInfo)element;
                return (posX > mapInfo.PosX - 1 || posX < 0 || posY > mapInfo.PosY - 1 || posY < 0) ? false : true;
            }
        }

        public bool CheckIfAvailableTreasureIsThere(int posX, int posY)
        {
            var element = this.MapElements.FirstOrDefault(
                elmt => elmt.PosX == posX
                && elmt.PosY == posY
                && elmt.GetType() == typeof(Treasure));
            if (element == null)
            {
                return false;
            }
            else
            {
                Treasure treasure = (Treasure)element;
                return (treasure.Count > 0) ? true : false;
            }
        }

        public Treasure GetTreasureByPosition(int posX, int posY)
        {
            var treasureElement = this.MapElements.FirstOrDefault(trs => 
            trs.PosX == posX 
            && trs.PosY == posY 
            && trs.GetType() == typeof(Treasure));
            return (treasureElement != null) ? (Treasure)treasureElement : null;
        }

        //public bool CheckIfMountain(int posX, int posY)
        //{
        //    var element = this.MapElements.FirstOrDefault(
        //        elmt => elmt.PosX == posX
        //        && elmt.PosY == posY
        //        && elmt.GetType() == typeof(Mountain));
        //    return (element != null) ? true : false;
        //}

        //public bool CheckIfTreasure(int posX, int posY)
        //{
        //    var element = this.MapElements.FirstOrDefault(
        //        elmt => elmt.PosX == posX
        //        && elmt.PosY == posY
        //        && elmt.GetType() == typeof(Treasure));
        //    if (element == null)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        Treasure treasure = (Treasure)element;
        //        return (treasure.Count > 0) ? true : false;
        //    }
        //}

        //public bool CheckIfAdventurerAlreadyThere(int posX, int posY)
        //{
        //    var element = this.MapElements.FirstOrDefault(
        //        elmt => elmt.PosX == posX
        //        && elmt.PosY == posY
        //        && elmt.GetType() == typeof(Adventurer));
        //    return (element != null) ? true : false;
        //}

    }
}
