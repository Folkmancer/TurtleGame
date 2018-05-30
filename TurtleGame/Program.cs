using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SmallBasic.Library;

namespace TurtleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int X = 200, Y = 200, count = 0,
               borderStartX = 20, borderStartY = 20,
               borderEndX = GraphicsWindow.Width - 40,
               bordersEndY = GraphicsWindow.Height - 40;

            GraphicsWindow.DrawRectangle(borderStartX, borderStartY, borderEndX, bordersEndY);
            GraphicsWindow.DrawBoundText(5, 5, 200, "0");
            GraphicsWindow.KeyDown += GraphicsWindow_KeyDown;
            Turtle.PenUp();
            var eat = Shapes.AddRectangle(10, 10);
            Shapes.Move(eat, X, Y);
            Random rand = new Random();
            while (true)
            {
                Turtle.Move(10);
                if ((Turtle.X <= borderStartX || Turtle.X >= borderEndX) || (Turtle.Y <= borderStartY || Turtle.Y >= bordersEndY)) break;
                if ((Turtle.X >= X && Turtle.X <= X + 10) && (Turtle.Y >= Y && Turtle.Y <= Y + 10))
                {
                    X = rand.Next(30, GraphicsWindow.Width - 50);
                    Y = rand.Next(30, GraphicsWindow.Height - 50);
                    Shapes.Move(eat, X, Y);
                    count++;
                    GraphicsWindow.BrushColor = "white";
                    GraphicsWindow.FillRectangle(4, 4, 12, 12);
                    GraphicsWindow.BrushColor = "black";
                    GraphicsWindow.DrawBoundText(5, 5, 200, count.ToString());
                }
                if (count > 3)
                {
                    GraphicsWindow.ShowMessage("Victory","You won!");
                    break;
                }
            }
        }

        private static void GraphicsWindow_KeyDown()
        {
            if (GraphicsWindow.LastKey == "Up") Turtle.Angle = 0;
            else if (GraphicsWindow.LastKey == "Right") Turtle.Angle = 90;
            else if (GraphicsWindow.LastKey == "Down") Turtle.Angle = 180;
            else if (GraphicsWindow.LastKey == "Left") Turtle.Angle = 270;
        }
    }
}
