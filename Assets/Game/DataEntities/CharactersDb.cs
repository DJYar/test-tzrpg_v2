using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.DataEntities
{
    [CreateAssetMenu(fileName = "Characters", menuName = "Characters Database", order = 0)]
    public class CharactersDb : ScriptableObject
    {
        [SerializeField] private List<CharacterDescription> _db;

        public int RandomId => _db[Random.Range(0, _db.Count)].Id;

        public GameObject FindPrefab(int id)
        {
            var item = _db.FirstOrDefault(x => x.Id == id);
            if (!item)
            {
                Debug.LogError($"Character id={id} not found in characters database!");
                return null;
            }

            return item!.Prefab;
        }

        [Serializable]
        public class CharacterDescription
        {
#if UNITY_EDITOR
            [HideInInspector] public string name;
#endif

            [field: SerializeField] public int Id { get; private set; }
            [field: SerializeField] public GameObject Prefab { get; private set; }

            public static implicit operator bool(CharacterDescription self)
            {
                return self != null;
            }

#if UNITY_EDITOR
            public void UpdateId(int newId)
            {
                Id = newId;
                RefreshElementName();
            }

            public void RefreshElementName()
            {
                name = $"ID={Id}  ( {(Prefab ? Prefab.name : "empty")} )";
            }
#endif
        }

#if UNITY_EDITOR
        private bool ValidateIds()
        {
            var changesMade = false;

            var idx = 0;
            var filter = new HashSet<int>();
            var orderedDb = _db.OrderBy(x => x.Id);
            foreach (var item in orderedDb)
                while (!filter.Add(item.Id))
                {
                    item.UpdateId(idx++);
                    changesMade = true;
                }

            return changesMade;
        }

        private bool ValidateEmptyItems()
        {
            return _db.RemoveAll(x => x == null) > 0;
        }

        private void RefreshNames()
        {
            foreach (var item in _db) item.RefreshElementName();
        }

        private void OnValidate()
        {
            if (_db == null)
                return;

            RefreshNames();
            var changesMade = ValidateIds() & ValidateEmptyItems();
            if (changesMade) EditorUtility.SetDirty(this);
        }
#endif
    }
}