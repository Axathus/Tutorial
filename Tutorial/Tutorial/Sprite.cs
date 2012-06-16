using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Tutorial
{
    public class Sprite
    {
        private Texture2D texture;
        private Vector2 position;
        private Vector2 speed = new Vector2(50.0f, 50.0f);
        private Vector2 scale;
        private Color tint;
        private Vector2 origin = Vector2.Zero;

        public Vector2 Position
        {
            get;
            set;
        }

        public Vector2 Scale
        {
            get;
            set;
        }

        public Color Tint
        {
            get;
            set;
        }

        public Sprite(ContentManager content, string source, Vector2 position, Vector2 scale, Color tint)
        {
            texture = content.Load<Texture2D>(source);  //unsure - use of field 'source'
            this.position = position;
            this.scale = scale;
            this.tint = tint;
        }

        public Sprite(ContentManager content, string source, Vector2 position, Vector2 scale, Color tint, Vector2 origin)
        {
            texture = content.Load<Texture2D>(source);  //unsure - use of field 'source'
            this.position = position;
            this.scale = scale;
            this.tint = tint;
            this.origin = origin;
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(texture, position, null, tint, 0, origin, scale, SpriteEffects.None, 0);
        }

        public void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            // Move the sprite by speed, scaled by elapsed time.
            position += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            Color tint = new Color(
                ((float)(Math.Sin(gameTime.TotalGameTime.TotalSeconds * 1.1) + 1) / 2),
                ((float)(Math.Sin(gameTime.TotalGameTime.TotalSeconds * 1.2) + 1) / 2),
                ((float)(Math.Sin(gameTime.TotalGameTime.TotalSeconds * 1.3) + 1) / 2));

            this.tint = tint;

            /*
            float MaxX =
                graphics.GraphicsDevice.Viewport.Width - (myTexture.Width * scale);
            float MinX = 0;
            float MaxY =
                graphics.GraphicsDevice.Viewport.Height - (myTexture.Height * scale);
            float MinY = 0;
            */

            int MaxX = graphics.GraphicsDevice.Viewport.Width - (int)(texture.Width * scale.X);
            int MinX = 0;
            int MaxY = graphics.GraphicsDevice.Viewport.Height - (int)(texture.Height * scale.Y);
            int MinY = 0;

            // Check for bounce.
            if (position.X > MaxX)
            {
                speed.X *= -1;
                position.X = MaxX;
            }

            else if (position.X < MinX)
            {
                speed.X *= -1;
                position.X = MinX;
            }

            if (position.Y > MaxY)
            {
                speed.Y *= -1;
                position.Y = MaxY;
            }

            else if (position.Y < MinY)
            {
                speed.Y *= -1;
                position.Y = MinY;
            }
        }
    }
}
