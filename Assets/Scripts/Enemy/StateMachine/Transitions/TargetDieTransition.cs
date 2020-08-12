using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace genotroid
{
    public class TargetDieTransition : Transition
    {
        private void Update()
        {
            if (Target == null)
            {
                NeedTransit = true;
            }
        }
    }
}
