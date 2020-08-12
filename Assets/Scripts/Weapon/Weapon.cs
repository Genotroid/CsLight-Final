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
        [SerializeField] private float ShootDelay = 2f;
        [SerializeField] private float BulletDelay = 0.1f;
        [SerializeField] private Transform ShootPoint;
        [SerializeField] private Bullet Bullet;
        [SerializeField] private int _bulletsInClip;
        [SerializeField] private int _bulletsCountInShot = 3;
        [SerializeField] private AudioSource _shootSound;
        [SerializeField] private AudioSource _reloadSound;

        private float LastBulletTime = 0f;
        private float LastShootTime = 0f;
        private float CurrentReloadTime = float.MaxValue;
        private bool IsShooting = false;
        private bool IsReloading = false;
        private int ShootedBulletCount = 0;
        private float HalfShootAngle;

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
            HalfShootAngle = _shootAngle / 2;
        }

        private void Update()
        {
            if (IsReloading)
            {
                if (CurrentReloadTime < _reloadTime)
                {
                    CurrentReloadTime += Time.deltaTime;
                    IsShooting = false;
                }
                else
                {
                    Reloaded?.Invoke();
                    IsReloading = false;
                }   
            }

            if(BulletsInClip <= 0)
            {
                Reload();
            }

            LastShootTime += Time.deltaTime;
            LastBulletTime += Time.deltaTime;
            if (IsShooting && !IsReloading)
            {
                if (LastShootTime >= ShootDelay)
                {
                    ShootedBulletCount = 0;
                    LastShootTime = 0;
                }
                if (ShootedBulletCount < _bulletsCountInShot)
                {
                    if (LastBulletTime >= BulletDelay)
                    {
                        LastBulletTime = 0;
                        _shootSound.Play();
                        Instantiate(Bullet, ShootPoint.position, Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + Random.Range(-HalfShootAngle, HalfShootAngle)));
                        _bulletsInClip--;
                        Shooted?.Invoke();
                        ShootedBulletCount++;
                        
                    }
                }
                else
                    IsShooting = false;
            }
        }

        public void Shoot()
        {
            IsShooting = true;
        }

        public void Reload()
        {
            _reloadSound.Play();
            CurrentReloadTime = 0f;
            _bulletsInClip = _clipSize;
            IsReloading = true;
        }
    }
}
