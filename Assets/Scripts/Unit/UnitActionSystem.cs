using System;
using System.Collections;
using System.Collections.Generic;
using TurnBased.Unit;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{
    public static UnitActionSystem Instance { get; private set; }
    public event EventHandler OnUnitSelectedChanged;
    [SerializeField] private Unit selectedUnit;
    [SerializeField] private LayerMask unitLayer;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.Log($"There is more than Unit Action system {transform} - {Instance} ");
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
   

    // Update is called once per frame
    void Update()
    {
     

        if (Input.GetMouseButtonDown(0))
        {
            if (TryHandleSelectedUnit()) return;
            selectedUnit.Move(MouseWorld.GetMousePostion());
        }
    }


    public bool TryHandleSelectedUnit()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, unitLayer))
        {
            if(hit.transform.TryGetComponent<Unit>(out Unit unit))
            {
                SetSelectedUnit(unit);
                return true;
            }
        }

        return false;
    }

    public void SetSelectedUnit(Unit unit)
    {
        selectedUnit = unit;
        OnUnitSelectedChanged?.Invoke(this, EventArgs.Empty);

    }


    public Unit GetSelectedUnit()
    {
        return selectedUnit;
    }


}
