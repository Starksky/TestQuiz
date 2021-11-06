using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace AbstractObjects
{
    public abstract class BaseTweenObject : MonoBehaviour
    {
        public abstract Graphic[] GetGraphics();
        private Sequence _sequence;
        
        private Sequence CreateFadeSequence(float endValue, float duration)
        {
            Graphic[] graphics = GetGraphics();
            _sequence?.Kill();
            _sequence = DOTween.Sequence();

            foreach (var graphic in graphics)
            {
                if(graphic == graphics.FirstOrDefault())
                    _sequence.Append(graphic.DOFade(endValue, duration));
                else _sequence.Join(graphic.DOFade(endValue, duration));
            }
            
            return _sequence;
        }
        
        public virtual void Hidden(float endValue = 0f, float duration = 1f)
        {
            Sequence sequence = CreateFadeSequence(endValue, duration);
            sequence.onComplete += () =>
            {
                gameObject.SetActive(false);
            };
        }

        public virtual void Show(float endValue = 1f, float duration = 1f)
        {
            Sequence sequence = CreateFadeSequence(endValue, duration);
            sequence.onPlay += () =>
            {
                gameObject.SetActive(true);
            };
        }

        public virtual void Bounce(Transform t = null)
        {
            if (!t)
            {
                Graphic[] graphics = GetGraphics();
                graphics.FirstOrDefault()?.transform.DOShakeScale(1.0f, 0.5f, 10, 0f);
            }
            else t.DOShakeScale(1.0f, 0.5f, 10, 0f);
        }
        
        public virtual void EaseInBounce(Transform t = null)
        {
            if (!t)
            {
                Graphic[] graphics = GetGraphics();
                graphics.FirstOrDefault()?.transform.DOShakePosition(1.0f, 2f);
            }
            else t.DOShakePosition(1.0f, 2f);
        }
    }
}