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
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace Kingsvalley
{
    public class KingsValley : Microsoft.Xna.Framework.Game
    {
        //FIELDS
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Explorer explorer;

        //PROPERTIES
        public SpriteBatch SpriteBatch
        {
            get { return this.spriteBatch; }
        }

        //CONSTRUCTOR
        public KingsValley()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        //INITIALIZE METHOD
        protected override void Initialize()
        {
            IsMouseVisible = true;
            this.Window.Title = "KingsValley Beta";
            this.graphics.PreferredBackBufferWidth = 640;
            this.graphics.PreferredBackBufferHeight = 480;
            this.graphics.ApplyChanges();

            base.Initialize();
        }
        //LOADCONTENT METHOD
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            this.explorer = new Explorer(this, new Vector2(100f, 300f));
        }

        //UNLOADCONTENT METHOD
        protected override void UnloadContent()
        {

        }
        //UPDATE
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            Input.Update();
            this.explorer.Update(gameTime);
            base.Update(gameTime);
        }
        //DRAW
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(6,6,6));
            this.spriteBatch.Begin();
            this.explorer.Draw(gameTime);
            this.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
