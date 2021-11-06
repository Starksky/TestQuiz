using System;
using AbstractObjects;
using UnityEngine;
using UnityEngine.UI;

namespace Objects.UI
{
    [RequireComponent(typeof(Button))]
    public class UIRestart : BaseTweenObject
    {
        [SerializeField] private LevelEvents levelEvents;
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
            
            levelEvents.OnGameOver.AddListener(() =>
            {
                _button.interactable = true;
                Show();
            });
            levelEvents.OnStartGame.AddListener(() =>
            {
                _button.interactable = false;
                Hidden(0f, 0.2f);
            });
        }

        public override Graphic[] GetGraphics()
        {
            return new Graphic[]{_button.targetGraphic};
        }
    }
}