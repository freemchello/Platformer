using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class LevelObjectView : MonoBehaviour
    {
        public Transform _transform;
        public SpriteRenderer _renderer;
        public Collider2D _collider2D;
        public Rigidbody2D _rb2D;
    }
}