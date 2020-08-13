using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace genotroid
{
    [RequireComponent(typeof(Rigidbody2D))]

    public class Bullet : MonoBehaviour
    {
        [SerializeField] protected int Damage;
        [SerializeField] protected float Speed;

        protected Rigidbody2D Rigidbody;

        private void Start()
        {
            Rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            transform.Translate(transform.right * -1 * Speed * Time.deltaTime, Space.World);
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Enemy enemy))
            {
                enemy.ApplyDamage(Damage);
                Destroy(gameObject);
            }
        }


    }
}
