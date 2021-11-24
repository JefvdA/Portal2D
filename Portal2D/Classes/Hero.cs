using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Portal2D.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Portal2D.Classes
{
    class Hero : IGameObject, IMovable
    {
        private Texture2D texture;
        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public IInputReader InputReader { get; set; }

        Animation animation;

        public Hero(Texture2D texture, IInputReader inputReader)
        {
            this.texture = texture;
            this.InputReader = inputReader;

            animation = new Animation();
            animation.GetFramesFromTextureProperties(texture.Width, texture.Height, 6, 1);

            Position = new Vector2(0, 100);
            Speed = new Vector2(1, 1);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, animation.CurrentFrame.SourceRectangle, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            animation.Update(gameTime);
            Move();
        }

        public void Move()
        {
            MovementManager.Move(this);
        }
        //public void ChangeInput(IInputReader inputReader)
        //{
        //    this.inputReader = inputReader;
        //}
    }
}
