using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace genotroid
{
    public class EnviromentSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _pool;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] float _spawnDelayTime;
        [SerializeField] float _randomTimeRange;

        private float _lastSpawnTime = 0;
        private float _randomTime;
        private List<GameObject> _enviroments = new List<GameObject>();

        private void Start()
        {
            for(int  i=0; i < _pool.transform.childCount; i++)
            {
                _enviroments.Add(_pool.transform.GetChild(i).gameObject);
            }
            _randomTime = GetRandomTime(_randomTimeRange);
        }

        private void Update()
        {
            _lastSpawnTime += Time.deltaTime;
            if(_lastSpawnTime >= _spawnDelayTime + _randomTime)
            {
                int randomEnviroment = Random.Range(0, _enviroments.Count - 1);
                if (TryGetObject(out GameObject obj, randomEnviroment))
                {
                    _randomTime = GetRandomTime(_randomTimeRange);
                    _lastSpawnTime = 0;
                    obj.SetActive(true);
                }
            }
        }

        private bool TryGetObject(out GameObject result, int index)
        {
            result = _enviroments[index];

            return result.active != true;
        }

        private float GetRandomTime(float randomTimeRange)
        {
            return Random.Range(-randomTimeRange, randomTimeRange);
        }
    }
}
