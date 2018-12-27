using Microsoft.Xna.Framework.Graphics;
using Nez;
using Microsoft.Xna.Framework;
using Nez.Sprites;

public class Task
{
    public Task()
    {
        m_taskRenderer = new TaskRenderer();
        ExpectedSchedule = 1.0f;
    }

    private float m_CurrentSchedule;
    public float CurrentSchedule
    {
        get { return m_CurrentSchedule; }
        set { m_CurrentSchedule = value; }
    }

    private float m_ExpectedSchedule;  
    public float ExpectedSchedule
    {
        get { return m_ExpectedSchedule; }
        set 
            { 
                m_ExpectedSchedule = value; 
                CalculateScheduleSpeed(); 
            }
    }

    private void CalculateScheduleSpeed()
    {
        m_ScheduleSpeed = (ExpectedSchedule - CurrentSchedule) / DEFAULT_SCHEDULE_TIME;
    }

    private static float DEFAULT_SCHEDULE_TIME = 5.0f;
    private float m_ScheduleSpeed;

    private TaskRenderer m_taskRenderer;

    public void update()
    { 
        if(CurrentSchedule != ExpectedSchedule)
        {
            CurrentSchedule = CurrentSchedule + m_ScheduleSpeed * Time.deltaTime;
            m_taskRenderer.SetSchedule(CurrentSchedule);
            if(ExpectedSchedule <= CurrentSchedule)
            {
                CurrentSchedule = ExpectedSchedule;
            }
        }
    }

    public void AddSchedule(float _addSchedule)
    {
        ExpectedSchedule += _addSchedule;
    }

    public void SetPosition(Vector2 _position)
    {
        m_taskRenderer.SetPosition(_position);
    }

}

public class TaskRenderer
{
    private static int m_taskRendererIndex = 0;

    private Text m_scheduleShowText;
    private Sprite m_scheduleShowSprite;
    private Entity m_target;


    public TaskRenderer()
    {
        initialize();
    }

    private void initialize()
    {
        m_target = Core.scene.createEntity(string.Format("Task Renderer {0}", m_taskRendererIndex));
        m_scheduleShowText = m_target.addComponent(new Text(Graphics.instance.bitmapFont, string.Format("{0}%", 0), Vector2.Zero, Color.Green));
        m_scheduleShowSprite = m_target.addComponent(new Sprite(Core.content.Load<Texture2D>("white block")));
        m_scheduleShowText.setLocalOffset(new Vector2(-m_scheduleShowText.width / 2.0f, -m_scheduleShowText.height / 2.0f));
        m_scheduleShowText.setLayerDepth(0);
        m_scheduleShowSprite.setLayerDepth(1);
    }

    public void SetPosition(Vector2 _position)
    {
        m_target.transform.position = _position;
    }

    public void SetSchedule(float _schedule)
    {
        _schedule = Mathf.clamp01(_schedule);
        RenderBySchedule(_schedule);

        if(_schedule >= 1.0f)
        {
            m_target.removeComponent(m_scheduleShowText);
        }
    }

    private void RenderBySchedule(float _schedule)
    {
        m_scheduleShowSprite.color = Color.White * _schedule;
        m_scheduleShowText.setText(string.Format("{0}%", (int)(_schedule * 100)));
    }

}

