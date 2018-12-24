using Nez;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez.Sprites;
using Microsoft.Xna.Framework.Input;

class PlayerArgs
{
    public static float m_playerMoveSpeed = 200.0f;
}

class PlayerController : Controller
{
    private Entity target;
    private Entity CreateTarget()
    {
        var ret = Core.scene.createEntity("Main Player");
        var sprite = ret.addComponent(new Sprite(Core.content.Load<Texture2D>("white block")));
        sprite.color = Color.Red;
        ret.transform.position = Globals.WINDOW_CENTER;
        ret.transform.scale = Vector2.One * 5.0f;
        return ret;
    }

    public override void initialize()
    {
        target = CreateTarget();
    }

    public override void update()
    {
        if (Input.isKeyPressed(Keys.Left))
        {
            Fire(BulletControllerComponent.BULLET_DIRECTION.LEFT);
        }
        else if (Input.isKeyPressed(Keys.Right))
        {
            Fire(BulletControllerComponent.BULLET_DIRECTION.RIGHT);
        }
        else if (Input.isKeyPressed(Keys.Up))
        {
            Fire(BulletControllerComponent.BULLET_DIRECTION.UP);
        }
        else if (Input.isKeyPressed(Keys.Down))
        {
            Fire(BulletControllerComponent.BULLET_DIRECTION.DOWN);
        }

        if (Input.isKeyDown(Keys.A))
        {
            target.transform.position += new Vector2(-1.0f, 0.0f) * Time.deltaTime * PlayerArgs.m_playerMoveSpeed;
        }

        if (Input.isKeyDown(Keys.D))
        {
            target.transform.position += new Vector2(1.0f, 0.0f) * Time.deltaTime * PlayerArgs.m_playerMoveSpeed;
        }

        if (Input.isKeyDown(Keys.W))
        {
            target.transform.position += new Vector2(0.0f, -1.0f) * Time.deltaTime * PlayerArgs.m_playerMoveSpeed;
        }

        if (Input.isKeyDown(Keys.S))
        {
            target.transform.position += new Vector2(0.0f, 1.0f) * Time.deltaTime * PlayerArgs.m_playerMoveSpeed;
        }
    }

    private void Fire(BulletControllerComponent.BULLET_DIRECTION _direction)
    {
        var bullet = PoolManager.Bullets.Pop();
        bullet.transform.position = target.transform.position;
        bullet.getComponent<BulletControllerComponent>().Direction = _direction;
    }
}

