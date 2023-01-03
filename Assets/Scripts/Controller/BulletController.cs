using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class BulletController
    {
        private Vector3 _velocity;
        private BulletView _view;

        private float _radius = 0.3f;
        private float _groundLevel = 0;
        private float _g = -10;

        public BulletController(BulletView view)
        {
            _view = view;

            Active(false);

            //_view.SetVisible(false);
        }

        public void Active(bool val)
        {
            _view.gameObject.SetActive(val);
        }

        //public void Update()
        //{
        //    if (IsGrounded())
        //    {
        //        //SetVelocity(_velocity.Change(y: -_velocity.y));
        //        //_view.transform.position = _view.transform.position.Change(y:
        //        //_groundLevel + _radius);
        //    }
        //    else
        //    {
        //        SetVelocity(_velocity + Vector3.up * _g * Time.deltaTime);
        //        _view.transform.position += _velocity * Time.deltaTime;
        //    }
        //}
        public void Throw(Vector3 position, Vector3 velocity)
        {
            _view.transform.position = position;
            SetVelocity(velocity);
            _view._rb2D.velocity = Vector2.zero; //обнуление тела
            _view._rb2D.angularVelocity = 0; //угловой vetocity
            Active(true);

            _view._rb2D.AddForce(velocity, ForceMode2D.Impulse);

        }
        private void SetVelocity(Vector3 velocity)
        {
            _velocity = velocity;
            var angle = Vector3.Angle(Vector3.left, _velocity);
            Vector3 axis = Vector3.Cross(Vector3.left, _velocity);
            _view._transform.rotation = Quaternion.AngleAxis(angle, axis);
        }

        //private bool IsGrounded()
        //{
        //    return _view.transform.position.y <= _groundLevel + _radius +
        //    float.Epsilon && _velocity.y <= 0;
        //}
    }
}