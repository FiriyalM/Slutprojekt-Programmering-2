using System;

namespace Template
{
#if WINDOWS || LINUX
    
    //This whole thing starts the game and keeps it running. 
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Game1())
                game.Run();
        }
    }
#endif
}
