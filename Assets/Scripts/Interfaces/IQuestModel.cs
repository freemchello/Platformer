using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public interface IQuestModel
    {
        bool TryCompleted(GameObject actor);
    }
}