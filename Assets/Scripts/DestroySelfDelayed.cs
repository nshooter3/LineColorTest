using UnityEngine;

public class DestroySelfDelayed : MonoBehaviour
{
    public float delay;

    // Update is called once per frame
    void Update()
    {
        if (delay > 0f)
        {
            delay -= Time.deltaTime;
            if (delay <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
