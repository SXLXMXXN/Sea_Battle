using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea_Battle
{
    public class CellsController
    {
        public Cell[,] Cells { get; private set; }
        
        
        public void FillCells(int row, int column)
        {   
            
            Cells = new Cell[row, column];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    Cells[i, j] = new Cell(i, j);
                }
            }
        }
    }
}
