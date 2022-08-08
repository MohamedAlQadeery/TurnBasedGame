using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBased.Unit
{
    public class MouseWorld : MonoBehaviour
    {
        private static MouseWorld Instance;
        [SerializeField] private LayerMask mousePlaneLayerMask;
        private void Awake()
        {
            Instance = this;
        }

     

        public static Vector3 GetMousePostion()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, Instance.mousePlaneLayerMask);
            return raycastHit.point;
        }


      
    }
}
