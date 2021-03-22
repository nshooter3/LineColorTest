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
    public Vector3 offset;
    public Renderer followerRenderer;

    private float distanceTravelled;
    private float totalDistance;

    private bool enteringNewState = false;

    public FollowerDebris followerDebrisPrefab;
    private int debrisCountLow = 17;
    private int debrisCountHigh = 23;
    private int debrisCount;

    public Material pathMat;

    private bool isTouchingScreen;

    private void Start()
    {
        transform.position = pathCreator.path.GetPointAtDistance(0f) + offset;
        totalDistance = pathCreator.path.length;
    }

    // Update is called once per frame
    void Update()
    {
        DetectTouchInput();
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
        CanvasManager.instance.SetProgressSlider(Mathf.Min(1f, GetPlayerProgress()));
        pathMat.SetFloat("_Progress", Mathf.Min(1f, GetPlayerProgress()));
    }

    private void DetectTouchInput()
    {
        // Handle screen touches.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                isTouchingScreen = true;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                isTouchingScreen = false;
            }
        }
    }

    private float GetPlayerProgress()
    {
        return Mathf.Min(1f, distanceTravelled / totalDistance);
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
            enteringNewState = false;
        }
        MovePlayerAlongPath(winSpeed);
    }

    private void DieUpdate()
    {
        if (enteringNewState)
        {
            followerRenderer.enabled = false;
            debrisCount = Random.Range(debrisCountLow, debrisCountHigh);
            for (int i = 0; i < debrisCount; i++)
            {
                Instantiate(followerDebrisPrefab, transform.position, Quaternion.identity);
            }
            enteringNewState = false;
        }
    }

    private void MovePlayerAlongPath(float speed)
    {
        distanceTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, EndOfPathInstruction.Stop) + offset;
        transform.eulerAngles = pathCreator.path.GetRotationAtDistance(distanceTravelled, EndOfPathInstruction.Stop).eulerAngles;
    }

    public bool isMoving()
    {
        return Input.GetKey(KeyCode.Space) || isTouchingScreen;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameStateManager.instance.gameState == GameStateManager.GameState.Playing)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer(LayerConstants.KillPlayerLayer))
            {
                GameStateManager.instance.Die(GetPlayerProgress());
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
