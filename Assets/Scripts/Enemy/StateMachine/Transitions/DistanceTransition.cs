using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace genotroid
{
    public class DistanceTransition : Transition
    {
        [SerializeField] private float _range;
        //[SerializeField] private float _rangeSpread;

        private void Start()
        {
            //_range += Random.Range(-_rangeSpread, _rangeSpread);
        }

        private void Update()
        {
            if (Vector2.Distance(transform.position, Target.transform.position) < _range)
            {
                NeedTransit = true;
            }
        }
    }
}