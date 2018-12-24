using Nez;
using Nez.UI;
using Microsoft.Xna.Framework;


public class MainGameMenu : Menu
{
    private Entity m_mainPlayerEntity;
    private Label m_showMainPlayerPositionLabel;

    public override void initialize()
    {
        base.initialize();

        m_mainPlayerEntity = Core.scene.findEntity("Main Player");
        m_showMainPlayerPositionLabel = new Label("hello world", new LabelStyle(Graphics.instance.bitmapFont, Color.DarkRed));
        m_table.addElement(m_showMainPlayerPositionLabel);
        m_showMainPlayerPositionLabel.setPosition(0.0f, 0.0f);
        m_showMainPlayerPositionLabel.setPosition(Globals.WINDOW_WIDTH-200, Globals.WINDOW_HEIGHT-40);
        m_showMainPlayerPositionLabel.setSize(100, 40);
        m_showMainPlayerPositionLabel.setFontScale(3);
    }

    private void UpdatePlayerLocationShow()
    {
        
        m_showMainPlayerPositionLabel.setText(
            string.Format("x={0}, y={1}", 
                (int)m_mainPlayerEntity.transform.position.X, 
                (int)m_mainPlayerEntity.transform.position.Y
                ));
    }
    
    public override void update()
    {
        base.update();
        if(m_mainPlayerEntity != null)
        {
            UpdatePlayerLocationShow();
        }
    }

    public override UICanvas CreateCanvas()
    {
        var canvas = new UICanvas();
        canvas.isFullScreen = false;
        return canvas;
    }

    public override Entity CreateEntity()
    {
        return Core.scene.createEntity("Main Game Menu Canvas");
    }

    public override Table CreateTable()
    {
        return new Table();
    }
}

