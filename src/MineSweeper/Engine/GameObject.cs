using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MineSweeper.Engine
{
    public class GameObject
    {
        public Texture2D texture;
        public Vector2 Position;
        public float LayerDepth;
        public GameObject(Texture2D _texture, Vector2 _position, float _layerDepth)
        {
            texture = _texture;
            Position = _position;
            LayerDepth = _layerDepth;
        }

        public void Update()
        {

        }
        public void Draw(SpriteBatch _spriteBath)
        {
            _spriteBath.Draw(texture, Position, Color.White);
        }
    }
}