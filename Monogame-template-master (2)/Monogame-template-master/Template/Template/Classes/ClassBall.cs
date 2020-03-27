using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Template.Classes
{
    class ClassBall : DrawableGameComponent
    {
        //This helps to get our figures draw into the program

        SpriteBatch spriteBatch;
        GraphicsDevice graphics;
        Texture2D pixel;

        //It shows the position and draws out the ball 
        
        int ballSize;

        public int dirX { get; set; }
        public int dirY { get; set; }
        public int posX { get; set; }
        public int posY { get; set; }


        //This is whole rows of codes below is for drawing out the ball to the program so we can see it. 
        //It even shows how big the boll is suppose to be like so you have a rough idea of how big the ball will end up before starting the game.
        public ClassBall(GraphicsDevice graphics, SpriteBatch spriteBatch, Game game, int ballSize) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.graphics = graphics;
            this.ballSize = ballSize;

            pixel = new Texture2D(graphics, 1, 1);
            pixel.SetData(new Color[] { Color.White });

        }


        //This rows of code under is for when the ball is suppose to show and that is when the game starts.
        //In the last two rows is for so 
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(pixel, new Rectangle(posX, posY, ballSize, ballSize), Color.White);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
