using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    public abstract class GraphicEditor
    {
        public void DrawShape()
        {
            Console.WriteLine($"I'm {GetType().Name}");
        }
    }
}
