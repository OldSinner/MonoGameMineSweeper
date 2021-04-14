using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MineSweeper.Engine;

namespace MineSweeper
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        List<GameObject> GameObjTitles = new List<GameObject>();

        Vector2[,] titles = new Vector2[10,10];

        int[,] minefield = new int[10,10];

        int minesSize= 30;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {

            base.Initialize();

            _graphics.PreferredBackBufferWidth = minesSize*10;  
            _graphics.PreferredBackBufferHeight = minesSize*10;   
            _graphics.ApplyChanges();
        }

        protected override void LoadContent()
        {
            minefield = Generator.GenerateMines(minefield,56);
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            for(int i = 0;i<10;i++)
            {
                for(int j=0;j<10;j++)
                {
                    if(minefield[i,j]==0)
                    {
                        GameObjTitles.Add(new GameObject(Content.Load<Texture2D>("blockzero"),new Vector2(j*minesSize,i*minesSize),0,0));
                    }
                    else
                    {
                        GameObjTitles.Add(new GameObject(Content.Load<Texture2D>("blockbomb"),new Vector2(j*minesSize,i*minesSize),0,0));
                    }
                    
                    titles[i,j] = new Vector2(j*minesSize,i*minesSize);
                }
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            Console.WriteLine("a");

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            

            foreach(var obj in GameObjTitles)
            {
                obj.Draw(_spriteBatch);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
