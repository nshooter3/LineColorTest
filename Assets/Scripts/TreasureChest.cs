using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : MonoBehaviour
{
    public GameObject chestTop;
    public float topOpenZVal = -140f;
    public AnimationCurve chestOpenCurve;
    public float chestOpenTime;
    private float initChestOpenTime;

    public float openDelay;

    private bool open;

    // Start is called before the first frame update
    void Start()
    {
        initChestOpenTime = chestOpenTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!open && GameStateManager.instance.gameState == GameStateManager.GameState.Win)
        {
            open = true;
        }

        if (open)
        {
            if (openDelay > 0f)
            {
                openDelay -= Time.deltaTime;
            }
            else if (chestOpenTime > 0f)
            {
                chestOpenTime = Mathf.Max(0f, chestOpenTime - Time.deltaTime);
                Vector3 chestTopRotation = chestTop.transform.localEulerAngles;
                chestTopRotation.z = chestOpenCurve.Evaluate(1f - chestOpenTime/initChestOpenTime) * topOpenZVal;
                chestTop.transform.localEulerAngles = chestTopRotation;
            }
        }
    }
}
