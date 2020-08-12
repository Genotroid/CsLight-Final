using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace genotroid
{
    public class BulletInClip : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private Text _clipSize;
        [SerializeField] private Text _bulletsInClip;

        private Weapon _currentWeapon;

        private void OnEnable()
        {    
            _player.WeaponChanged += WeaponChange;
            _currentWeapon = _player.GetCurrentWeapon();
            _currentWeapon.Shooted += Shoot;
            _currentWeapon.Reloaded += EndReload;
            FillLabels(_currentWeapon);
        }

        private void OnDisable()
        {
            _player.WeaponChanged -= WeaponChange;
            _currentWeapon.Shooted -= Shoot;
            _currentWeapon.Reloaded -= EndReload;
        }

        private void WeaponChange(Weapon weapon)
        {
            _currentWeapon.Shooted -= Shoot;
            _currentWeapon.Reloaded -= EndReload;
            _currentWeapon = weapon;
            _currentWeapon.Shooted += Shoot;
            _currentWeapon.Reloaded += EndReload;
            FillLabels(_currentWeapon);
        }

        private void Shoot()
        {
            _bulletsInClip.text = _currentWeapon.BulletsInClip.ToString();
        }

        private void EndReload()
        {
            FillLabels(_currentWeapon);
        }
         
        private void  FillLabels(Weapon weapon)
        {
            _clipSize.text = weapon.ClipSize.ToString();
            _bulletsInClip.text = weapon.BulletsInClip.ToString();
        }
    }
}
