using UnityEngine;

public class FollowerDebris : MonoBehaviour
{
    Rigidbody rb;
    Vector3 randomDirection = new Vector3();
    float randomSpeedLow = 0.2f;
    float randomSpeedHigh = 0.6f;

    float scaleLow = 0.5f;
    float scaleHigh = 1.5f;
    float scale;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        randomDirection.x = Random.value;
        randomDirection.y = Random.value;
        randomDirection.z = Random.value;
        transform.Rotate(randomDirection);

        rb.velocity = Vector3.one * Random.Range(randomSpeedLow, randomSpeedHigh);

        scale = Random.Range(scaleLow, scaleHigh);
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z) * scale;
    }
}
