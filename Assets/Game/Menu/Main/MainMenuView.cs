using Reflex.Attributes;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Menu.Main
{
    public class MainMenuView : MonoBehaviour, IMainMenuView
    {
        [Header("State controls")] [SerializeField]
        private Button _btnGenerate;

        [SerializeField] private Button _btnStart;
        [Inject] private MainMenuPresenter _presenter;

        private void Awake()
        {
            _btnGenerate.onClick.RemoveAllListeners();
            _btnGenerate.onClick.AddListener(OnGenerateClick);

            _btnStart.onClick.RemoveAllListeners();
            _btnStart.onClick.AddListener(OnStartClick);

            _presenter.Mount(this);
        }

        private void OnStartClick()
        {
            _presenter?.StartGame();
        }

        private void OnGenerateClick()
        {
            _presenter?.RegenerateCharacter();
        }

        public void OnDestroy()
        {
            _presenter.Unmount();
        }
    }
}