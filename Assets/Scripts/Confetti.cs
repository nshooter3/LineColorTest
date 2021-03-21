using UnityEngine;

public class Confetti : MonoBehaviour
{
    public ParticleSystem particles;
    bool hasFired = false;

    // Start is called before the first frame update
    void Start()
    {
        particles = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasFired && GameStateManager.instance.gameState == GameStateManager.GameState.Win)
        {
            hasFired = true;
            particles.Play();
        }
    }
}
