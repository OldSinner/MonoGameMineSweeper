using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MineSweeper.Engine
{
    public class Loader
    {
        public List<Texture2D> LoadTexture(ContentManager contentManager)
        {
            List<Texture2D> textures = new List<Texture2D>();
            textures.Add((contentManager.Load<Texture2D>("unblocked")));
            textures.Add((contentManager.Load<Texture2D>("blockzero")));
            textures.Add((contentManager.Load<Texture2D>("blockone")));
            textures.Add((contentManager.Load<Texture2D>("blocktwo")));
            textures.Add((contentManager.Load<Texture2D>("blockthree")));
            textures.Add((contentManager.Load<Texture2D>("blockfour")));
            textures.Add((contentManager.Load<Texture2D>("blockfive")));
            textures.Add((contentManager.Load<Texture2D>("blocksix")));
            textures.Add((contentManager.Load<Texture2D>("blockseven")));
            textures.Add((contentManager.Load<Texture2D>("blockeight")));
            textures.Add((contentManager.Load<Texture2D>("blockbomb")));
            return textures;
        }
        public Mine[,] LoadBombs(int[,] mines, int bombHeight, int bombWidth, List<Texture2D> textures, int minesSize)
        {
            var GameObjTitles = new Mine[bombHeight, bombWidth];
            for (int i = 0; i < bombHeight; i++)
            {
                for (int j = 0; j < bombWidth; j++)
                {
                    if (mines[i, j] == 10)
                    {
                        GameObjTitles[i, j] = new Mine(textures.Where(x => x.Name == "unblocked").First(), new Vector2(j * minesSize, i * minesSize), 0, true, mines[i, j], minesSize, i, j);
                    }
                    else
                    {
                        GameObjTitles[i, j] = new Mine(textures.Where(x => x.Name == "unblocked").First(), new Vector2(j * minesSize, i * minesSize), 0, true, mines[i, j], minesSize, i, j);
                    }
                }
            }
            return GameObjTitles;
        }

    }
}