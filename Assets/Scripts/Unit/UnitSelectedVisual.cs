using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBased.Unit
{
    public class UnitSelectedVisual : MonoBehaviour
    {
        [SerializeField] Unit unit;
        private MeshRenderer meshRenderer;

        private void Awake()
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }


        // Start is called before the first frame update
        void Start()
        {
            UnitActionSystem.Instance.OnUnitSelectedChanged += UnitActionSystem_OnUnitSelectedChanged;
            UpdateVisual();
        }

        private void UnitActionSystem_OnUnitSelectedChanged(object sender, EventArgs e)
        {
            UpdateVisual();
        }

        private void UpdateVisual()
        {
            if (UnitActionSystem.Instance.GetSelectedUnit() == unit)
            {
                meshRenderer.enabled = true;
            }
            else
            {
                meshRenderer.enabled = false;
            }
        }



    }

}