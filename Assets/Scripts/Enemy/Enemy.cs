using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace genotroid
{
    [RequireComponent(typeof(CapsuleCollider2D))]
    [RequireComponent(typeof(Animator))]

    public class Enemy : MonoBehaviour
    {
        [SerializeField] private int _health;
        [SerializeField] private Player _target;

        private Animator _animator;
        private int _currentHealth;

        public Player Target => _target;

        public event UnityAction<Enemy> Died;

        private void OnEnable()
        {
            GetComponent<CapsuleCollider2D>().enabled = true;
        }

        private void Start()
        {
            _currentHealth = _health;
            _animator = GetComponent<Animator>();
        }

        public void Die()
        {
            Died?.Invoke(this);
            _currentHealth = _health;
            gameObject.SetActive(false);
        }

        public void Init(Player target)
        {
            _target = target;
        }

        public void ApplyDamage(int damage)
        {
            _currentHealth -= damage;
            if (_currentHealth <= 0)
            {
                GetComponent<CapsuleCollider2D>().enabled = false;
                _animator.Play("Dead");
            }   
        }
    }
}
