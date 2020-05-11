using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Template.Classes
{
        //This where you write all the codes and where the class begins.
    class ClassRacket : DrawableGameComponent
    {
        //This is what helps us to draw out our paddles.
        protected SpriteBatch spriteBatch;
        protected GraphicsDevice graphics;
        protected Texture2D pixel;

        //The size of the players.
        
        int width;
        int height;

        public Game game;
        public int posY { get; set; }
        public int posX { get; set; }

        //This codes is what decides how the paddles will look like and where they will end up on the game.
        public ClassRacket(GraphicsDevice graphics, SpriteBatch spriteBatch, Game game, int width, int height, int posX, int posY) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.graphics = graphics;
            this.posX = posX;
            this.posY = posY;
            this.height = height;
            this.width = width;
           
            //The colour of the paddles. 
            pixel = new Texture2D(graphics, 1, 1);
            pixel.SetData(new Color[] { Color.White });

        }

        public ClassRacket(Game game) : base(game)
        {
            this.game = Game;

        }

        //This is what keeps the game up to date, like what position the paddle or the ball goes as well as when the game starts or ends.
        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }
        //The codes down here are for to tell that when the game starts it will draw out the paddles, also where they will be. Basically draw out every code we have up there
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(pixel, new Rectangle(posX, posY, width, height), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}