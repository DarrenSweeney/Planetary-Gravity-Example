using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
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
    class SolarSystem
    {
        Player player;
        List<Planet> planets = new List<Planet>();

        public SolarSystem(ContentManager content)
        {
            player = new Player(content, 10, new Vector2(200, 100), 0.2f);

            planets.Add(new Planet(content, 20, new Vector2(750, 200), 0.45f));
            planets.Add(new Planet(content, 20, new Vector2(100, 400), 0.45f));
        }

        public void Update()
        {
            player.Update();

            foreach(Planet p in planets)
            {
                player.UpdateGravity(p.position, p.mass);
                p.UpdateGravity(player.position, player.mass);

                // Planets pull of each other.
                foreach (Planet op in planets)
                {
                    if (p.Equals(op))
                        break;

                    p.UpdateGravity(op.position, op.mass);
                    op.UpdateGravity(p.position, p.mass);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            player.Draw(spriteBatch);

            for (int i = 0; i < planets.Count(); i++)
                planets[i].Draw(spriteBatch);
        }
    }
}