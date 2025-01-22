using Game.Core;
using Game.DataEntities;
using Reflex.Attributes;
using UnityEngine.SceneManagement;

namespace Game.Menu.Main
{
    public class MainMenuPresenter : GenericPresenter<IMainMenuView>
    {
        private const string GameSceneName = "Game";

        [Inject] private GameState _gameState;

        public void RegenerateCharacter()
        {
            _gameState.SetRandomCharacter();
        }

        public void StartGame()
        {
            SceneManager.LoadSceneAsync(GameSceneName, LoadSceneMode.Single);
        }
    }
}