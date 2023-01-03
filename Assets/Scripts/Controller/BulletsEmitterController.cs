using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class BulletsEmitterController
    {
        private const float _delay = 4;
        private float _startSpeed = 0.003f;

        private List<BulletController> _bullets = new List<BulletController>();
        private Transform _transform;

        private int _index;
        private float _timeTillNextBullet;
        public BulletsEmitterController(List<BulletView> bulletViews, Transform Emmitertransform)
        {
            _transform = Emmitertransform;

            foreach (BulletView bulletView in bulletViews)
            {
                _bullets.Add(new BulletController(bulletView));
            }
        }
        public void Update()
        {
            if (_timeTillNextBullet > 0)
            {
                _bullets[_index].Active(false);
                _timeTillNextBullet -= Time.deltaTime;
            }
            else
            {
                _timeTillNextBullet = _delay;
                _bullets[_index].Throw(_transform.position, -_transform.up *
                _startSpeed);
                _index++;
                if (_index >= _bullets.Count) 
                    _index = 0;
            }
            //_bullets.ForEach(b => b.Update());
        }
    }
}