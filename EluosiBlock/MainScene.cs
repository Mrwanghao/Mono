using Nez;

public class MainScene : Scene
{
    public MainScene()
    {
        addRenderer(new DefaultRenderer());
    }

    //Task task;
    Constructor constructor;

    public override void onStart()
    {
        base.onStart();

        ControllersManager.Push("Player Controller", new PlayerController());
        UIManager.Push("Main Game Menu Canvas", new MainGameMenu());

        //task = new Task();
        //task.SetPosition(new Microsoft.Xna.Framework.Vector2(200.0f, 200.0f));
        constructor = new Constructor();
    }   

    public override void update()
    {
        base.update();

        ControllersManager.update();
        UIManager.update();

        //task.update();
        constructor.update();

    }

   


}

