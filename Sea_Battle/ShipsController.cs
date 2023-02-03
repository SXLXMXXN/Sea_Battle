using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea_Battle
{
    public class ShipsController
    {
        public List<Ship> Ships = new List<Ship>();
        private Random _random = new Random();

        public void FillShips(CellsController cellsController)
        {
            Ships.Clear();
            int[] deck = new int[] { 4, 3, 3, 2, 2, 2, 1, 1, 1, 1 };
            for (int i = 0; i < deck.Length; i++)
            {

                Ships.Add(new Ship(deck[i]));
                PlaceShip(Ships[i], cellsController.Cells);
            }
        }

        private void PlaceShip(Ship ship, Cell[,] cells)
        {
            int row = cells.GetLength(0) - 1;
            int column = cells.GetLength(1) - 1;
            bool checkResult = false;
            int rRow = -1;
            int rColumn = -1;
            int modifierRow = 0;
            int modifierColumn = 0;
            int rdirection = _random.Next(0, 2);
            while (!checkResult)
            {
                if (rdirection == 0)
                {
                    rRow = _random.Next(0, cells.GetLength(0));
                    rColumn = _random.Next(0, cells.GetLength(1) - ship.DeckCount);
                }
                else
                {
                    rRow = _random.Next(0, cells.GetLength(0) - ship.DeckCount);
                    rColumn = _random.Next(0, cells.GetLength(1));
                }
                checkResult = true;
                for (int i = 0; i < ship.DeckCount; i++)
                {
                    if (rdirection == 0)
                    {
                        modifierColumn = i;
                    }
                    else
                    {
                        modifierRow = i;
                    }
                    checkResult = checkResult & !cells[rRow + modifierRow, rColumn + modifierColumn].IsShip;
                }
                for (int i = 0; i < ship.DeckCount; i++)
                {

                    if (rdirection == 0)
                    {
                        modifierColumn = i;
                    }
                    else
                    {
                        modifierRow = i;
                    }

                    if (rRow > 0)
                    {
                        checkResult = checkResult & !cells[rRow + modifierRow - 1, rColumn + modifierColumn].IsShip;
                    }
                    if (rColumn + i < column & rRow > 0)
                    {
                        checkResult = checkResult & !cells[rRow + modifierRow - 1, rColumn + modifierColumn + 1].IsShip;
                    }
                    if (rColumn + i < column)
                    {
                        checkResult = checkResult & !cells[rRow + modifierRow, rColumn + modifierColumn + 1].IsShip;
                    }
                    if (rColumn + i < column & rRow < row)
                    {
                        checkResult = checkResult & !cells[rRow + modifierRow + 1, rColumn + modifierColumn + 1].IsShip;
                    }
                    if (rRow < row)
                    {
                        checkResult = checkResult & !cells[rRow + modifierRow + 1, rColumn + modifierColumn].IsShip;
                    }
                    if (rRow < row & rColumn > 0)
                    {
                        checkResult = checkResult & !cells[rRow + modifierRow + 1, rColumn + modifierColumn - 1].IsShip;
                    }
                    if (rColumn > 0)
                    {
                        checkResult = checkResult & !cells[rRow + modifierRow, rColumn + modifierColumn - 1].IsShip;
                    }
                    if (rColumn > 0 & rRow > 0)
                    {
                        checkResult = checkResult & !cells[rRow + modifierRow - 1, rColumn + modifierColumn - 1].IsShip;
                    }
                }
            }
            for (int i = 0; i < ship.DeckCount; i++)
            {
                if (rdirection == 0)
                {
                    modifierColumn = i;
                }
                else
                {
                    modifierRow = i;
                }
                if (rRow > 0)
                {
                    ship.AddNearShip(cells[rRow + modifierRow - 1, rColumn + modifierColumn]);
                }
                if (rColumn + i < column & rRow > 0)
                {
                    ship.AddNearShip(cells[rRow + modifierRow - 1, rColumn + modifierColumn + 1]);
                }
                if (rColumn < column)
                {
                    ship.AddNearShip(cells[rRow + modifierRow, rColumn + modifierColumn + 1]);
                }
                if (rColumn < column & rRow < row)
                {
                    ship.AddNearShip(cells[rRow + modifierRow + 1, rColumn + modifierColumn + 1]);
                }
                if (rRow < row)
                {
                    ship.AddNearShip(cells[rRow + modifierRow + 1, rColumn + modifierColumn]);
                }
                if (rRow < row & rColumn > 0)
                {
                    ship.AddNearShip(cells[rRow + modifierRow + 1, rColumn + modifierColumn - 1]);
                }
                if (rColumn > 0)
                {
                    ship.AddNearShip(cells[rRow + modifierRow, rColumn + modifierColumn - 1]);
                }
                if (rColumn > 0 & rRow > 0)
                {
                    ship.AddNearShip(cells[rRow + modifierRow - 1, rColumn + modifierColumn - 1]);
                }

                ship.AddShipPlace(cells[rRow + modifierRow, rColumn + modifierColumn]);
                cells[rRow + modifierRow, rColumn + modifierColumn].SetShip(ship);

            }

            for (int i = 0; i < ship.NearShip.Count; i++)
            {
                ship.NearShip[i].IsNearShip = true;
            }
            for (int i = 0; i < ship.ShipPlace.Count; i++)
            {
                ship.ShipPlace[i].IsShip = true;
            }

        }

    }
}
