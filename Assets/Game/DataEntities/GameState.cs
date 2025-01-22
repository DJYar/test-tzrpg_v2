using System;
using UnityEngine;

namespace Game.DataEntities
{
    [Serializable]
    public class GameState
    {
        private const string PrefsKey = nameof(GameState);

        [SerializeField] private int _characterId;

        [NonSerialized] private CharactersDb _db;

        public GameState(CharactersDb db)
        {
            _db = db;

            var data = PlayerPrefs.GetString(PrefsKey, null);
            if (string.IsNullOrEmpty(data))
                return;

            JsonUtility.FromJsonOverwrite(data, this);
        }

        public int CharacterId
        {
            get => _characterId;
            set
            {
                if (!_db.FindPrefab(value))
                    return;

                _characterId = value;
                FireValueChangedEvent();
            }
        }

        public event Action Changed;

        private void FireValueChangedEvent()
        {
            PlayerPrefs.SetString(PrefsKey, JsonUtility.ToJson(this));
            Changed?.Invoke();
        }

        public void SetRandomCharacter()
        {
            CharacterId = _db.RandomId;
        }
    }
}