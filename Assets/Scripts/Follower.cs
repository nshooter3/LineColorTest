using UnityEngine;
using PathCreation;

public class Follower : MonoBehaviour
{
    public PathCreator pathCreator;
    public float speed = 5f;
    float distanceTravelled;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        distanceTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled) + offset;
        transform.eulerAngles = pathCreator.path.GetRotationAtDistance(distanceTravelled).eulerAngles;
    }
}
