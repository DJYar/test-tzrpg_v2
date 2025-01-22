using Game.Core;
using Game.DataEntities;
using Reflex.Attributes;

namespace Game.Entities.Character
{
    public class CharacterPresenter : GenericPresenter<ICharacterView>
    {
        [Inject] private CharactersDb _charactersDb;
        [Inject] private GameState _gameState;

        public override void Mount(ICharacterView view)
        {
            base.Mount(view);

            _gameState.Changed += OnGameStateChanged;
            OnGameStateChanged();
        }

        private void OnGameStateChanged()
        {
            var id = _gameState.CharacterId;
            var prefab = _charactersDb.FindPrefab(id);
            if (!prefab)
                return;

            View.SetPreview(prefab);
        }

        public override void Unmount()
        {
            base.Unmount();

            _gameState.Changed -= OnGameStateChanged;
        }
    }
}