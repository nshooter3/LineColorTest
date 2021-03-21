using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Follower player;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Follower>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
