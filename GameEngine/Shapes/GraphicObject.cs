using GameEngine.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Reflection.Metadata;
using System.Text;
using System.Xml.Linq;

namespace GameEngine.Shapes
{
    public abstract class GraphicObject
    {
        public string Name { get; private set; }
        public float PositionX { get; set; }
        public float PositionY { get; set; }
        public float PositionZ { get; set; }

        public float Scale { set { ScaleX = value; ScaleY = value; } }
        public float ScaleX { get; set; }
        public float ScaleY { get; set; }

        public float Rotation { get; set; }

        public bool IsOpaque { get; protected set; }
        
        protected Shader Shader;
        protected VertexArray VertexArray;

        public GraphicObject(string name)
        {
            Scale = 1.0f; //Default value
            Name = name;
        }

        public abstract void Draw();

        protected void SetTransformation()
        {
            //TODO: Create the object's transformation matrix and pass it as a uniform matrix
        }

    }
}
