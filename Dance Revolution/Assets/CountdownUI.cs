using UnityEngine;
using TMPro; // Or UnityEngine.UI for Text
using DG.Tweening;
using System.Collections;
using UnityEngine.UI;
using System;

public class CountdownUI : MonoBehaviour
{
    public TMP_Text countdownText; // Assign in Inspector
    public float largeScale = 5f;
    public float normalScale = 1f;
    public float smallScale = 0.1f;

    public float bounceOvershoot = 0.4f; // Custom overshoot for bounce effect
    public float fadeDurationLarge = 0.4f; // Duration for fade in/out
    public float fadeDurationSmall = 0.2f; // Duration for fade in/out

    public GameObject backgroundOverlay;

    public void StartCountdown(Action countdownComplete)
    {
        StartCoroutine(CountdownRoutineScale(countdownComplete));
    }

    private IEnumerator CountdownRoutineScale(Action countdownComplete)
    {
        for (int i = 3; i > 0; i--)
        {
            countdownText.text = i.ToString();
            countdownText.rectTransform.localScale = Vector3.one * largeScale;
            countdownText.alpha = 0f; // Start transparent

            // Fade in and scale down simultaneously, with bounce effect on scale
            // Use a custom overshoot value for a gentler bounce
            countdownText.rectTransform.DOScale(normalScale, fadeDurationLarge).SetEase(Ease.OutBack, bounceOvershoot);
            countdownText.DOFade(1f, 0.4f);

            yield return new WaitForSeconds(0.4f + 1f); // Animation + hold

            // Animate scale to small and fade out together
            countdownText.rectTransform.DOScale(smallScale, fadeDurationSmall).SetEase(Ease.InQuad);
            countdownText.DOFade(0f, 0.2f);

            yield return new WaitForSeconds(0.2f);
        }

        countdownText.text = "";
        countdownText.rectTransform.localScale = Vector3.one * normalScale; // Reset
        countdownText.alpha = 1f; // Reset alpha

        backgroundOverlay.GetComponent<Image>().DOFade(0f, 0.5f);
        yield return new WaitForSeconds(0.5f);
        countdownComplete.Invoke();

    }
    
        // private IEnumerator CountdownRoutine()
    // {
        // for (int i = 3; i > 0; i--)
        // {
        //     countdownText.text = i.ToString();
        //     countdownText.rectTransform.localScale = Vector3.one * largeScale;
        //     countdownText.alpha = 0f; // Start transparent

        //     // Fade in and scale down simultaneously, with bounce effect on scale
        //     // Use a custom overshoot value for a gentler bounce
        //     countdownText.rectTransform.DOScale(normalScale, fadeDurationLarge).SetEase(Ease.OutBack, bounceOvershoot);
        //     countdownText.DOFade(1f, 0.4f);

        //     yield return new WaitForSeconds(0.4f + 1f); // Animation + hold

        //     // Animate scale to small and fade out together
        //     countdownText.rectTransform.DOScale(smallScale, fadeDurationSmall).SetEase(Ease.InQuad);
        //     countdownText.DOFade(0f, 0.2f);

        //     yield return new WaitForSeconds(0.2f);
        // }

        // countdownText.text = "";
        // countdownText.rectTransform.localScale = Vector3.one * normalScale; // Reset
        // countdownText.alpha = 1f; // Reset alpha

        
    // }
}