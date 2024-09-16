using DG.Tweening;
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

            Debug.Log("Fading audio out.");
        }


        private void DoOnComplete()
        {
            Debug.Log("Audio faded out.");

            if (m_disableOnComplete)
            {
                m_source.enabled = false;
                Debug.Log("Disabling source.");
            }
        }
    }
}