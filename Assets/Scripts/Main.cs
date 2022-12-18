using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private LevelObjectView _playerView;
        private PlayerController _playerController;
        
        private ParalaxController _paralaxController;
        public Transform _camera;
        public Transform _back;


        private void Awake()
        {
            _playerController = new PlayerController(_playerView);
            _paralaxController = new ParalaxController(_camera, _back);
        }
        void Update()
        {
            _playerController.Update();
            _paralaxController.Update();
        }
    }
}