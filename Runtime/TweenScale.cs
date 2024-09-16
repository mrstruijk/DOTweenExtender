using DG.Tweening;
using UnityEngine;


namespace SOSXR.DOTweenExtender
{
    public class TweenScale : TweenBase
    {
        public Transform Target;
        public Vector3 DesiredScale;


        protected override void Initialisation()
        {
            if (Target == null)
            {
                Target = transform;
            }
        }


        protected override Tween Tweener()
        {
            return Target.DOScale(DesiredScale, ChangeDuration).SetLoops(m_numberOfLoops, m_loopType).SetEase(IntensityCurve);
        }
    }
}