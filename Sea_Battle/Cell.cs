using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Sea_Battle
{
    public class Cell
    {
        public bool IsShip = false;
        public bool IsNearShip = false;
        public bool IsKnocked = false;
        public bool IsSink = false;
        public bool IsMiss = false;
        public bool IsClear => !IsShip;
        public int Row;
        public int Column;
        public Ship Ship { get; private set; }
        public CellButton CellButton { get; private set; }
        public static SolidColorBrush ShipColor = Brushes.White;
        public static SolidColorBrush NearColor = Brushes.White;
        public static SolidColorBrush ClearColor = Brushes.White;
        public static SolidColorBrush KnockedColor = Brushes.Red;
        public static SolidColorBrush SinkColor = Brushes.Black;
        public static SolidColorBrush MissColor = Brushes.Blue;
        public SolidColorBrush Color
        {
            get
            {
                if (IsShip) { return ShipColor; }
                else if (IsKnocked) { return KnockedColor; }
                else if (IsSink) { return SinkColor; }
                else if (IsMiss) { return MissColor; }
                else if (IsNearShip) { return NearColor; }
                
                else { return ClearColor; }
            }
        }
        public Cell (int row, int column) 
        { 
            Row = row;
            Column = column;
        }

        public void SetShip(Ship ship)
        {
            Ship = ship;
        }

        public void SetCellButton(CellButton cellButton)
        {
            CellButton = cellButton;
        }
    }
}
