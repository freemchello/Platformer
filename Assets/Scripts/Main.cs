using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Platformer
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private InteractiveObjectView _playerView;
        [SerializeField] private CannonView _cannonView;
        [SerializeField] private CameraView _cameraView;

        private Reference _reference;
        private BonusView _bonusView;
        private int _bonusCount;

        private PlayerController _playerController;
        private CannonController _canonController;
        private CameraController _cameraController;
        private BulletsEmitterController _bulletsEmitterController;

        [SerializeField] private Button _restartButton;
        private static Button _restartGame;

        //private ParalaxController _paralaxController;
        //public Transform _camera;
        //public Transform _back;

        private void Awake()
        {
            Time.timeScale = 1f;

            _reference = new Reference();
            //_bonusView = new BonusView(_reference.BonusLabel);

            _restartGame = _restartButton;
            _restartGame.onClick.AddListener(RestartGame);
            _restartGame.gameObject.SetActive(false);


            _playerController = new PlayerController(_playerView);
            _canonController = new CannonController(_cannonView._muzzleTransform, _playerView._transform);
            _cameraController = new CameraController(_playerView.transform, _cameraView.transform);
            _bulletsEmitterController = new BulletsEmitterController(_cannonView._bulletsView, _cannonView._emitterTransform);

            //_paralaxController = new ParalaxController(_camera, _back);
        }
        void Update()
        {
            _playerController.Update();
            _canonController.Update();
            _cameraController.Update();
            _bulletsEmitterController.Update();

            //_paralaxController.Update();
        }
        private void RestartGame()
        {
            SceneManager.LoadScene(0);
        }
        public static void GameOver()
        {
            _restartGame.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
        private void AddBonus(int value)
        {
            _bonusCount += value;
            _bonusView.Display(_bonusCount);
        }
    }
}