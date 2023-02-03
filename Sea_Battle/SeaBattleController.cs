using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea_Battle
{
    public class SeaBattleController
    {
        public CellsController CellsController { get; private set; }
        public ShipsController ShipsController { get; private set; }

        static Random random = new Random();
        public SeaBattleController ()
        {
            CellsController = new CellsController ();
            ShipsController = new ShipsController ();
        }

        public void Generate()
        {
            CellsController.FillCells(10,10);
            ShipsController.FillShips(CellsController);
        }

        
        

        


        
    }
}
