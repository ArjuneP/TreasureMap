using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreasureMap.Exceptions;

namespace TreasureMap.Map
{
    public static class MapFactory
    {
        public static IMapElement CreateElement(MapElementType mapElementType, string[] content, int i)
        {
            if (content.Length < 3)
            {
                throw new InputFileException(string.Format("Line {0} does not contain at least 3 elements {1}", i, string.Join(", ", content)));
            }
            string x = content[1];
            string y = content[2];
            switch (mapElementType)
            {
                case MapElementType.C:
                    return CreateMapInfo(content, i);
                case MapElementType.M:
                    return CreateMountain(content, i);
                case MapElementType.T:
                    return CreateTreasure(content, i);
                case MapElementType.A:
                    return CreateAdventurer(content, i);
                default:
                    return null;
            }
        }
        private static IMapElement CreateMapInfo(string[] content, int i)
        {
            int x = Int16.Parse(content[1].Trim());
            int y = Int16.Parse(content[2].Trim());
            return new MapInfo(x, y);
        }
        private static IMapElement CreateMountain(string[] content, int i)
        {
            int posX = Int16.Parse(content[1].Trim());
            int posY = Int16.Parse(content[2].Trim());
            return new Mountain(posX, posY);
        }
        private static IMapElement CreateTreasure(string[] content, int i)
        {
            if (content.Length < 4)
            {
                throw new InputFileException(string.Format("Line {0} does not contain 4 elements: {1}", i, string.Join(", ", content)));
            }
            int posX = Int16.Parse(content[1].Trim());
            int posY = Int16.Parse(content[2].Trim());
            int count = Int16.Parse(content[3].Trim());
            return new Treasure(posX, posY, count);
        }
        private static IMapElement CreateAdventurer(string[] content, int i)
        {
            if (content.Length < 6)
            {
                throw new InputFileException(string.Format("Line {0} does not contain 6 elements: {1}", i, string.Join(", ", content)));
            }
            int posX = Int16.Parse(content[2].Trim());
            int posY = Int16.Parse(content[3].Trim());
            string name = content[1];
            Orientation orientation = (Orientation)Enum.Parse(typeof(Orientation), content[4].Trim());
            var movements = content[5].Trim().Select(mov => mov.ToString()).ToList();
            //var movementsEnum = movements.Select(mov => (Movement)Enum.Parse(typeof(Movement), mov)).ToList();
            //var movementsDictionnary = movementsEnum.ToDictionary(mov => movementsEnum.IndexOf(mov));
            var movementsDictionnary = movements.Select((val, index) => new { Index = index, Value = val })
                .ToDictionary(key => key.Index, key => (Movement)Enum.Parse(typeof(Movement), key.Value));

            return new Adventurer(posX, posY, name, orientation, movementsDictionnary);
        }
    }
}
