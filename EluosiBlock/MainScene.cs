using Nez;

public class MainScene : Scene
{
    public MainScene()
    {
        addRenderer(new DefaultRenderer());
    }
    
    public override void onStart()
    {
        base.onStart();

        ControllersManager.Push("Player Controller", new PlayerController());
        UIManager.Push("Main Game Menu Canvas", new MainGameMenu());
    }   

    public override void update()
    {
        base.update();

        ControllersManager.update();
        UIManager.update();

    }

   


}

