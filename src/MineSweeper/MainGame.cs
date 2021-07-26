using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MineSweeper.Engine;

namespace MineSweeper
{
    public class MainGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        static int bombHeight = 20;
        static int bombWidth = 20;
        Mine[,] GameObjTitles = new Mine[bombHeight, bombWidth];
        List<Texture2D> textures = new List<Texture2D>();
        int minesSize = 30;
        bool pressed = false;


        public MainGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {

            base.Initialize();

            _graphics.PreferredBackBufferWidth = minesSize * bombWidth;
            _graphics.PreferredBackBufferHeight = minesSize * bombHeight;
            _graphics.ApplyChanges();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            var loader = new Loader();
            textures = loader.LoadTexture(Content);
            var minefield = Utility.GenerateMines(30, bombHeight, bombWidth);
            GameObjTitles = loader.LoadBombs(minefield, bombHeight, bombWidth, textures, minesSize);
        }

        protected override void Update(GameTime gameTime)
        {
            var mouseState = Mouse.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (mouseState.LeftButton == ButtonState.Pressed && !pressed)
            {
                var mousePosition = new Point(mouseState.X, mouseState.Y);
                foreach (var obj in GameObjTitles)
                {
                    if (!obj.area.Contains(mousePosition))
                    {
                        continue;
                    }
                    if (!obj.isRevelated)
                    {
                        obj.revealTitle(textures, GameObjTitles);
                    }
                    break;
                }
                pressed = true;
            }
            if (mouseState.LeftButton == ButtonState.Released)
            {
                pressed = false;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            foreach (var obj in GameObjTitles)
            {
                obj.Draw(_spriteBatch);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
