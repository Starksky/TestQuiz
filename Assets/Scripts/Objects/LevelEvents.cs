using System;
using System.Collections.Generic;
using AbstractObjects;
using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;

namespace Objects
{
    [Serializable]
    public class V3UnityEvent : UnityEvent<Vector3>
    { }
    
    [Serializable]
    public class LUnityEvent : UnityEvent<List<string>>
    { }
    
    [Serializable]
    public class SUnityEvent : UnityEvent<string>
    { }
    
    [Serializable]
    public class BUnityEvent : UnityEvent<BaseSpawnItem>
    { }
    
    public class LevelEvents : MonoBehaviour
    {
        [SerializeField] private UnityEvent onGameOver;
        [SerializeField] private UnityEvent onFail;
        [SerializeField] private UnityEvent onStartGame;
        
        [SerializeField] private V3UnityEvent onWin;
        [SerializeField] private LUnityEvent onSpawner;
        [SerializeField] private SUnityEvent onGenerateMission;
        [SerializeField] private BUnityEvent onClickSpawnItem;
        
        public UnityEvent OnGameOver => onGameOver;
        public UnityEvent OnFail => onFail;
        public UnityEvent<Vector3> OnWin => onWin;
        public UnityEvent OnStartGame => onStartGame;

        public UnityEvent<List<string>> OnSpawner => onSpawner;
        public UnityEvent<string> OnGenerateMission => onGenerateMission;
        public UnityEvent<BaseSpawnItem> OnClickSpawnItem => onClickSpawnItem;

        private void Start()
        {
            onStartGame?.Invoke();
        }
    }
}