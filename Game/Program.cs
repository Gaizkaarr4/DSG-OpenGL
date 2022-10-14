using OpenTK.Windowing.Desktop;
using System;
using GameEngine;

namespace OpenTKGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NativeWindowSettings settings = new NativeWindowSettings()
            {
                WindowState = OpenTK.Windowing.Common.WindowState.Normal,
                Size = new OpenTK.Mathematics.Vector2i(800, 600),
                Title = "My game",
                API = OpenTK.Windowing.Common.ContextAPI.OpenGL
            };
            Game game = new Game(settings);

            game.Run();

            game.Close();
        }
    }
}
