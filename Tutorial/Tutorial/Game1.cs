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

namespace Tutorial
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;

        SpriteFont StandardFont;
        Vector2 FontPos;

        SpriteFont spriteFont;
        SpriteBatch spriteBatch;

        List<Sprite> sprites = new List<Sprite>();
        Vector2 scale = new Vector2(0.75f);      // fixme

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }


        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            StandardFont = Content.Load<SpriteFont>("Axathus Standard");

            // Create my first sprite

            Vector2 position = Vector2.Zero;
                /* This is the starting position, and not where the scale and rotation is done
                 * Check the other Vector2 field "origin" in Sprite.cs for scale position, etc
                 */
            Vector2 scale = new Vector2(0.75f);     // Think of it as a %... 75%
            Color tint = Color.White;
            Sprite mySprite = new Sprite(Content, "yumi", position, scale, tint);
            sprites.Add(mySprite);

            // Create my second sprite

            Vector2 position2 = new Vector2(1.0f);
            Vector2 scale2 = new Vector2(1.0f);
            Color tint2 = Color.Tomato;     // 'cause tomatoes. You jelly?
            Vector2 origin2 = new Vector2(100.0f);
            Sprite mySprite2 = new Sprite(Content, "yumi", position, scale, tint, origin2);  // I like using Yumi, you mad?
            sprites.Add(mySprite2);

            // TODO: use this.Content to load your game content here
            FontPos = new Vector2(  graphics.GraphicsDevice.Viewport.Width / 2,
                                    graphics.GraphicsDevice.Viewport.Height / 2);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            foreach (Sprite sprite in sprites)
            {
                sprite.Update(gameTime, graphics);

            }
            
            //sprites.ElementAt(0).Update(gameTime,graphics);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            graphics.GraphicsDevice.Clear(Color.CornflowerBlue);

            // Draw the sprite.

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            
            foreach (Sprite sprite in sprites)
            {
                sprite.Draw(spriteBatch);
            }

            string output = "Hello World";

            Vector2 FontOrigin = StandardFont.MeasureString(output) / 2;
            spriteBatch.DrawString(StandardFont, output, FontPos, Color.AliceBlue,
                                    0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);

            //sprites.ElementAt(0).Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
