using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Core.Native;
using System;
using System.Collections.Generic;
using System.Text;
using GameEngine.Shapes;
using GameEngine.Graphics;
using GameEngine;
using GameEngine.Sounds;

namespace OpenTKGame
{
    public class Game : GameWindow
    {
        Renderer Renderer;

        
        public Game(NativeWindowSettings settings) : base(GameWindowSettings.Default, settings)
        {
            Renderer = new Renderer();

            Renderer.AddObject(new TexturedQuad("Background", "..\\..\\..\\..\\img\\bg.jpg") { PositionZ = 0.9f});
            Renderer.AddObject(new SimpleQuad("Simple quad") { PositionX = -0.2f, PositionY = -0.2f, PositionZ = 0.5f, Scale = 0.2f });
            Renderer.AddObject(new ColoredQuad("Colored quad") { PositionX = 0.2f, PositionY = 0.2f, PositionZ = 0.6f, Scale = 0.2f });
            Renderer.AddObject(new TexturedQuad("Alien-2", "..\\..\\..\\..\\img\\alien-02.png", true) { PositionX = 0.5f, PositionY = 0.5f, PositionZ = -0.3f, Scale = 0.2f });
            Renderer.AddObject(new TexturedQuad("Alien", "..\\..\\..\\..\\img\\alien-01.png", true) { PositionX = -0.5f, PositionY = -0.5f, PositionZ = -0.3f, Scale = 0.2f, Rotation = 45 });

        }

        protected override void OnResize(ResizeEventArgs e)
        {
            //TODO: What if e.Width != e.Height???

            Renderer.SetViewport(0, 0, e.Width, e.Height);

            base.OnResize(e);
        }


        protected override void OnRenderFrame(FrameEventArgs e)
        {
            Renderer.DrawScene();

            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }

        protected override void OnKeyDown(KeyboardKeyEventArgs e)
        {
            if (e.IsRepeat)
                return;

            //TODO: Map keys and actions

            base.OnKeyDown(e);
        }

        protected override void OnLoad()
        {
            Renderer.SetGlobalSettings();

            base.OnLoad();
        }
    }
}
