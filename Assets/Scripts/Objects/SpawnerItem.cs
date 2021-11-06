using System;
using System.Collections.Generic;
using AbstractObjects;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Objects
{
    [RequireComponent(typeof(Canvas))]
    public class SpawnerItem : BaseSpawnItem
    {
        [SerializeField] private TMP_Text text;
        [SerializeField] private Image background;
        [SerializeField] private Image border;

        public override Color BorderColor
        {
            get => border.color;
            set => border.color = value;
        }
        
        public override Color BackgroundColor
        {
            get => background.color;
            set => background.color = value;
        }
        
        public override string Text
        {
            get => text_value;
            set
            {
                text_value = value;
                text.text = String.Format(mask, value);
            }
        }

        public override TMP_SpriteAsset SpriteAsset
        {
            get => text.spriteAsset;
            set => text.spriteAsset = value;
        }
        
        private string text_value = "";
        private string mask = "<sprite name=\"{0}\">";
        
        private void OnValidate()
        {
            if(text == null) Debug.LogError("TMP_Text not set!");
            if(background == null) Debug.LogError("Image Background not set!");
            if(border == null) Debug.LogError("Image Border not set!");
        }
        
        public override Graphic[] GetGraphics()
        {
            return new Graphic[]{text, background, border};
        }
    }
}
