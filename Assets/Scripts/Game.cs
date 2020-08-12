using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace genotroid {
    public class Game : MonoBehaviour
    {
        [SerializeField] private GameObject _gameMenu;
        [SerializeField] private Player _player;
        [SerializeField] private GameObject _enemySpawner;
        [SerializeField] private GameObject _playerControl;

        private void OnEnable()
        {
            _player.PlayerDied += GameOver;
        }

        private void OnDisable()
        {
            _player.PlayerDied -= GameOver;
        }

        public void GameOver()
        {
            _enemySpawner.SetActive(false);
            _playerControl.SetActive(false);
            _gameMenu.SetActive(true); 
        }

        public void ResetGame()
        {
            _enemySpawner.SetActive(true);
            _playerControl.SetActive(true);
            _gameMenu.SetActive(false);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}
