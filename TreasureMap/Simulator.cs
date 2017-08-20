using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreasureMap.Map;

namespace TreasureMap
{
    public class Simulator
    {
        public MapGlobal Map { get; set; }

        public Simulator(MapGlobal map)
        {
            this.Map = map;
        }

        public void SimulateMovements()
        {
            //var adventurers = map.MapElementsTuple
            //    .Where(x => x.Item1 == MapElementType.A)
            //    .Select(x => x.Item2);

            var adventurers = this.Map.MapElements.Where(x => x.GetType() == typeof(Adventurer)).Cast<Adventurer>().ToList();
            int maxTours = adventurers.Max(x => x.Movements.Count);
            int tour = 0;
            while (tour < maxTours)
            {
                NewTurn(tour, adventurers);
                tour++;
            }
        }

        private void NewTurn(int tour, List<Adventurer> adventurers)
        {
            var movingAdventurers = adventurers.Where(x => x.Movements.Keys.Contains(tour));
            foreach (Adventurer adventurer in movingAdventurers)
            {
                adventurer.ProcessMovement(tour, this.Map);
            }
        }
    }
}
