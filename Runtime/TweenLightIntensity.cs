using DG.Tweening;
using UnityEngine;


namespace SOSXR.DOTweenExtender
{
    public class TweenLightIntensity : TweenBase
    {
        [SerializeField] private Light m_lightSource;
        [SerializeField] private float m_startIntensity;
        [SerializeField] private float m_desiredIntensity;


        protected override void Initialisation()
        {
            m_lightSource.intensity = m_startIntensity;
        }


        protected override Tween Tweener()
        {
            return m_lightSource.DOIntensity(m_desiredIntensity, ChangeDuration).SetLoops(m_numberOfLoops, m_loopType).SetEase(IntensityCurve);
        }


        private void OnDisable()
        {
            StopAllCoroutines();
        }
    }
}