using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessagePanel : MonoBehaviour
{

    public GameObject MessageText;

  
    public void OpenMessageText(string text)
    {
        MessageText.SetActive(true);
    }

    public void CloseMessageText()
    {
        MessageText.SetActive(false);
    }
}
