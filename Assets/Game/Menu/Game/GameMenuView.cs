using Reflex.Attributes;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Menu.Game
{
    public class GameMenuView : MonoBehaviour, IGameMenuView
    {
        [SerializeField] private Button _btnBack;
        [Inject] private GameMenuPresenter _presenter;

        private void Awake()
        {
            _btnBack.onClick.RemoveAllListeners();
            _btnBack.onClick.AddListener(OnBackClick);

            _presenter.Mount(this);
        }

        private void OnBackClick()
        {
            _presenter.GoBack();
        }

        public void OnDestroy()
        {
            _presenter.Unmount();
        }
    }
}