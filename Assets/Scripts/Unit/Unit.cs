using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBased.Unit
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] float moveSpeed = 4;
        [SerializeField] Animator unitAnimator;
        private float stoppingDistance = .1f;
        private float rotateSpeed = 10f;
        private Vector3 targetPostion;


        private void Awake()
        {
            targetPostion = transform.position;
        }
        void Update()
        {
            if (Vector3.Distance(targetPostion, transform.position) > stoppingDistance)
            {

                var moveDirection = (targetPostion - transform.position).normalized;
                transform.forward = Vector3.Lerp(transform.forward, moveDirection, rotateSpeed * Time.deltaTime);
                transform.position += moveDirection * Time.deltaTime * moveSpeed;
                unitAnimator.SetBool("IsWalking", true);
            }
            else
            {
                unitAnimator.SetBool("IsWalking", false);

            }

           
        }

        public void Move(Vector3 targetPostion)
        {
            this.targetPostion = targetPostion;
        }
    }
}
