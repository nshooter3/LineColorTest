﻿using System.Collections;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;

    public EndScreen winScreen;
    public EndScreen loseScreen;

    private float winEndScreenDelay = 2.0f;
    private float loseEndScreenDelay = 1.5f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ActivateWinScreen()
    {
        StartCoroutine(ActivateWinScreenCoroutine());
    }

    private IEnumerator ActivateWinScreenCoroutine()
    {
        yield return new WaitForSeconds(winEndScreenDelay);
        winScreen.StartEndScreen();
    }

    public void ActivateLoseScreen()
    {
        StartCoroutine(ActivateLoseScreenCoroutine());
    }

    private IEnumerator ActivateLoseScreenCoroutine()
    {
        yield return new WaitForSeconds(loseEndScreenDelay);
        loseScreen.StartEndScreen();
    }
}