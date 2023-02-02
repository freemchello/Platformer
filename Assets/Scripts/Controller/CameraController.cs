using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class CameraController
    {
        private LevelObjectView _player;
        private Transform _playerT;
        private Transform _cameraT;

        private float _cameraSpeed = 1.2f;

        private float X;
        private float Y;

        private float offsetX;
        private float offsetY;

        private float _xAxisInput;
        private float _yAxisInput;

        private float _tresholtd;


        public CameraController(LevelObjectView player, Transform mainCamera)
        {
            _player = player;
            _playerT = player.transform;
            _cameraT = mainCamera;
            _tresholtd = 0.2f;
            
        }
        public void Update()
        {
            _xAxisInput = Input.GetAxis("Horizontal");
            _yAxisInput = _player._rb2D.velocity.y;

            X = _playerT.position.x;
            Y = _playerT.position.y;

            if(_xAxisInput>_tresholtd)
            {
                offsetX = 4;
            }
            else if(_xAxisInput<-_tresholtd)
            {
                offsetX = -4;
            }
            else
            {
                offsetX = 0;
            }

            if (_xAxisInput > _tresholtd)
            {
                offsetY = 4;
            }
            else if (_xAxisInput < -_tresholtd)
            {
                offsetY = -4;
            }
            else
            {
                offsetY = 0;
            }

            _cameraT.position = Vector3.Lerp(_cameraT.position,
                new Vector3(X + offsetX, Y + offsetY, _cameraT.position.z),
                Time.deltaTime * _cameraSpeed);
        }
    }
}