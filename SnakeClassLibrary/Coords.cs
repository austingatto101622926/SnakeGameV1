using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeClassLibrary
{
    public class Coords
    {
        public int X;
        public int Y;

        public Coords(int x, int y)
        {
            X = x;
            Y = y;
        }
        public static Coords operator +(Coords c1, Coords c2)
        {
            return new Coords(c1.X + c2.X, c1.Y + c2.Y);
        }
        public static Coords operator -(Coords c1, Coords c2)
        {
            return new Coords(c1.X - c2.X, c1.Y - c2.Y);
        }

        public static bool operator ==(Coords c1, Coords c2)
        {
            return (c1.X == c2.X && c1.Y == c2.Y);
        }

        public static bool operator !=(Coords c1, Coords c2)
        {
            return !(c1.X == c2.X && c1.Y == c2.Y);
        }

        public void Set(Coords coords)
        {
            X = coords.X;
            Y = coords.Y;
        }
    }
}
