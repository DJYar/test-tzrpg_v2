using Game.Core;
using UnityEngine;

namespace Game.Entities.Character
{
    public interface ICharacterView : IView
    {
        void SetPreview(GameObject characterPrefab);
    }
}