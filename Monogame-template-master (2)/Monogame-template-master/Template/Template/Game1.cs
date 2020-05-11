using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Template.Classes;
using Microsoft.Xna.Framework.Content;
using System.IO;
using System;
using Microsoft.Xna.Framework.Media;


namespace Template
{
    //This is our game itself.
    public class Game1 : Game
    {
        public enum State
        {
            menu,
            Gameover,

        };


        //ascii for space, R and Escape.
        Keys start = (Keys)32;
        Keys reset = (Keys)82;
        Keys exit = (Keys)27;


        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        ClassBall ball;
        ClassRacket P1;
        ClassRacket P2;
        SpriteFont font;
        public Texture2D menuImage;
        public Texture2D GameoverImage;


        //The value of the score, The sizes of rackets hight and width, The size of the ball. 

        int scoreP1 = 0;
        int scoreP2 = 0;
        int racketWidth = 10;
        int racketHeight = 100;
        int ballSize = 10;
        public object sw;


        //Text file creats a file with the controllers for the player and game. 
        private void controls()

        {
            //The program will read from the ascii file and look at the nummbers and see which key it is suppose to take. 
            try
            {
                StreamReader sr = new StreamReader("ascii-codes.txt", true);
                string s = sr.ReadLine();

                start = (Keys)s[0];
                s = sr.ReadLine();
                reset = (Keys)s[0];
                s = sr.ReadLine();
                exit = (Keys)s[0];
                sr.Close();
            }

            //If it can't find the file than this message will pop up.
            catch
            {
                Console.WriteLine("Filen doesn't exist");

            }

        }

        //This is what manages the graphics of the game. 
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            GameoverImage = null;
            menuImage = null;
        }

        //
        protected override void Initialize()
        {

            base.Initialize();
        }


        protected override void LoadContent()
        {
            //The font for the scores that show. 
            font = Content.Load<SpriteFont>("font");

            //The balls size will be loaded from the ClassBall to the program. 
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ball = new ClassBall(GraphicsDevice, spriteBatch, this, ballSize);

            //Both players will be loaded from the ClassRacket to the program
            P1 = new ClassRacket(GraphicsDevice, spriteBatch, this, racketWidth, racketHeight, 10, GraphicsDevice.Viewport.Height / 2 - racketHeight / 2);
            P2 = new ClassRacket(GraphicsDevice, spriteBatch, this, racketWidth, racketHeight, GraphicsDevice.Viewport.Width - 10 - racketWidth, GraphicsDevice.Viewport.Height / 2 - racketHeight / 2);

            Components.Add(P1);
            Components.Add(P2);
            Components.Add(ball);

            ball.ResetBall();
            menuImage = Content.Load<Texture2D>("menyimage");
            GameoverImage = Content.Load<Texture2D>("Gameover");
        }

        //There is nothing here
        protected override void UnloadContent()
        {

        }

        //This is for what happens when the game is running.
        protected override void Update(GameTime gameTime)
        {
            //When Escape key is pressed it closes the game.
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //When the spacebar is pressed than the game will start and the ball will move.
            else if (Keyboard.GetState().IsKeyDown(Keys.Space) && !ball.gameRun)
            {
                ball.gameRun = true;

            }

            //When someone presses the key R it will reset.
            else if (Keyboard.GetState().IsKeyDown(Keys.R) && ball.gameRun)
            {
                ball.gameRun = false;
                ball.ResetBall();
            }

            //The paddles will move where the mouse is going.
            P1.posY = Mouse.GetState().Y;
            P2.posY = Mouse.GetState().Y;

            // Ball goes to P2
            if (ball.dirX > 0)
            {
                if (ball.posY >= P2.posY && ball.posY + ballSize < P2.posY + racketHeight && ball.posX >= P2.posX)
                {
                    ball.dirX = -ball.dirX;
                }

                //If it goes behind the paddle than a score will go for the player of the opposite pladdle
                else if (ball.posX >= GraphicsDevice.Viewport.Width - ballSize)
                {
                    scoreP1++;
                    ball.gameRun = false;
                    ball.ResetBall();
                }
            }
            // Ball goes to P1

            else if (ball.dirX < 0)
            {
                {
                    if (ball.posY >= P1.posY && ball.posY + ballSize <= P1.posY + racketHeight && ball.posX <= P1.posX + racketWidth)
                    {
                        ball.dirX = -ball.dirX;

                    }

                    //If it goes behind the paddle than a score will go for the player of the opposite pladdle
                    else if (ball.posX <= 0)
                    {
                        scoreP2++;
                        ball.gameRun = false;
                        ball.ResetBall();
                    }


                }

                 case Stat Gameover;
                {
                    KeyboardState keyState = Keyboard.GetState();
                    if (keyState.IsKeyDown(Keys.Escape))
                        gameState = State.menu;
                    break;
                }


                base.Update(gameTime);
            }
        }

        // This tells the program what to draw out when the game starts. 
        protected override void Draw(GameTime gameTime)
        {
            //The colour of the background
            GraphicsDevice.Clear(new Color(51, 51, 51));
            spriteBatch.Begin();
            //Draws out how the font of the score for both p1 and p2 will look like and what colour it will have. 
            spriteBatch.DrawString(font, scoreP1.ToString(), new Vector2(50, 50), new Color(45, 45, 45, 20));
            spriteBatch.DrawString(font, scoreP2.ToString(), new Vector2(GraphicsDevice.Viewport.Width - 250, 50), new Color(45, 45, 45, 20));
            //Ends when alla of them show up on the srceen. 
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
