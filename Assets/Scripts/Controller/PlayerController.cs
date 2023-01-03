using System;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer
{
    public class PlayerController
    {
        private float _xAxisinput;
        private bool _isJump;

        private bool _isMoving;

        private int _health = 100;

        private float _walkSpeed = 170f;
        private float _animationSpeed = 7f;
        private float _movingTrashold = 0.1f;

        private Vector3 _leftScale = new Vector3(-1, 1, 1);
        private Vector3 _rightScale = new Vector3(1, 1, 1);

        private float _jumpForce = 11f;
        private float _jumpTrashold = 1f;
        private float _yVelocity = 0;
        private float _xVelocity = 0;

        private SpriteAnimatorController _playerAnimator;
        private ContactPooler _contactPooler;
        private AnimationConfig _config;
        private LevelObjectView _playerView;
        private Transform _playerT;
        private Rigidbody2D _rb;

        public PlayerController(InteractiveObjectView player)
        {
            _config = Resources.Load<AnimationConfig>("SpriteAnimCfg");
            _playerAnimator = new SpriteAnimatorController(_config);
            _playerAnimator.StartAnimation(player._renderer, AnimState.Run, true, _animationSpeed);
            
            _playerView = player;
            _playerT = player._transform;
            _rb = player._rb2D;
            _contactPooler = new ContactPooler(_playerView._collider2D);

            player.TakeDamage += TakeBullet;
        }
        private void MoveToward()
        {
            _xVelocity = Time.fixedDeltaTime * _walkSpeed * (_xAxisinput < 0 ? -1 : 1);
            _rb.velocity = new Vector2(_xVelocity, _yVelocity);
            _playerT.localScale = _xAxisinput < 0 ? _leftScale : _rightScale;
        }
        private void TakeBullet(BulletView bullet)
        {
            _health -= bullet.DamagePoint;
        }
        public void Update()
        {
            if(_health <= 0)
            {
                _health = 0;
                _playerView._renderer.enabled = false;
            }
            _playerAnimator.Update();
            _contactPooler.Update();
            _xAxisinput = Input.GetAxis("Horizontal");
            _isJump = Input.GetAxis("Vertical")>0;
            _yVelocity = _rb.velocity.y;
            _isMoving = Mathf.Abs(_xAxisinput) > _movingTrashold;
            _playerAnimator.StartAnimation(_playerView._renderer, _isMoving ? AnimState.Run : AnimState.Idle, true, _animationSpeed);

            if (_isMoving)
            {
                MoveToward();
            }
            else
            {
                _xVelocity = 0;
                _rb.velocity = new Vector2(_xVelocity, _rb.velocity.y);
            }

            if(_contactPooler.IsGrounded)
            {
                if(_isJump&&_yVelocity<=_jumpTrashold)
                {
                    _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
                }    
            }
            else
            {
                if(Mathf.Abs(_yVelocity)>_jumpTrashold)
                {
                    _playerAnimator.StartAnimation(_playerView._renderer, AnimState.Jump, true, _animationSpeed);
                    
                }
            }
        }
    }
}