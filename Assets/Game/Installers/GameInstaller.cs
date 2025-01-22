using Game.DataEntities;
using Reflex.Core;
using UnityEngine;

namespace Game.Installers
{
    public class GameInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private CharactersDb _charactersDb;

        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            var _gameState = new GameState(_charactersDb);

            containerBuilder
                .AddSingleton(_charactersDb)
                .AddSingleton(_gameState);
        }
    }
}