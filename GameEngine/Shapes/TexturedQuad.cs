using GameEngine.Graphics;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Shapes
{
    public class TexturedQuad : GraphicObject
    {
        Texture Texture;


        public TexturedQuad(string objectName, string textureFilename, bool useAlphaBlending = false): base(objectName)
        {
            //TODO: See SimpleQuad.Draw()
        }

        public override void Draw()
        {
            //TODO: See SimpleQuad.Draw()
        }

    }
}
