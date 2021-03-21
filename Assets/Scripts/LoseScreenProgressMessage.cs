using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseScreenProgressMessage : MonoBehaviour
{
    public Text text;
    private string loseMessage = "% Complete";

    public void SetLoseMessage(float completion)
    {
        text.text = (int)(completion * 100) + loseMessage;
    }
}
