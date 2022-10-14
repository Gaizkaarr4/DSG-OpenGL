using GameEngine.Graphics;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Shapes
{
    public class SimpleQuad : GraphicObject
    {
        float[] Vertices =
        {
            -1, -1, 0,   //Bottom-left vertex
            1, -1, 0,    //Bottom-right vertex
            -1, 1, 0,     //Top-left vertex
            1,  1, 0,    //Top-right vertex
           
        };

        public SimpleQuad(string objectName) : base(objectName)
        {
            VertexArray = new VertexArray(VertexArray.Format.Position, Vertices);

            Shader = new Graphics.Shader("..\\..\\..\\..\\GameEngine\\Shaders\\Position.vertex-shader", "..\\..\\..\\..\\GameEngine\\Shaders\\Position.fragment-shader");
        }

        public override void Draw()
        {
            //Set the shader
            Shader.Use();

            //Pass the transformation to the shader as a uniform parameter
            SetTransformation();

            //Set the vertex array object
            VertexArray.Use();

            //Draw
            GL.DrawArrays(PrimitiveType.TriangleStrip, 0, 4);
        }
    }
}
