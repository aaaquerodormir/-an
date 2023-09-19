using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogoControl : MonoBehaviour
{
    public GameObject dialogoObj;
    public Image profile;
    public Text speechText;
    public Text actorNameText;

    public float typingSpeed;
    private string[] sentences;
    public int index;

    private bool isDialogActive = false;
    private bool playerInRadious = false;

    private void Start()
    {
        dialogoObj.SetActive(false);
    }

    public void UpdatePlayerInRadious(bool inRadious)
    {
        playerInRadious = inRadious;
    }

    public bool CanStartSpeech()
    {
        return !isDialogActive && playerInRadious;
    }

    public void Speech(Sprite p, string[] txt, string actorName)
    {
        isDialogActive = true;
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
        if (speechText.text == sentences[index])
        {
            if (index < sentences.Length - 1)
            {
                index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }
            else
            {
                speechText.text = "";
                index = 0;
                dialogoObj.SetActive(false);
                isDialogActive = false;
            }
        }
    }
}
