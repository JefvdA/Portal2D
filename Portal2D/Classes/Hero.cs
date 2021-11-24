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
        private MovementManager movementManager;
        public Vector2 position { get; set; }

        public IInputReader inputReader { get; set; }

        Animation animation;

        public Hero(Texture2D texture, IInputReader inputReader, MovementManager movementManager)
        {
            this.texture = texture;
            this.inputReader = inputReader;
            this.movementManager = movementManager;

            animation = new Animation();
            animation.GetFramesFromTextureProperties(texture.Width, texture.Height, 6, 1);

            position = new Vector2(0, 100);
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
            movementManager.Move(this);
        }
        //public void ChangeInput(IInputReader inputReader)
        //{
        //    this.inputReader = inputReader;
        //}
    }
}
