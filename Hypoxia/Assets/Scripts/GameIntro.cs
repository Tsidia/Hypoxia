using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class GameIntro : MonoBehaviour
{
    public TMP_Text displayText;
    public string fullText = "Impulse Completed\nWarp Drive Failure: Local area does not match jump destination\nCritical failure: proximity to nearest black hole [1000ux] below minimal safe distance [1000000ux]\nCritical failure: crew in immediate danger\nWaking pilot from hibernation... success\nReverting control to pilot... success\nManual controls engaged.\n"; public float typingSpeed = 0.05f;
    public int originalFontSize = 24; // Set this to match the font size in the inspector
    private RectTransform rectTransform;
    private float shrinkDuration = 10.0f; // Duration of the shrink effect

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        StartCoroutine(TypeOutText());
    }


    IEnumerator TypeOutText()
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            displayText.text = fullText.Substring(0, i);
            yield return new WaitForSeconds(typingSpeed);
        }
        StartCoroutine(ShrinkScreen());
    }

    IEnumerator ShrinkScreen()
    {
        // Calculate target size as a percentage of the screen size
        float targetWidthPercentage = 0.15f; // 10% of screen width
        float targetHeightPercentage = 0.15f; // 10% of screen height
        Vector2 targetSize = new Vector2(Screen.width * targetWidthPercentage, Screen.height * targetHeightPercentage);
        Vector2 targetPosition = new Vector2(Screen.width - targetSize.x, targetSize.y - Screen.height);
        Vector2 originalSize = new Vector2(Screen.width, Screen.height);
        float elapsedTime = 0;

        while (elapsedTime < shrinkDuration)
        {
            float scale = elapsedTime / shrinkDuration;
            rectTransform.sizeDelta = Vector2.Lerp(originalSize, targetSize, scale);
            rectTransform.anchoredPosition = Vector2.Lerp(new Vector2(0, 0), targetPosition, scale);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        GameManager.Instance.IntroComplete();
    }
}
