using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace AbstractObjects
{
    public abstract class BaseSpawnItem : BaseTweenObject, IPointerClickHandler
    {
        public UnityEvent OnClick { set; get; }
        public abstract Color BorderColor { set; get; }
        public abstract Color BackgroundColor { set; get; }
        public abstract string Text { set; get; }
        public abstract TMP_SpriteAsset SpriteAsset { set; get; }

        protected virtual void Awake()
        {
            OnClick = new UnityEvent();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClick?.Invoke();
        }
    }
}