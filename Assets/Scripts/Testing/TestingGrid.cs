using System.Collections;
using System.Collections.Generic;
using TurnBased.Grid;
using TurnBased.Unit;
using UnityEngine;

public class TestingGrid : MonoBehaviour
{
    GridSystem gs;
    [SerializeField] Transform debugObjectPrefab;
    private void Start()
    {
        gs =   new GridSystem(10, 10,2f);
        gs.CreateDebugObjects(debugObjectPrefab);

    }


    private void Update()
    {
       // Debug.Log(gs.GetGridPostion(MouseWorld.GetMousePostion()));
    }
}
