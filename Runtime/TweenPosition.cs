using DG.Tweening;
using UnityEngine;


namespace SOSXR.DOTweenExtender
{
    public class TweenPosition : TweenBase
    {
        [Tooltip("If not set, will find Transform on this object")]
        [SerializeField] private Transform m_target;
        [SerializeField] private Vector3 m_desiredAddedPosition;
        private Vector3 _desiredPosition;

        private Vector3 _startPosition;


        protected override void Initialisation()
        {
            if (m_target == null)
            {
                m_target = transform;
            }

            _startPosition = m_target.localPosition;
            _desiredPosition = _startPosition + m_desiredAddedPosition;
        }


        protected override Tween Tweener()
        {
            return m_target.DOLocalMove(_desiredPosition, ChangeDuration).SetLoops(m_numberOfLoops, m_loopType).SetEase(IntensityCurve);
        }
    }
}