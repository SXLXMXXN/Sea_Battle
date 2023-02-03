using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea_Battle
{
    public class Ship
    {

        private List<Cell> _shipPlace = new List<Cell>();
        public IReadOnlyList<Cell> ShipPlace => _shipPlace;
        private List<Cell> _nearShip = new List<Cell>();
        public IReadOnlyList<Cell> NearShip => _nearShip;
        public bool IsSink = false;
        public int DeckCount;


        public Ship(int deckCounter) { DeckCount = deckCounter; }

        public void AddShipPlace(Cell cell)
        {
            _shipPlace.Add(cell);
        }

        public void AddNearShip(Cell cell)
        {
            _nearShip.Add(cell);
        }
    }
}
