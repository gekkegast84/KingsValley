using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Kingsvalley
{
    public class ExplorerIdleJumpRight : AnimatedSprite
    {
        //Fields
        private Explorer explorer;
        private float startX, startY, a, x;
        private int startH, startK, h, k;

        //Constructor
        public ExplorerIdleJumpRight(Explorer explorer, int h, int k)
            : base(explorer)
        {
            this.explorer = explorer;
            this.startK = k;
            this.startH = h;
            this.i = 0;
        }
        public void Initialize()
        {
            this.startX = this.explorer.Position.X;
            this.startY = this.explorer.Position.Y;
            this.h = (int)(this.startX + startH);
            this.k = (int)(this.startY - startK);
            this.a = this.CalculateA();
            this.x = this.startX;
        }

        private float CalculateA()
        {
            return (this.startY - this.k) / (float)Math.Pow((double)(this.startX - this.h), 2d);
        }

        //Update
        public override void Update(GameTime gameTime)
        {
            this.x = this.x + this.explorer.Speed;
            float y = (float)(this.a * Math.Pow((this.x - this.h), 2d) + this.k);
            float x = this.startX;

            this.explorer.Position = new Vector2(this.startX, y);
            if (this.explorer.Position.Y > this.startY)
            {
                this.explorer.State = this.explorer.IdleRight;
                this.explorer.Position = new Vector2(x, startY);
            }

            //base.Update(gameTime);
        }

        //Draw
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
