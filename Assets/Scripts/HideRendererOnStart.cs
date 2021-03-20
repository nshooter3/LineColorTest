using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideRendererOnStart : MonoBehaviour
{
    private Renderer ren;

    // Start is called before the first frame update
    void Start()
    {
        ren = GetComponent<Renderer>();
        ren.enabled = false;
    }
}
