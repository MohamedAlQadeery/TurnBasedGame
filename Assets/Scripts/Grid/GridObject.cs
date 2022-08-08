using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBased.Grid
{
    public class GridObject
    {
        private GridSystem gridSystem;
        private GridPostion gridPostion;

        public GridObject(GridSystem gridSystem, GridPostion gridPostion)
        {
            this.gridSystem = gridSystem;
            this.gridPostion = gridPostion;
        }


    }

}