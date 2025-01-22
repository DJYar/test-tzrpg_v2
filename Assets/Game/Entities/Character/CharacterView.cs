using Reflex.Attributes;
using UnityEngine;

namespace Game.Entities.Character
{
    public class CharacterView : MonoBehaviour, ICharacterView
    {
        [SerializeField] private Transform _previewRoot;
        [Inject] private CharacterPresenter _characterPresenter;

        private void Awake()
        {
            _characterPresenter.Mount(this);
        }

        public void SetPreview(GameObject characterPrefab)
        {
            ClearPreviewRoot();
            if (!characterPrefab)
                return;

            var instance = Instantiate(characterPrefab.gameObject, _previewRoot);
            var instanceTransform = instance.transform;
            instanceTransform.localPosition = Vector3.zero;
            instanceTransform.localRotation = Quaternion.identity;
        }

        private void ClearPreviewRoot()
        {
            for (var i = _previewRoot.transform.childCount - 1; i >= 0; i--)
                Destroy(_previewRoot.transform.GetChild(i).gameObject);
        }

        public void OnDestroy()
        {
            _characterPresenter.Unmount();
        }
    }
}