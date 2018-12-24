using Nez;
using Microsoft.Xna.Framework.Graphics;
using Nez.Sprites;
using Microsoft.Xna.Framework;

    public class MapAgrs
    {
        public static int MAP_WIDTH_LENGTH = 100;
        public static int MAP_HEIGHT_LENGTH = 100;

        public static int BLOCK_LENGTH = 10;

    }

    public class Map
    {
        private int[,] mapContent = new int[MapAgrs.MAP_HEIGHT_LENGTH, MapAgrs.MAP_WIDTH_LENGTH];

        private Entity m_mapRootNode;

        private Vector2 GetBlockPosition(int _row, int _col)
        {
            Vector2 ret = Vector2.Zero;
            ret.X = (_col + 0.5f) * MapAgrs.BLOCK_LENGTH;
            ret.Y = (_row + 0.5f) * MapAgrs.BLOCK_LENGTH;
            return ret;
        }

        private void initialize()
        {
            m_mapRootNode = Core.scene.createEntity("m_mapRootNode");
            m_mapRootNode.transform.position = Vector2.Zero;

            for(int row = 0; row < MapAgrs.MAP_HEIGHT_LENGTH; row++)
            { 
                for(int col = 0; col < MapAgrs.MAP_WIDTH_LENGTH; col++)
                {
                    var block = Core.scene.createEntity("Map Block");
                    block.setParent(m_mapRootNode.parent);
                    block.transform.localPosition = GetBlockPosition(row, col);
                    int ret = Random.nextInt(2);
                    switch(ret)
                    {
                        case 0:
                            block.addComponent(new Sprite(Core.content.Load<Texture2D>("white block")));
                            break;

                        case 1:
                            block.addComponent(new Sprite(Core.content.Load<Texture2D>("black block")));
                            break;
                    }
                }
            }
        }

        public Map()
        {
            initialize();
        }
    }

