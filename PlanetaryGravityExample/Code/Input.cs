using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * The following code is created by Darren Sweeney.
 * Twitter: @NerdyNinja95
*/

namespace PlanetaryGravityExample
{
    static class Input
    {
        private static KeyboardState keyboardState;

        public static void Update()
        {
            keyboardState = Keyboard.GetState();
        }

        public static Vector2 GetMovementDirection()
        {
            Vector2 direction = Vector2.Zero; 

            if (keyboardState.IsKeyDown(Keys.A))
                direction.X -= 1;
            if (keyboardState.IsKeyDown(Keys.D))
                direction.X += 1;
            if (keyboardState.IsKeyDown(Keys.W))
                direction.Y -= 1;
            if (keyboardState.IsKeyDown(Keys.S))
                direction.Y += 1;

            // Clamp the length of the vector to a maximum of 1.
            if (direction.Length() > 1)
                direction.Normalize();

            return direction;
        }
    }
}