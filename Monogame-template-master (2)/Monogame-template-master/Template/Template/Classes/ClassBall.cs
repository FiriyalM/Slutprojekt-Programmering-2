using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Template.Classes
{
    class ClassBall : ClassRacket
    {
        //This helps to get our figures draw into the program

        Random rnd;

        //It shows the position and draws out the ball 

        int ballSize;

        public int speed { get; set; } = 1;
        public bool gameRun { get; set; }
        public int dirX { get; set; }
        public int dirY { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }

    
        //This is whole rows of codes below is for drawing out the ball to the program so we can see it. 
        //It even shows how big the boll is suppose to be like so you have a rough idea of how big the ball will end up before starting the game.
        public ClassBall(GraphicsDevice graphics, SpriteBatch spriteBatch, Game game, int ballSize) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.graphics = graphics;
            this.ballSize = ballSize;

            pixel = new Texture2D(graphics, 1, 1);
            pixel.SetData(new Color[] { Color.White });

         //This one is what makes the ball's movement in a unpredictable pattern when the game is running. 
            rnd = new Random();

        }
        //Everytime the ball goes through any side of the 
        public void ResetDirection()
        {
            do
            {
                dirX = rnd.Next(-10, 10);
            } while (dirX == 0);

            do
            {
                dirY = rnd.Next(-10, 10);
            } while (dirY == 0);


        }


        //This rows of code under is for when the ball is suppose to show and that is when the game starts.
        //Row 48 it's for the sprites to show when the program is running and row 50 is for when the proogram ends.
        //Row 52 is for the sprite to update when the game is running.  

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(pixel, new Rectangle(posX, posY, ballSize, ballSize), Color.White);

            spriteBatch.End();
            base.Draw(gameTime);
        }

        //Don't foroget that the rows change the more code you add!!

        public void ResetBall()

        {
            posX = graphics.Viewport.Width / 2 - ballSize / 2;
            posY = graphics.Viewport.Height / 2 - ballSize / 2;
            ResetDirection();


        }

        //When the ball interacts with the an objekt it will go the other way. 
        public void CheckWallColision()
        {
            if (posY <= 0 || posY + ballSize > graphics.Viewport.Height)
            {
                dirY = -dirY;
            }
        }

        public void CheckRacketColision(ClassRacket Player)
        {
           

        }

        //This is when the game starts the ball will have the same speed througout the game. From start to finish. 
        //And that it updates efter every small change that happens in the game like a movement. 
        public override void Update(GameTime gameTime)
        {
            if (gameRun)
            {
                posX += dirX * speed;
                posY += dirY * speed;

                CheckWallColision();
            }
            base.Update(gameTime);
        }
    }
}
