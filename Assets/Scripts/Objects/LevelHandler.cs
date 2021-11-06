using System;
using System.Collections;
using AbstractObjects;
using UnityEngine;

namespace Objects
{
    [RequireComponent(typeof(LevelEvents), 
        typeof(LevelChecker), 
        typeof(LevelLoader))]
    public class LevelHandler : MonoBehaviour
    {
        private LevelEvents _levelEvents;
        private LevelChecker _levelChecker;
        private LevelLoader _levelLoader;

        private void Awake()
        {
            _levelEvents = GetComponent<LevelEvents>();
            _levelChecker = GetComponent<LevelChecker>();
            _levelLoader = GetComponent<LevelLoader>();
            
            _levelEvents.OnStartGame.AddListener(_levelLoader.NextLevel);
            _levelEvents.OnClickSpawnItem.AddListener(OnClickSpawnItem);
            _levelEvents.OnWin.AddListener(OnWin);
        }

        private void OnClickSpawnItem(BaseSpawnItem item)
        {
            if (_levelChecker.ChekLevel(item))
            {
                item.Bounce();
                _levelEvents.OnWin?.Invoke(item.transform.position);
            }
            else
            {
                item.EaseInBounce();
                _levelEvents.OnFail?.Invoke();
            }
        }

        private void OnWin(Vector3 pos)
        {
            StartCoroutine(Delay(1f, () => _levelLoader.NextLevel()));
        }

        private IEnumerator Delay(float time, Action callback)
        {
            yield return new WaitForSeconds(time);
            callback?.Invoke();
        }
    }
}