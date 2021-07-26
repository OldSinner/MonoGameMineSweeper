using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MineSweeper.Engine
{
    public class Mine : GameObject
    {
        public bool isBomb { get; set; }
        public int type { get; set; }
        public Rectangle area { get; }
        public bool isRevelated { get; set; }


        public Mine(Texture2D _texture, Vector2 _position, float _layerDepth, bool _isBomb, int _type, int size) : base(_texture, _position, _layerDepth)
        {
            isBomb = _isBomb;
            type = _type;
            area = new Rectangle((int)Position.X, (int)Position.Y, size, size);
        }
        public void revealTitle(List<Texture2D> textures)
        {
            var texturename = "";
            switch (type)
            {
                case 0:
                    texturename = "blockzero";
                    break;
                case 1:
                    texturename = "blockone";
                    break;
                case 2:
                    texturename = "blocktwo";
                    break;
                case 3:
                    texturename = "blockthree";
                    break;
                case 4:
                    texturename = "blockfour";
                    break;
                case 5:
                    texturename = "blockfive";
                    break;
                case 6:
                    texturename = "blocksix";
                    break;
                case 7:
                    texturename = "blockseven";
                    break;
                case 8:
                    texturename = "blockeight";
                    break;
                case 10:
                    texturename = "blockbomb";
                    break;
            }
            texture = textures.Where(x => x.Name == texturename).First();
            isRevelated = true;
        }
    }
}