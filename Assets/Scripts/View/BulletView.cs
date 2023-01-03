using UnityEngine;

namespace Platformer
{
    public class BulletView: LevelObjectView
{
        private int _damagePoint = 10;

        //[SerializeField]
        //private TrailRenderer _trail;
        //private SpriteRenderer _spriteRenderer;

        public int DamagePoint { get => _damagePoint; set => _damagePoint = value; }

        //public void SetVisible(bool visible)
        //{
        //    if (_trail) _trail.enabled = visible;
        //    if (_trail) _trail.Clear();
        //    _spriteRenderer.enabled = visible;
        //    //SpriteRenderer.enabled = visible;
        //}
    }
}