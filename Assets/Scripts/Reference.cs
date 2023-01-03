using UnityEngine;

namespace Platformer
{
    public class Reference
    {
        private GameObject _bonusLabel;
        private GameObject _health;
        private GameObject _restartButton;
        private Canvas _canvas;

        private Camera _mainCamera;

        public GameObject BonusLabel
        {
            get
            {
                if (_bonusLabel == null)
                {
                    GameObject bonusPrefab = Resources.Load<GameObject>("UI/Bonus");
                    _bonusLabel = Object.Instantiate(bonusPrefab, Canvas.transform);
                }
                return _bonusLabel;
            }
            set
            { _bonusLabel = value; }
        }

        public GameObject RestartButton
        {
            get
            {
                if (_restartButton == null)
                {
                    GameObject restart = Resources.Load<GameObject>("UI/Restart");
                    _restartButton = Object.Instantiate(restart, Canvas.transform);
                }
                return _restartButton;
            }
            set { _restartButton = value; }
        }

        public GameObject Health
        {
            get
            {
                if (_health == null)
                {
                    GameObject health = Resources.Load<GameObject>("UI/Health");
                    _health = Object.Instantiate(health, Canvas.transform);
                }
                return _health;
            }
            set { _health = value; }
        }
        public Canvas Canvas
        {
            get
            {
                if (_canvas == null)
                {
                    _canvas = Object.FindObjectOfType<Canvas>();
                }
                return _canvas;
            }
            set { _canvas = value; }
        }
        public Camera MainCamera
        {
            get
            {
                if (!_mainCamera)
                {
                    _mainCamera = Camera.main;
                }
                return _mainCamera;
            }
            set { _mainCamera = value; }
        }
    }
}
