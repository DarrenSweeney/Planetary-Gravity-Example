using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

/*
 * The following code is created by Darren Sweeney.
 * Twitter: @NerdyNinja95
*/

namespace PlanetaryGravityExample
{
    class Planet : Object
    {
        public Planet(ContentManager content, float objectMass, Vector2 objectPos, float objectScale)
            : base(content, "Planet", objectScale)
        {
            mass = objectMass;
            position = objectPos;
        }
    }
}