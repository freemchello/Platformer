using System;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer
{
    public class InteractiveObjectView : LevelObjectView
    {
        public Action<BulletView> TakeDamage { get; set; }
        public Action<FinishView> GameOver { get; set; }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.TryGetComponent(out BulletView contact))
            {
                TakeDamage?.Invoke(contact);
            }
            if (collision.CompareTag("Finish"))
            {
                Debug.Log("YOU WIN, CONGRATULATIONS");
                Main.GameOver();
            }
        }
    }
}