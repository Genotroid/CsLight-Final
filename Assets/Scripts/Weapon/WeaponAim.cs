using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace genotroid
{
    public class WeaponAim : MonoBehaviour
    {
        [SerializeField] private RectTransform _aim;

        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            Vector3 screenAimPosition = _camera.ScreenToWorldPoint(_aim.transform.position);
            transform.LookAt(screenAimPosition);
            Quaternion normalRotation = transform.rotation;
            normalRotation.y = 0;
            normalRotation.x = 0;
            transform.rotation = normalRotation;
        }
    }
}
