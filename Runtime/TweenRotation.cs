using DG.Tweening;
using UnityEngine;


namespace SOSXR.DOTweenExtender
{
    public class TweenRotation : TweenBase
    {
        [Tooltip("If not set, will find Transform on this object")]
        [SerializeField] private Transform m_target;

        //[SerializeField] private Quaternion m_startRotation;
        [SerializeField] private Vector3 m_desiredRotation;
        [SerializeField] private Vector2 m_range = new(-2, 2);


        protected override void Initialisation()
        {
            if (m_target == null)
            {
                m_target = transform;
            }

            if (m_range.x == 0 && m_range.y == 0)
            {
                return;
            }

            if (m_desiredRotation.x != 0)
            {
                m_desiredRotation.x += Random.Range(m_range.x, m_range.y);
            }

            if (m_desiredRotation.y != 0)
            {
                m_desiredRotation.y += Random.Range(m_range.x, m_range.y);
            }

            if (m_desiredRotation.z != 0)
            {
                m_desiredRotation.z += Random.Range(m_range.x, m_range.y);
            }
        }


        protected override Tween Tweener()
        {
            var transformLocalRotation = transform.localRotation;
            var target = transformLocalRotation.eulerAngles += m_desiredRotation;

            return m_target.DOLocalRotate(target, ChangeDuration).SetLoops(m_numberOfLoops, m_loopType).SetEase(IntensityCurve);
        }
    }
}