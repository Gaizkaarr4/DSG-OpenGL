using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Core.Native;
using System.Drawing;
using GameEngine.Shapes;

namespace GameEngine.Graphics
{
    public class Renderer
    {
        List<GraphicObject> GraphicObjects = new List<GraphicObject>();
        public Renderer()
        {

        }

        public void AddObject(GraphicObject obj)
        {
            GraphicObjects.Add(obj);
        }

        public void RemoveObject(GraphicObject obj)
        {
            GraphicObjects.Remove(obj);
        }

        public void RemoveObjectByName(string name)
        {
            GraphicObject object2D = GraphicObjects.Find(obj => obj.Name == name);
            if (object2D != null)
                GraphicObjects.Remove(object2D);
        }

        public GraphicObject FindByName(string name)
        {
            return GraphicObjects.Find(obj => obj.Name == name);
        }

        public void DrawScene()
        {
            //Clear the back-buffer
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            //Draw the scene
            //Opaque objects first
            foreach (GraphicObject obj in GraphicObjects)
                if (obj.IsOpaque)
                    obj.Draw();
            //Then translucent objects
            foreach (GraphicObject obj in GraphicObjects)
                if (!obj.IsOpaque)
                    obj.Draw();
        }

        public void SetViewport(int xOffset, int yOffset, int width, int height)
        {
            GL.Viewport(xOffset, yOffset, width, height);
        }

        public void SetGlobalSettings()
        {
            GL.ClearColor(Color.White);
            GL.Enable(EnableCap.DepthTest);
        }
    }
}
