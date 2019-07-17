using System;
using System.Collections.Generic;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            var shapes = new List<GraphicEditor>
            { new Rectangle(), new Circle(), new Square() };

            foreach (var item in shapes)
            {
                item.DrawShape();
            }
        }
    }
}
