using System;
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
        public int column { get; set; }
        public int row { get; set; }
        public Mine(Texture2D _texture, Vector2 _position, float _layerDepth, bool _isBomb, int _type, int size, int column, int row) : base(_texture, _position, _layerDepth)
        {
            isBomb = _isBomb;
            type = _type;
            area = new Rectangle((int)Position.X, (int)Position.Y, size, size);
            this.column = column;
            this.row = row;
        }
        public void revealTitle(List<Texture2D> textures, Mine[,] gameObjects, bool clicked)
        {
            if (isRevelated) return;
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
            if (type == 0 && clicked)
            {
                bool reveletedAll = false;
                while (!reveletedAll)
                {
                    Console.WriteLine("ok");
                    reveletedAll = !RevealNear(gameObjects, textures);
                }
            }
            RevealNear(gameObjects, textures);

        }
        public bool RevealNear(Mine[,] gameObjects, List<Texture2D> textures)
        {
            bool reveal = false;
            for (int i = 0; i < gameObjects.GetLength(0); i++)
            {
                for (int j = 0; j < gameObjects.GetLength(1); j++)
                {
                    if (gameObjects[i, j].isRevelated || gameObjects[i, j].isBomb)
                    {
                        continue;
                    }
                    if (i - 1 >= 0)
                    {
                        var obj = gameObjects[i - 1, j];
                        if (obj.isRevelated && !obj.isBomb && obj.type == 0)
                        {
                            gameObjects[i, j].revealTitle(textures, gameObjects, false);
                            reveal = true;
                        }
                    }
                    if (i + 1 < gameObjects.GetLength(0))
                    {
                        {
                            var obj = gameObjects[i + 1, j];
                            if (obj.isRevelated && !obj.isBomb && obj.type == 0)
                            {
                                gameObjects[i, j].revealTitle(textures, gameObjects, false);
                                reveal = true;
                            }

                        }
                    }
                    if (j - 1 >= 0)
                    {
                        var obj = gameObjects[i, j - 1];
                        if (obj.isRevelated && !obj.isBomb && obj.type == 0)
                        {
                            gameObjects[i, j].revealTitle(textures, gameObjects, false);
                            reveal = true;
                        }
                    }
                    if (j + 1 < gameObjects.GetLength(1))
                    {
                        {
                            var obj = gameObjects[i, j + 1];
                            if (obj.isRevelated && !obj.isBomb && obj.type == 0)
                            {
                                gameObjects[i, j].revealTitle(textures, gameObjects, false);
                                reveal = true;
                            }
                        }
                    }
                }
            }
            return reveal;
        }
    }
}
