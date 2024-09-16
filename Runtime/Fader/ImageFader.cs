using System;
using System.Collections;
using DG.Tweening;
using SOSXR.EnhancedLogger;
using UnityEngine;
using UnityEngine.UI;


namespace SOSXR.DOTweenExtender
{
    public class ImageFader : MonoBehaviour
    {
        [SerializeField] private Image m_fadeImage;
        [SerializeField] private bool m_fadeOnStart = true;
        [SerializeField] private Color m_fadeColor = Color.black;
        [SerializeField] [Range(0f, 10f)] private float m_preFadeInDuration = 2f;

        [SerializeField] [Range(0f, 10f)] private float m_preFadeOutDuration = 0f;

        [SerializeField] private AnimationCurve m_fadeCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);

        private float _backupTimer;

        private Coroutine _fadeInCoroutine;
        private Coroutine _fadeOutCoroutine;


        private void Start()
        {
            if (!m_fadeOnStart)
            {
                return;
            }

            FadeIn(5);
            this.Warning("We've hardcoded the fade duration to 5 seconds, you might want to change this.");
        }


        private void OnEnable()
        {
        }


        /// <summary>
        ///     Fades out first, then fades back in
        /// </summary>
        public void FadeRound(float f)
        {
            FadeOut(f / 2);
            FadeIn(f / 2);
        }


        public void FadeIn(float f)
        {
            if (_fadeInCoroutine != null)
            {
                return;
            }

            _fadeInCoroutine = StartCoroutine(FadeInCR(f));
        }


        public void FadeOut(float f)
        {
            if (_fadeOutCoroutine != null)
            {
                return;
            }

            m_fadeImage.enabled = true;

            _fadeOutCoroutine = StartCoroutine(FadeOutCR(f));
        }


        private IEnumerator FadeInCR(float f)
        {
            _backupTimer = 0f;

            while (_fadeOutCoroutine != null)
            {
                this.Info("Fade out is still running, waiting for it to finish");

                _backupTimer += Time.deltaTime;

                if (_backupTimer > f)
                {
                    this.Error("Backup timer exceeded the fadeOut duration, stopping the fadeOut coroutine");
                    _fadeOutCoroutine = null;
                }

                yield return null;
            }

            if (Math.Abs(m_fadeImage.color.a - 0) < 0.01f)
            {
                this.Info("Fade in is already finished, not doing anything");

                yield break;
            }

            DOTween.KillAll();

            yield return new WaitForSeconds(m_preFadeInDuration);

            m_fadeImage.DOFade(0, f).SetEase(m_fadeCurve).onComplete += FadeInFinished;
        }


        private void FadeInFinished()
        {
            _fadeInCoroutine = null;

            m_fadeImage.enabled = false;
        }


        private IEnumerator FadeOutCR(float f)
        {
            _backupTimer = 0f;

            while (_fadeInCoroutine != null)
            {
                this.Info("Fade in is still running, waiting for it to finish");

                _backupTimer += Time.deltaTime;

                if (_backupTimer > f)
                {
                    this.Error("Backup timer exceeded the fadeIn duration, stopping the fadeIn coroutine");
                    _fadeInCoroutine = null;
                }

                yield return null;
            }

            if (Math.Abs(m_fadeImage.color.a - 1) < 0.01f)
            {
                this.Info("Fade out is already finished, not doing anything");

                yield break;
            }

            DOTween.KillAll();

            yield return new WaitForSeconds(m_preFadeOutDuration);


            m_fadeImage.DOFade(1, f).SetEase(m_fadeCurve).onComplete += FadeOutFinished;
        }


        private void FadeOutFinished()
        {
            _fadeOutCoroutine = null;
        }


        private void OnDisable()
        {
            StopAllCoroutines();
        }
    }
}