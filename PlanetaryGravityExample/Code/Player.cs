using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

/*
 * The following code is created by Darren Sweeney.
 * Twitter: @NerdyNinja95
*/

namespace PlanetaryGravityExample
{
    class Player : Object
    {
        public Player(ContentManager content, float objectMass, Vector2 objectPos, float objectScale)
            : base (content, "Player", objectScale)
        {
            mass = objectMass;
            position = objectPos;
        }

        public void Update()
        {
            Input.Update();
            velocity += Input.GetMovementDirection();
        }
    }
}