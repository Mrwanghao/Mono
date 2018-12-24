using Nez;
using Microsoft.Xna.Framework;


public class BulletControllerComponent : Nez.Component, IUpdatable
{
    private static float DEFAULT_LIFE_LENGTH = 2.0f;
    private static float m_moveSpeed = 1000.0f;
    private float m_lifeLength = DEFAULT_LIFE_LENGTH;

    public void update()
    {
        m_lifeLength -= Time.deltaTime;
        //Console.WriteLine("bullet = " + entity.ToString() + " ,bullet time = " + m_lifeLength);
        
        if (m_lifeLength <= 0.0f)
        {
            m_lifeLength = DEFAULT_LIFE_LENGTH;
            PoolManager.Bullets.Push(entity);
        }

        transform.position += m_directionVec2D * Time.deltaTime * m_moveSpeed;

    }

    public void SetDefaultStatus()
    {
        m_lifeLength = DEFAULT_LIFE_LENGTH;
    }

    public enum BULLET_DIRECTION
    { 
        LEFT,
        RIGHT,
        UP,
        DOWN
    }

    private BULLET_DIRECTION m_direction;
    public BULLET_DIRECTION Direction
    {
        get { return m_direction; }
        set 
        {
            m_direction = value;
            m_directionVec2D = GetDirectionVec2D();
        }
    }

    private Vector2 m_directionVec2D;
    private Vector2 GetDirectionVec2D()
    {
        Vector2 ret = Vector2.Zero;
        switch(Direction)
        {
            case BULLET_DIRECTION.DOWN:
                ret = new Vector2(0.0f, 1.0f);
                break;

            case BULLET_DIRECTION.UP:
                ret = new Vector2(0.0f, -1.0f);
                break;

            case BULLET_DIRECTION.LEFT:
                ret = new Vector2(-1.0f, 0.0f);
                break;

            case BULLET_DIRECTION.RIGHT:
                ret = new Vector2(1.0f, 0.0f);
                break;
        }
        return ret;
    }
}

