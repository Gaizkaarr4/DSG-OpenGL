using GameEngine.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace FirstSteps
{
    public class TestGame : GameWindow
    {
        int BufferObjectId;
        int VertexArrayObjectId;
        int ProgramId;
        public TestGame(): base(new GameWindowSettings() , new NativeWindowSettings() { WindowState = WindowState.Normal })
        {
            //Create and initialize Vertex Array Object
            CreateVertexArrayObject();

            //Create shaders
            CompileShaders("..\\..\\..\\..\\GameEngine\\Shaders\\Position.vertex-shader", "..\\..\\..\\..\\GameEngine\\Shaders\\Position.fragment-shader");

            //General settings
            GL.ClearColor(Color.White);
            GL.Enable(EnableCap.DepthTest);
            
            //TODO: Create a transformation matrix and pass it to the shading program as a uniform variable
        }

        private void CreateVertexArrayObject()
        {
            //TODO: Create a vertex array object and initialize it with vertices
        }

        private void CompileShaders(string vertexShaderFilename, string fragmentShaderFilename)
        {
            //Create shader objects
            int vertexShaderId = GL.CreateShader(ShaderType.VertexShader);
            string vertexShaderSource = System.IO.File.ReadAllText(vertexShaderFilename);
            GL.ShaderSource(vertexShaderId, vertexShaderSource);

            int fragmentShaderId = GL.CreateShader(ShaderType.FragmentShader);
            string fragmentShaderSource = System.IO.File.ReadAllText(fragmentShaderFilename);
            GL.ShaderSource(fragmentShaderId, fragmentShaderSource);

            var error = GL.GetError();

            //Compile the shader
            GL.CompileShader(vertexShaderId);

            GL.GetShader(vertexShaderId, ShaderParameter.CompileStatus, out int success);
            if (success == 0)
            {
                string infoLog = GL.GetShaderInfoLog(vertexShaderId);
                Console.WriteLine(infoLog);
            }

            GL.CompileShader(fragmentShaderId);

            GL.GetShader(fragmentShaderId, ShaderParameter.CompileStatus, out success);
            if (success == 0)
            {
                string infoLog = GL.GetShaderInfoLog(fragmentShaderId);
                Console.WriteLine(infoLog);
            }

            //Create a program with both shaders
            ProgramId = GL.CreateProgram();

            GL.AttachShader(ProgramId, vertexShaderId);
            GL.AttachShader(ProgramId, fragmentShaderId);
            GL.LinkProgram(ProgramId);

            GL.GetProgram(ProgramId, GetProgramParameterName.LinkStatus, out success);
            if (success == 0)
            {
                string infoLog = GL.GetProgramInfoLog(ProgramId);
                Console.WriteLine(infoLog);
            }

            //Clean-up
            GL.DetachShader(ProgramId, vertexShaderId);
            GL.DetachShader(ProgramId, fragmentShaderId);
            GL.DeleteShader(fragmentShaderId);
            GL.DeleteShader(vertexShaderId);

            error = GL.GetError();
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            //Rendering
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.UseProgram(ProgramId);

            //TODO: Draw a triangle strip from the vertex array object we created before

            Context.SwapBuffers();

            OpenTK.Graphics.OpenGL.ErrorCode error = GL.GetError();
            base.OnRenderFrame(e);
        }

        protected override void OnKeyDown(KeyboardKeyEventArgs e)
        {
            if (e.Key == Keys.Escape)
                this.Close();

            base.OnKeyDown(e);
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            //TODO: What if e.Width != e.Height???

            GL.Viewport(0, 0, e.Width, e.Height);


            base.OnResize(e);
        }
    }
}
