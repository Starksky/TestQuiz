using System;
using AbstractObjects;
using JetBrains.Annotations;
using UnityEngine;

namespace Objects
{
    [RequireComponent(typeof(LevelEvents))]
    public class LevelLoader : BaseLevelLoader
    {
        [SerializeField] private AssetGame _assetGame;
        [SerializeField] private BaseSpawner _spawner;

        private LevelEvents _levelEvents;
        private int _currentLevel;
        
        private void OnValidate()
        {
            if(!_assetGame) Debug.LogError("AssetGame not set!");
            if(_spawner == null) Debug.LogError("Spawner not set!");
        }

        private void Awake()
        {
            _levelEvents = GetComponent<LevelEvents>();
        }

        [UsedImplicitly]
        public override void Restart()
        {
            _currentLevel = 0;
            _levelEvents.OnStartGame?.Invoke();
        }
        
        public override void NextLevel()
        {
            if (_assetGame.Levels.Count < _currentLevel + 1)
            {
                _levelEvents.OnGameOver?.Invoke();
                return;
            }
            
            var level = _assetGame.Levels[_currentLevel];
            if (!_spawner.TrySpawn(level, _currentLevel == 0))
                Debug.LogError("Next level not created!");
            else _currentLevel++;
        }
    }
}