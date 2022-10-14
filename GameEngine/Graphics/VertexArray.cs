using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Graphics
{
    public class VertexArray : IDisposable
    {
        public enum Format { Position, PositionAndColor, PositionAndTexture }

        int BufferObjectId;
        int VertexArrayObjectId;

        private int VertexSize(Format format)
        {
            //TODO: given a vertex format, return its size in bytes
            return 0;
        }

        public VertexArray(Format format, float[] vertices)
        {
            //TODO
        }

        public void Use()
        {
            //TODO
        }


        private bool disposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
                    GL.DeleteBuffer(BufferObjectId);
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
