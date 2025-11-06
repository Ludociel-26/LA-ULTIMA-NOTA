using System.Collections;
using TMPro;
using UnityEngine;

public class TypeWriterEffect : MonoBehaviour
{
    public TMP_Text textComponent;
    public float charDelay = 0.03f;
    private string fullText;

    void Start()
    {
        fullText = textComponent.text;
        textComponent.text = "";
        StartCoroutine(Reproducir());
    }

    IEnumerator Reproducir()
    {
        foreach (char c in fullText)
        {
            textComponent.text += c;
            yield return new WaitForSeconds(charDelay);
        }
    }
}
