using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public enum QuestStoryType
    {
        Common,
        Resetteble
    }

    [CreateAssetMenu(fileName = "QuestStoryCfg", menuName = "Configs / QuestSystem / QuestStoryCfg", order = 1)]
    public class QuestStoryConfig : ScriptableObject
    {
        public QuestConfig[] questsConfig;
        public QuestStoryType type;
    }
}