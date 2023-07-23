using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class QuestCoinModel : IQuestModel
    {
        public bool TryCompleted(GameObject actor)
        {
            return actor.CompareTag("QuestCoin");
        }
    }
}