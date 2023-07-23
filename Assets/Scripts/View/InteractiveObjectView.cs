using System;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer
{
    public class InteractiveObjectView : LevelObjectView
    {
        public Action<BulletView> TakeDamage { get; set; }
        public Action<FinishView> GameOver { get; set; }
        public Action<QuestObjectView> OnQuestComplete { get; set; }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.TryGetComponent(out LevelObjectView contactView))
            {
                if(contactView is QuestObjectView)
                {
                    OnQuestComplete?.Invoke((QuestObjectView)contactView);
                }
                if (contactView is BulletView)
                {
                    TakeDamage?.Invoke((BulletView)contactView);
                }
                
            }
            if (collision.CompareTag("Finish"))
            {
                Debug.Log("YOU WIN, CONGRATULATIONS");
                Main.GameOver();
            }
        }
    }
}