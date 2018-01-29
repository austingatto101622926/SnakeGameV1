using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeClassLibrary
{
    public class Snake
    {
        public  enum SegmentType { Head, Body, Tail};
        public  enum Direction { N, E, S, W };

        public Direction CurrentDirection;

        public char[,] Character = new char[,] 
        {
            {'N','E','S','W' },    //Head: N, E, S, W
            {'#','#','#','#' },    //Body: N, E, S, W
            {'v','<','^','>' }     //Tail: N, E, S, W
        };

        private Coords[] Velocity = new Coords[]
        {
            new Coords(0,-1), new Coords(1, 0), new Coords(0,1), new Coords(-1, 0)   //N, E, S, W
        };

        public class Segment
        {
            public SegmentType Type;
            public Direction Direction { get; set; }
            public Coords Coords;

            public Segment(SegmentType type, Direction direction, Coords coords)
            {
                Type = type;
                Direction = direction;
                Coords = coords;
            }

            public void SetDirection(Direction direction)
            {
                this.Direction = direction;
            }
        }

        public List<Segment> Segments;
        
        public Snake(Coords coords, Direction direction, int length = 3)
        {
            Segments = new List<Segment>();
            CurrentDirection = direction;

            //Head
            Segments.Add(new Segment(SegmentType.Head, direction, coords));
            //Body
            for (int i = 1; i < length-1; i++)
            {
                Segments.Add(new Segment(SegmentType.Body, direction, (Segments[i-1].Coords-Velocity[(int)direction]) ));
            }
            //Tail
            Segments.Add(new Segment(SegmentType.Tail, direction, (Segments[length - 2].Coords - Velocity[(int)direction]) ));
        }

        //Methods

        public void Move()
        {
            for (int i = Segments.Count-1; i > 0; i--)
            {
                Segments[i].Coords.Set(Segments[i-1].Coords);
                Segments[i].Direction = Segments[i-1].Direction;
            }
            Segments[0].Coords.Set(Segments[0].Coords + Velocity[(int)CurrentDirection]);
            Segments[0].Direction = CurrentDirection;
        }

        public void Grow()
        {
            Segments.Add(new Segment(SegmentType.Tail, Segments[Segments.Count-1].Direction, (Segments[Segments.Count - 2].Coords - Velocity[(int)Segments[Segments.Count - 1].Direction])));
            Segments[Segments.Count - 2].Type = SegmentType.Body;
        }
    }
}
