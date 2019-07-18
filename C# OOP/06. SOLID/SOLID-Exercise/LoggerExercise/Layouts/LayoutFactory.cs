using LoggerExercise.Layouts.Contracts;
using LoggerExerciseExercise.Layouts;
using LoggerExerciseExercise.Layouts.Contracts;
using System;

namespace LoggerExercise.Layouts
{
    public class LayoutFactory : ILayoutFactory
    {
        public ILayout CreateLayout(string type)
        {
            string typeAsLower = type.ToLower();

            switch (typeAsLower)
            {
                case "simplelayout":
                    return new SimpleLayout();
                case "xmllayout":
                    return new XmlLayout();

                default:
                    throw new ArgumentException("Invalid layout type!");
            }
        }
    }
}
