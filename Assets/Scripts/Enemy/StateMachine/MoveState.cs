using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace genotroid
{
    public class MoveState : State
    {
        [SerializeField] private float _speed;

        private void Update()
        {
            transform.Translate(transform.right * _speed * Time.deltaTime, Space.World);
        }
    }
}
