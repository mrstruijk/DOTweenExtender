using System.Collections;
using DG.Tweening;
using UnityEngine;


namespace SOSXR.DOTweenExtender
{
    public abstract class TweenBase : MonoBehaviour
    {
        [SerializeField] protected float m_durationBeforeTweenStart = 5f;
        public float ChangeDuration = 1f;
        public AnimationCurve IntensityCurve = new(new Keyframe(0, 0), new Keyframe(1, 1));
        [SerializeField] protected int m_numberOfLoops;
        [SerializeField] protected LoopType m_loopType = LoopType.Yoyo;
        [SerializeField] protected bool m_changeFromStart = true;
        private Tween _tween;
        private bool _initialised;


        private void OnEnable()
        {
            if (!_initialised)
            {
                Initialisation();
            }

            _initialised = true;

            if (m_changeFromStart)
            {
                Tween();
            }
        }


        protected abstract void Initialisation();


        [ContextMenu(nameof(Tween))]
        public void Tween()
        {
            StartCoroutine(DelayedTweenCR(m_durationBeforeTweenStart));
        }


        public void Tween(float duration)
        {
            StartCoroutine(DelayedTweenCR(duration));
        }


        private IEnumerator DelayedTweenCR(float delay)
        {
            yield return new WaitForSeconds(delay);

            _tween = Tweener();
        }


        /// <summary>
        ///     E.g: m_target.DOLocalMove(m_desiredPosition, m_changeDuration).SetLoops(m_numberOfLoops,
        ///     m_loopType).SetEase(m_intensityCurve);
        /// </summary>
        protected abstract Tween Tweener();


        private void OnDisable()
        {
            _tween.Kill();
            StopAllCoroutines();
        }
    }
}