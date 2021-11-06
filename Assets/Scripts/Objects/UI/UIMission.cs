using System;
using AbstractObjects;
using UnityEngine;
using UnityEngine.UI;

namespace Objects.UI
{
    [RequireComponent(typeof(Text))]
    public class UIMission : BaseTweenObject
    {
        [SerializeField] private LevelEvents levelEvents;
        [SerializeField] private string mask = "Find {0}";
        private Text _text;
        
        private void OnValidate()
        {
            if(!levelEvents) Debug.LogError("LevelEvents not set!");
        }

        private void Awake()
        {
            _text = GetComponent<Text>();
            levelEvents.OnGameOver.AddListener(() => Hidden());
            levelEvents.OnGenerateMission.AddListener(OnGeneratedMission);
            Hidden(0f, 0f);
        }
        
        private void OnGeneratedMission(string mission)
        {
            Show();
            _text.text = String.Format(mask, mission.ToUpper());
        }
        
        public override Graphic[] GetGraphics()
        {
            return new Graphic[]{_text};
        }
    }
}