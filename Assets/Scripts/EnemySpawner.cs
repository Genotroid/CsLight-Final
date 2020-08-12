using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace genotroid
{
    public class EnemySpawner : ObjectPool
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Player _target;
        [SerializeField] float _spawnDelayTime;

        private float _lastSpawnTime = 0;

        private void OnDisable()
        {
            ResetPool();
        }

        private void Start()
        {
            Init(_prefab, _target);
        }

        private void Update()
        {
            _lastSpawnTime += Time.deltaTime;

            if(_lastSpawnTime >= _spawnDelayTime)
            {
                if(TryGetObject(out GameObject obj))
                {
                    _lastSpawnTime = 0;
                    SetObject(obj, _spawnPoint.position);    
                }
            }
        }

        private void SetObject(GameObject obj, Vector3 spawnPoint)
        {
            obj.transform.position = spawnPoint;
            obj.SetActive(true);
        }
    }
}
