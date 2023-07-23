using UnityEngine;

namespace Platformer
{
    public class QuestObjectView : LevelObjectView
    {
        public Color _completedColor;
        public Color _defaultColor;
        public int _id;

        private void Awake()
        {
            _defaultColor = _renderer.color;
        }

        public void ProcessComplete()
        {
            _renderer.color = _completedColor;
        }

        public void ProcessActivate()
        {
            _renderer.color = _defaultColor;
        }
    }
}