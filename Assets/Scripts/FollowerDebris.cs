using UnityEngine;

public class FollowerDebris : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 randomDirection = new Vector3();
    float randomSpeedLow = 0.2f;
    float randomSpeedHigh = 0.6f;

    float scaleLow = 0.5f;
    float scaleHigh = 1.5f;
    float scale;
    private Vector3 initScale;

    private float minLifeTime = 2f;
    private float maxLifeTime = 2.75f;
    private float lifeTime;
    private float curShrinkTime;
    private float maxShrinkTime = 0.25f;

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
        initScale = transform.localScale;

        curShrinkTime = maxShrinkTime;
        lifeTime = Random.Range(minLifeTime, maxLifeTime);
    }

    private void Update()
    {
        if (lifeTime > 0f)
        {
            lifeTime -= Time.deltaTime;
        }
        else if (curShrinkTime > 0f)
        {
            curShrinkTime = Mathf.Max(curShrinkTime - Time.deltaTime, 0f);
            transform.localScale = Vector3.Lerp(initScale, Vector3.zero, 1f - curShrinkTime / maxShrinkTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
