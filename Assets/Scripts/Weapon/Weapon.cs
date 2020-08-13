using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace genotroid
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private float _shootAngle = 30;
        [SerializeField] private float _rayRange = 20;
        [SerializeField] private float _reloadTime;
        [SerializeField] private int _clipSize;
        [SerializeField] private float _shootDelay = 2f;
        [SerializeField] private float _bulletDelay = 0.1f;
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private Bullet _bullet;
        [SerializeField] private int _bulletsInClip;
        [SerializeField] private int _bulletsCountInShot = 3;
        [SerializeField] private AudioSource _shootSound;
        [SerializeField] private AudioSource _reloadSound;

        private float _lastBulletTime = 0f;
        private float _lastShootTime = 0f;
        private float _currentReloadTime = float.MaxValue;
        private bool _isShooting = false;
        private bool _isReloading = false;
        private int _shootedBulletCount = 0;
        private float _halfShootAngle;

        public float ShootAngle => _shootAngle;
        public float RayRange => _rayRange;
        public int ClipSize => _clipSize;
        public int BulletsInClip => _bulletsInClip;

        public event UnityAction Shooted;
        public event UnityAction Reloaded;

        private void Awake()
        {
            _bulletsInClip = _clipSize;
        }

        private void Start()
        {
            _halfShootAngle = _shootAngle / 2;
        }

        private void Update()
        {
            if (_isReloading)
            {
                if (_currentReloadTime < _reloadTime)
                {
                    _currentReloadTime += Time.deltaTime;
                    _isShooting = false;
                }
                else
                {
                    Reloaded?.Invoke();
                    _isReloading = false;
                }   
            }

            if(BulletsInClip <= 0)
            {
                Reload();
            }

            _lastShootTime += Time.deltaTime;
            _lastBulletTime += Time.deltaTime;
            if (_isShooting && !_isReloading)
            {
                if (_lastShootTime >= _shootDelay)
                {
                    _shootedBulletCount = 0;
                    _lastShootTime = 0;
                }
                if (_shootedBulletCount < _bulletsCountInShot)
                {
                    if (_lastBulletTime >= _bulletDelay)
                    {
                        _lastBulletTime = 0;
                        _shootSound.Play();
                        Instantiate(_bullet, _shootPoint.position, Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + Random.Range(-_halfShootAngle, _halfShootAngle)));
                        _bulletsInClip--;
                        Shooted?.Invoke();
                        _shootedBulletCount++;
                        
                    }
                }
                else
                    _isShooting = false;
            }
        }

        public void Shoot()
        {
            _isShooting = true;
        }

        public void Reload()
        {
            _reloadSound.Play();
            _currentReloadTime = 0f;
            _bulletsInClip = _clipSize;
            _isReloading = true;
        }
    }
}
