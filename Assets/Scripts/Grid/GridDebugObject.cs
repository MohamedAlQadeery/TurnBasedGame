using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace TurnBased.Grid
{
    public class GridDebugObject : MonoBehaviour
    {
        private GridObject gridObject;
        [SerializeField] TMP_Text gridText;

        public void SetGridObject(GridObject gridObject)
        {
            this.gridObject = gridObject;
            gridText.text = gridObject.ToString();
          
        }


       
    }

}