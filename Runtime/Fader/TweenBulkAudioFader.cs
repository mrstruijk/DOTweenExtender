using System.Collections;
using UnityEngine;


namespace SOSXR.DOTweenExtender
{
    public class TweenBulkAudioFader : MonoBehaviour
    {
        protected void StartAudioFade(float fadeDuration)
        {
            var audioSources = FindObjectsOfType<AudioSource>();

            foreach (var source in audioSources)
            {
                StartCoroutine(AudioFadeCR(source, fadeDuration, 0));
            }
        }


        private IEnumerator AudioFadeCR(AudioSource audioSource, float duration, float targetVolume)
        {
            if (audioSource == null || !audioSource.gameObject.activeInHierarchy)
            {
                yield break;
            }

            float currentTime = 0;
            var start = audioSource.volume;

            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;

                if (audioSource == null || !audioSource.gameObject.activeInHierarchy)
                {
                    yield break;
                }

                audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);

                yield return null;
            }
        }


        private void OnDisable()
        {
            StopAllCoroutines();
        }
    }
}