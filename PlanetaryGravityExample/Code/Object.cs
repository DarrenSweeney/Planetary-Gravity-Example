#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
#endregion

/*
 * The following code is created by Darren Sweeney.
 * Twitter: @NerdyNinja95
*/

namespace PlanetaryGravityExample
{
    abstract class Object
    {
        public Texture2D texture;
        public Vector2 position;
        public Vector2 center;
        public float radius;
        public float mass;
        public float scale;
        public Vector2 velocity;

        public Object(ContentManager content, String fileName, float objectScale)
        {
            texture = content.Load<Texture2D>(fileName);

            center = new Vector2(texture.Width / 2, texture.Height / 2);
            position = position + center; // Position is measured from the center of texture
            radius = texture.Width / 2;
            scale = objectScale;
        }

        public void UpdateGravity(Vector2 p2, float m2)
        {
            position += velocity * UniversalGravitation.force;
            UniversalGravitation.distance = Vector2.Distance(p2, position);
            UniversalGravitation.force =     (UniversalGravitation.gravitationalConstant * mass * m2) 
            //                             ____________________________________________________________
                                                     / (UniversalGravitation.distance * 10);

            UniversalGravitation.direction = (p2) - (position);
            UniversalGravitation.direction.Normalize();
            velocity += UniversalGravitation.direction * UniversalGravitation.force;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, position, null, Color.White, 0, Vector2.Zero, scale, SpriteEffects.None, 0);
            spriteBatch.End();
        }
    }
}