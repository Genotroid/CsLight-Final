using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace genotroid
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private int _health = 12;
        [SerializeField] private List<Weapon> _weapons;
        [SerializeField] private int _money;

        private Weapon _currentWeapon;
        private int _currentWeaponNumber = 0;
        private int _currentHealth;

        public event UnityAction<int, int> HealthChanged;
        public event UnityAction<int> MoneyChanged;
        public event UnityAction<Weapon> WeaponChanged;
        public event UnityAction PlayerDied;

        private void Awake()
        {
            _currentWeapon = _weapons[_currentWeaponNumber];
            ChangeWeapon(_weapons[_currentWeaponNumber]);
            _currentHealth = _health;
        }

        private void Die()
        {
            PlayerDied?.Invoke();
        }

        private void ChangeWeapon(Weapon weapon)
        {
            _currentWeapon.gameObject.SetActive(false);
            _currentWeapon = weapon;
            WeaponChanged?.Invoke(weapon);
            _currentWeapon.gameObject.SetActive(true);

        }

        public void Shoot()
        {
            _currentWeapon.Shoot();
        }

        public void Reload()
        {
            _currentWeapon.Reload();
        }

        public void ApplyDamage(int damage)
        {
            _currentHealth -= damage;
            HealthChanged?.Invoke(_currentHealth, _health);

            if (_currentHealth <= 0)
                Die();
        }

        public void NextWeapon()
        {
            if (_currentWeaponNumber == (_weapons.Count - 1))
                _currentWeaponNumber = 0;
            else
                _currentWeaponNumber++;
            ChangeWeapon(_weapons[_currentWeaponNumber]);
        }

        public void PrevWeapon()
        {
            if (_currentWeaponNumber == 0)
                _currentWeaponNumber = _weapons.Count - 1;
            else
                _currentWeaponNumber--;
            ChangeWeapon(_weapons[_currentWeaponNumber]);
        }

        public Weapon GetCurrentWeapon()
        {
            return _currentWeapon;
        }
    }
}
