using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace genotroid
{
    [RequireComponent(typeof(Animator))]

    public class AttackState : State
    {
        [SerializeField] private int _damage;

        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            Attack(Target);
        }

        private void Attack(Player target)
        {
            target.ApplyDamage(_damage);
            _animator.Play("Dead");
            GetComponent<CapsuleCollider2D>().enabled = false;
            enabled = false;
        }
    }
}
