public class CameraSpinner : Spinner
{
    private bool isSpinning = false;

    // Update is called once per frame
    public override void Update()
    {
        if (isSpinning)
        {
            base.Update();
        }
        else if(GameStateManager.instance.gameState == GameStateManager.GameState.Win)
        {
            isSpinning = true;
        }
    }
}
