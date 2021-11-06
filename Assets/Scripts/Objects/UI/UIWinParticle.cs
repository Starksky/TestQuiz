using System;
using UnityEngine;

namespace Objects.UI
{
    [RequireComponent(typeof(ParticleSystem))]
    public class UIWinParticle : MonoBehaviour
    {
        [SerializeField] private LevelEvents _levelEvents;
        private ParticleSystem _particleSystem;
       
        
        private void Awake()
        {
            _particleSystem = GetComponent<ParticleSystem>();
            _levelEvents.OnWin.AddListener(Play);
        }

        private void Play(Vector3 pos)
        {
            _particleSystem.transform.position = pos;
            _particleSystem.Play();
        }
    }
}