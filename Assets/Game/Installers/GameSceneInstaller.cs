using System;
using Game.Entities.Character;
using Game.Menu.Game;
using Reflex.Core;
using UnityEngine;

namespace Game.Installers
{
    public class GameSceneInstaller : MonoBehaviour, IInstaller
    {
        private static readonly Type[] _presenters =
        {
            typeof(GameMenuPresenter),
            typeof(CharacterPresenter)
        };

        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            foreach (var type in _presenters) containerBuilder.AddScoped(type, type);
        }
    }
}