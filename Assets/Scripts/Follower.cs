using UnityEngine;
using PathCreation;

public class Follower : MonoBehaviour
{
    public PathCreator pathCreator;
    public float maxSpeed;
    public float winSpeed;
    private float currentSpeed;
    public float acceleration;
    public float deceleration;
    float distanceTravelled;
    public Vector3 offset;
    public Renderer followerRenderer;

    bool enteringNewState = false;

    private void Start()
    {
        transform.position = pathCreator.path.GetPointAtDistance(0f) + offset;
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameStateManager.instance.gameState)
        {
            case GameStateManager.GameState.Playing:
                PlayingUpdate();
                break;
            case GameStateManager.GameState.Win:
                WinUpdate();
                break;
            case GameStateManager.GameState.Die:
                DieUpdate();
                break;
        }
    }

    private void PlayingUpdate()
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
            MovePlayerAlongPath(currentSpeed);
        }
    }

    private void WinUpdate()
    {
        if (enteringNewState)
        {

        }
        MovePlayerAlongPath(winSpeed, false);
    }

    private void DieUpdate()
    {
        if (enteringNewState)
        {
            followerRenderer.enabled = false;
        }
    }

    private void MovePlayerAlongPath(float speed, bool rotate = true)
    {
        distanceTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, EndOfPathInstruction.Stop) + offset;
        if (rotate)
        {
            transform.eulerAngles = pathCreator.path.GetRotationAtDistance(distanceTravelled).eulerAngles;
        }
    }

    public bool isMoving()
    {
        return Input.GetKey(KeyCode.Space);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameStateManager.instance.gameState == GameStateManager.GameState.Playing)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer(LayerConstants.KillPlayerLayer))
            {
                GameStateManager.instance.Die();
                enteringNewState = true;
            }
            else if (other.gameObject.layer == LayerMask.NameToLayer(LayerConstants.EndLevelLayer))
            {
                GameStateManager.instance.Win();
                enteringNewState = true;
            }
        }
    }
}
