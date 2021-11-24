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
    class Hero : IGameObject,IMovable
    {
        private Texture2D texture;
        private Vector2 position ;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        private IInputReader inputReader;

        public IInputReader InputReader
        {
            get { return inputReader; }
            set { inputReader = value; }
        }

        Animation animation;

        public Hero(Texture2D texture, IInputReader inputReader)
        {
            this.texture = texture;
            this.inputReader = inputReader;

            animation = new Animation();
            animation.GetFramesFromTextureProperties(texture.Width, texture.Height, 6, 1);

            position = new Vector2(0, 0);
            //speed = new Vector2(0, 0);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, animation.CurrentFrame.SourceRectangle, Color.White);
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
