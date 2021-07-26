using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MineSweeper.Engine
{
    public class Mine : GameObject
    {
        public bool isBomb { get; set; }
        public Mine(Texture2D _texture, Vector2 _position, float _layerDepth, int _type, bool _isBomb) : base(_texture, _position, _layerDepth, _type)
        {
            isBomb = _isBomb;
        }
    }
}