﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{

    public Text dialogueText;
    private bool isTyping = false;
    private float typeSpeed = 0.03f;
    
    public void SetText(string text)
    {
        StartCoroutine(TypeText(text));
    }
    
    public IEnumerator TypeText(string text)
    {
        isTyping = true;
        dialogueText = GetComponent<Text>();
        dialogueText.text = "";
        yield return new WaitForSeconds(Mathf.PI / 10);


        foreach (char letter in text)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }

        isTyping = false;
    }

    public bool GetTyping()
    {
        return isTyping;
    }

}
