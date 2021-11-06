using System;
using AbstractObjects;
using UnityEngine;
using UnityEngine.UI;

namespace Objects.UI
{
    [RequireComponent(typeof(Image))]
    public class UIBackground : BaseTweenObject
    {
        [SerializeField] private LevelEvents levelEvents;
        private Image _image;

        private void OnValidate()
        {
            if(!levelEvents) Debug.LogError("LevelEvents not set!");
        }
        
        private void Awake()
        {
            _image = GetComponent<Image>();
            levelEvents.OnGameOver.AddListener(() => Show(0.5f));
            levelEvents.OnStartGame.AddListener(() => Hidden());
        }
        
        public override Graphic[] GetGraphics()
        {
            return new Graphic[]{_image};
        }
    }
}