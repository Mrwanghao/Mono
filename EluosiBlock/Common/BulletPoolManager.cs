using System.Collections.Generic;
using Nez;
using Nez.Sprites;
using Microsoft.Xna.Framework.Graphics;


    public class BulletPoolManager
    {
        private Queue<Entity> contents;
        private static int BASE_CONTENTS_LENGTH = 10;

        private static int m_bulletIndex = 0;

        public BulletPoolManager()
        {
            contents = new Queue<Entity>();
            for(int i = 0; i < BASE_CONTENTS_LENGTH; i++)
            {
                Push(CreateBullet());
            }
        }

        private Entity CreateBullet()
        {
            var element = Core.scene.createEntity(string.Format("bullet {0}", m_bulletIndex));
            m_bulletIndex++;
            element.addComponent(new Sprite(Core.content.Load<Texture2D>("white block")));
            element.addComponent(new BulletControllerComponent());
            return element;
        }

        public void Push(Entity element)
        {
            element.setEnabled(false);
            contents.Enqueue(element);
        }

        public Entity Pop()
        { 
            if(contents.Count == 0)
            {
                return CreateBullet();
            }

            var element = contents.Dequeue();
            element.setEnabled(true);
            element.getComponent<BulletControllerComponent>().SetDefaultStatus();
            return element;
        }
    }

