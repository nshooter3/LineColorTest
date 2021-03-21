using UnityEngine;

public class ScrollingOcean : MonoBehaviour
{
    public Renderer ren;
    public float xSpeed, ySpeed;
    public Color color;

    // Start is called before the first frame update
    void Update()
    {
        ren.material.SetFloat("_ScrollXSpeed", xSpeed);
        ren.material.SetFloat("_ScrollYSpeed", ySpeed);
        ren.material.SetColor("_Color", color);
    }
}
