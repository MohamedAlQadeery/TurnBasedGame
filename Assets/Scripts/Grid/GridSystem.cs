using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBased.Grid
{
    public class GridSystem
    {
        private int width, height;
        private float cellSize;
        private GridObject[,] gridObjects;

        public GridSystem(int width, int height,float cellSize)
        {
            this.width = width;
            this.height = height;
            this.cellSize = cellSize;

            gridObjects = new GridObject[width, height];
            FillGridArray();

        }


        public void FillGridArray()
        {
            for (int x = 0; x < width; x++)
            {
                for (int z = 0; z < height; z++)
                {
                    gridObjects[x, z] = new GridObject(this, new GridPostion(x, z));
                }
            }
        }

        public Vector3 GetWorldPostion(GridPostion gridPostion)
        {
            return new Vector3(gridPostion.x, 0, gridPostion.z) * cellSize;
        }


        public GridPostion GetGridPostion(Vector3 worldPostion)
        {
            int x = Mathf.RoundToInt(worldPostion.x/cellSize);
            int z = Mathf.RoundToInt(worldPostion.z/cellSize);
            return new GridPostion(x,z);
        }


        public void CreateDebugObjects(Transform debugObjectPrefab)
        {
            for (int x = 0; x < width; x++)
            {
                for (int z = 0; z < height; z++)
                {
                    var gridPostion = new GridPostion(x, z);
                  var debugObject=  GameObject.Instantiate(debugObjectPrefab, GetWorldPostion(gridPostion), Quaternion.identity);
                    debugObject.GetComponent<GridDebugObject>().SetGridObject(GetGridObject(gridPostion));
                }
            }
        }

        public GridObject GetGridObject(GridPostion gridPostion)
        {
            return gridObjects[gridPostion.x, gridPostion.z];
        }
    }

}