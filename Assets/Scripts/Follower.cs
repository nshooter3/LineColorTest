using UnityEngine;
using PathCreation;

public class Follower : MonoBehaviour
{
    public PathCreator pathCreator;
    public float maxSpeed;
    private float currentSpeed;
    public float acceleration;
    public float deceleration;
    float distanceTravelled;
    public Vector3 offset;

    private void Start()
    {
        transform.position = pathCreator.path.GetPointAtDistance(0f) + offset;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving())
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, maxSpeed, acceleration);
        }
        else
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, deceleration);
        }

        if (currentSpeed > 0f)
        {
            distanceTravelled += currentSpeed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled) + offset;
            transform.eulerAngles = pathCreator.path.GetRotationAtDistance(distanceTravelled).eulerAngles;
        }
    }

    public bool isMoving()
    {
        return Input.GetKey(KeyCode.Space);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("DIE");
        GameState.instance.Die();
    }
}
