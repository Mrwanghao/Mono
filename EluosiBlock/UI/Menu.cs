using Nez.UI;
using Nez;


public abstract class Menu
{
    protected UICanvas m_canvas;
    protected Table m_table;
    protected Entity m_entity;


    public Menu()
    {
        m_canvas = CreateCanvas();
        m_table = CreateTable();
        m_entity = CreateEntity();

        m_entity.addComponent(m_canvas);
        m_canvas.stage.addElement(m_table);

    }

    public virtual void initialize() { }
    public virtual void update() { }

    public abstract UICanvas CreateCanvas();
    public abstract Table CreateTable();
    public abstract Entity CreateEntity();

}

