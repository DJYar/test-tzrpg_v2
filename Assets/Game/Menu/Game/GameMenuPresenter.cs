using Game.Core;
using UnityEngine.SceneManagement;

namespace Game.Menu.Game
{
    public class GameMenuPresenter : GenericPresenter<IGameMenuView>
    {
        private const string MenuSceneName = "CharacterSelector";

        public void GoBack()
        {
            SceneManager.LoadSceneAsync(MenuSceneName, LoadSceneMode.Single);
        }
    }
}