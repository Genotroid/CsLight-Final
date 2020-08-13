using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace genotroid
{
    [RequireComponent(typeof(LineRenderer))]

    public class ShootPoint : MonoBehaviour
    {
        [SerializeField] private Weapon _weapon;

        private float _totalFOV;
        private float _rayRange;
        private float _halfFOV;
        private LineRenderer _weaponLine;

        private void Start()
        {
            _totalFOV = _weapon.ShootAngle;
            _rayRange = _weapon.RayRange;
            _halfFOV = _totalFOV / 2.0f;

            _weaponLine = GetComponent<LineRenderer>();

            Vector3 upRayDirection = GetRayDirection(_halfFOV);
            Vector3 downRayDirection = GetRayDirection(-_halfFOV);

            Vector3[] positions = { Vector3.zero, downRayDirection * _rayRange, upRayDirection * _rayRange, Vector3.zero         };

            _weaponLine.SetPositions(positions);
        }

        private Vector3 GetRayDirection(float angle)
        {
            Quaternion rayRotation = Quaternion.AngleAxis(angle, new Vector3(-1, 0, -1));   
            return rayRotation * transform.right * -1;
            
        } 
    }
}
