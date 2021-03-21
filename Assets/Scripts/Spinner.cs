using UnityEngine;

public class Spinner : MonoBehaviour
{
    public float rotationSpeed;

    // Update is called once per frame
    public virtual void Update()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + rotationSpeed * Time.deltaTime, transform.eulerAngles.z);
    }
}
