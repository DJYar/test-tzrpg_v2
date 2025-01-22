using System;
using Game.Entities.Character;
using Game.Menu.Main;
using Reflex.Core;
using UnityEngine;

namespace Game.Installers
{
    public class MenuSceneInstaller : MonoBehaviour, IInstaller
    {
        private static readonly Type[] _presenters =
        {
            typeof(MainMenuPresenter),
            typeof(CharacterPresenter)
        };

        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            foreach (var type in _presenters) containerBuilder.AddScoped(type, type);
        }
    }
}