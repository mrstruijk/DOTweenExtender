using DG.Tweening;
using SOSXR.EnhancedLogger;
using UnityEngine;


namespace SOSXR.DOTweenExtender
{
    public class ITLTweenAudioFader : MonoBehaviour
    {
        [SerializeField] private AudioSource m_source;
        [SerializeField] private float m_audioFadeDuration = 2.5f;

        [SerializeField] private bool m_disableOnComplete = true;


        private void Awake()
        {
            if (m_source == null)
            {
                m_source = GetComponent<AudioSource>();
            }
        }


        public void StartAudioFade(float fadeDuration)
        {
            m_source.DOFade(0, fadeDuration).OnComplete(DoOnComplete);
            this.Info("Fading audio out.");
        }


        private void DoOnComplete()
        {
            this.Info("Audio faded out.");

            if (m_disableOnComplete)
            {
                m_source.enabled = false;
                this.Info("Disabling source.");
            }
        }
    }
}