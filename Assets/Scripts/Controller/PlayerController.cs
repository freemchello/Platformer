using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class PlayerController
    {
        private float _xAxisinput;
        private bool _isJump;

        private bool _isMoving;

        private float _walkSpeed = 3f;
        private float _animationSpeed = 7f;
        private float _movingTrashold = 0.1f;

        private Vector3 _leftScale = new Vector3(-1, 1, 1);
        private Vector3 _rightScale = new Vector3(1, 1, 1);

        private float _jumpForce = 6f;
        private float _jumpTrashold = 1f;
        private float g = -9.8f;
        private float _groundLevel = -3.5f;
        private float _yVelosity;

        private SpriteAnimatorController _playerAnimator;
        private AnimationConfig _config;
        private LevelObjectView _playerView;
        private Transform _playerT;

        public PlayerController(LevelObjectView player)
        {
            _config = Resources.Load<AnimationConfig>("SpriteAnimCfg");
            _playerAnimator = new SpriteAnimatorController(_config);
            _playerAnimator.StartAnimation(player._renderer, AnimState.Run, true, _animationSpeed);
            _playerView = player;
            _playerT = player._transform;
        }
        private void MoveToward()
        {
            _playerT.position += Vector3.right * (Time.deltaTime * _walkSpeed * (_xAxisinput < 0 ? -1 : 1));
            _playerT.localScale = _xAxisinput < 0 ? _leftScale : _rightScale;
        }

        public bool isGrounded()
        {
            return _playerT.position.y <= _groundLevel && _yVelosity <= 0;
        }
        public void Update()
        {
            _playerAnimator.Update();
            _xAxisinput = Input.GetAxis("Horizontal");
            _isJump = Input.GetAxis("Vertical")>0;
            _isMoving = Mathf.Abs(_xAxisinput) > _movingTrashold;

            if(_isMoving)
            {
                MoveToward();
            }

            if(isGrounded())
            {
                _playerAnimator.StartAnimation(_playerView._renderer, _isMoving ? AnimState.Run : AnimState.Idle, true, _animationSpeed);

                if(_isJump&&_yVelosity<=0)
                {
                    _yVelosity = _jumpForce;
                }
                else if(_yVelosity<0)
                {
                    _yVelosity = 0;
                    _playerT.position = new Vector3(_playerT.position.x, _groundLevel, _playerT.position.z);
                }
            }
            else
            {
                if(Mathf.Abs(_yVelosity)>_jumpTrashold)
                {
                    _playerAnimator.StartAnimation(_playerView._renderer, AnimState.Jump, true, _animationSpeed);
                    
                }
                _yVelosity += g * Time.deltaTime;
                _playerT.position += Vector3.up * (Time.deltaTime * _yVelosity);
            }
        }
    }
}