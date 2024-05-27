using UnityEngine;
using TMPro;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    public TMP_Text infoText;
    public float scrollSpeed = 20f; // Speed of text scrolling

    private bool isScrolling = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void AppendText(string newText)
    {
        if (!isScrolling)
        {
            StartCoroutine(ScrollAndAppendText(newText));
        }
    }

    IEnumerator ScrollAndAppendText(string newText)
    {
        isScrolling = true;

        // Calculate the height of the new text
        TMP_Text tempText = Instantiate(infoText, infoText.transform.parent);
        tempText.text = newText;
        float newHeight = tempText.preferredHeight;
        Destroy(tempText.gameObject);

        // Append new text below current text (off-screen)
        infoText.text += "\n" + newText;

        // Scroll enough to bring the new text into view
        RectTransform textRectTransform = infoText.rectTransform;
        float targetYPos = textRectTransform.anchoredPosition.y + newHeight;

        while (textRectTransform.anchoredPosition.y < targetYPos)
        {
            textRectTransform.anchoredPosition += new Vector2(0, scrollSpeed * Time.deltaTime);
            yield return null;
        }

        isScrolling = false;
    }
}
