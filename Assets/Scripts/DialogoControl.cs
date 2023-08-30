using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogoControl : MonoBehaviour
{
    [Header("Components")]
    public GameObject dialogoObj;
    public Image profile;
    public Text speechText;
    public Text actorNameText;

    [Header("Settings")]
    public float typingSpeed;
    private string[] sentences;
    public int index;

    public void Speech(Sprite p, string[] txt, string actorName)
    {
        dialogoObj.SetActive(true);
        profile.sprite = p;
        sentences = txt;
        actorNameText.text = actorName;
        StartCoroutine(TypeSentence());
    }

    IEnumerator TypeSentence()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        if(speechText.text == sentences[index])
        {
            //ainda h� textos
            if(index < sentences.Length - 1)
            {
                index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }
            else // le quando acabar os textos
            {
                speechText.text = "";
                index = 0;
                dialogoObj.SetActive(false);
            }
        }
    }
}