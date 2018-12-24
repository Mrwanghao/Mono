
using Nez;


namespace EluosiBlock.MacOS
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class MainGame : Nez.Core
    {
        public MainGame() : base(Globals.WINDOW_WIDTH, Globals.WINDOW_HEIGHT, false, windowTitle:"Hello World Window")
        {
            Core.scene = new MainScene();
            Scene.setDefaultDesignResolution(Globals.WINDOW_WIDTH, Globals.WINDOW_HEIGHT, Scene.SceneResolutionPolicy.ShowAllPixelPerfect);
        }
    }
}
