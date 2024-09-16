using DG.Tweening;
using UnityEngine;


namespace SOSXR.DOTweenExtender
{
    /// <summary>
    ///     Uses Tweening to fade in and out.
    /// </summary>
    [RequireComponent(typeof(MeshRenderer))]
    public class TweenAlphaMaterial : MonoBehaviour
    {
        [SerializeField] private float m_fadeOutDuration = 3f;
        [SerializeField] private float m_fadeInDuration = 5f;


        private MeshRenderer _renderer;


        private void Awake()
        {
            _renderer = GetComponent<MeshRenderer>();
        }


        public void FadeOut()
        {
            ResetAlpha(0); // Make sure we start transparent

            _renderer.material.DOFade(1, m_fadeOutDuration);
        }


        public void FadeIn()
        {
            ResetAlpha(1); // Make sure we start opaque

            _renderer.material.DOFade(0, m_fadeInDuration);
        }


        private void ResetAlpha(float alpha)
        {
            var material = _renderer.material;
            var color = material.color;
            color.a = alpha;
            material.color = color;
        }
    }
}