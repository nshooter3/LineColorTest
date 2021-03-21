using UnityEngine;

public class FollowerDebris : MonoBehaviour
{
    public bool randomScale = true;

    private Rigidbody rb;
    public float randomSpeedLow = 0.2f;
    public float randomSpeedHigh = 0.6f;

    float scaleLow = 0.5f;
    float scaleHigh = 1.5f;
    float scale;
    private Vector3 initScale;

    private float minLifeTime = 2f;
    private float maxLifeTime = 2.75f;
    private float lifeTime;
    private float curShrinkTime;
    private float maxShrinkTime = 0.25f;

    private float minYPos = -0.49f;

    public GameObject splashPrefab;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.rotation = Random.rotation;

        rb.velocity = Vector3.one * Random.Range(randomSpeedLow, randomSpeedHigh);

        if (randomScale)
        {
            scale = Random.Range(scaleLow, scaleHigh);
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z) * scale;
        }
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

        if (transform.position.y <= minYPos)
        {
            Vector3 splashPos = transform.position;
            splashPos.y = minYPos;

            Instantiate(splashPrefab, splashPos, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
