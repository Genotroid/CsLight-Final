using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace genotroid
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private GameObject _container;
        [SerializeField] protected int _count;

        private List<GameObject> _pool = new List<GameObject>();

        protected void ResetPool()
        {
            foreach (GameObject poolObject in _pool)
            {
                poolObject.SetActive(false);
            }
        }

        protected void Init(GameObject prefab, Player target = null)
        {
            for (int i = 0; i < _count; i++)
            {
                GameObject spawned = Instantiate(prefab, _container.transform);
                spawned.SetActive(false);
                if (spawned.TryGetComponent<Enemy>(out Enemy enemy) && target != null)
                {
                    enemy.Init(target);
                }
                _pool.Add(spawned);
            }
        }

        protected bool TryGetObject(out GameObject result)
        {
            result = _pool.First(p => p.activeSelf == false);
            Debug.Log(result);
            return result != null;
        }
    }
}
