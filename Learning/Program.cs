using System;

namespace ConsoleApp1
{
    class Point
    {
        private double x;
        private double y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double GetX()
        {
            return x;
        }

        public double GetY()
        {
            return y;
        }

        public double GetDistanceTo(Point o)
        {
            return Math.Sqrt( Math.Pow(this.x - o.x,2) + Math.Pow(this.y - o.y, 2));
        }


        public override string ToString()
        {
            return "{" + x + "," + y + "}";
        }

        private static bool IsEqual (double a, double b)
        {
            double d = a * 0.00001;
            return Math.Abs(a - b) < d;
        }

        public static bool operator ==(Point a, Point b)
        {
            return IsEqual(a.x,b.x) && IsEqual(a.y, b.y);
        }

        public static bool operator !=(Point a, Point b)
        {
            return !IsEqual(a.x, b.x) || !IsEqual(a.y, b.y);
        }

    }

    class Shape
    {
        private Point[] points;

        public Shape(Point[] points)
        {
            this.points = points;
        }

        public Point GetPoint(int id)
        {
            return points[id];
        }

        public int GetSize()
        {
            return points.Length;
        }

        public override string ToString()
        {
            string result = "[";

            for (int i = 0; i<points.Length - 1; i++)
            {
                result += points[i] + ", ";
            } 
            if (points.Length > 0)
                result += points[points.Length-1];

            return result + "]";
        }   
    }

    class Triangle : Shape
    {
        public Triangle(Point a, Point b, Point c) : base(new Point[] { a, b, c })
        {
        }

        public double GetAB()
        {
            return GetPoint(0).GetDistanceTo(GetPoint(1));
        }
        public double GetAC()
        {
            return GetPoint(0).GetDistanceTo(GetPoint(2));
        }
        public double GetBC()
        {
            return GetPoint(1).GetDistanceTo(GetPoint(2));
        }

        public bool IsValid()
        {
            return !(GetPoint(0) == GetPoint(1) || GetPoint(1) == GetPoint(2) || GetPoint(0) == GetPoint(2));
        }

    }

    



    class Program
    {

        static void Main(string[] args)
        {
            Triangle t = new Triangle(new Point(1, 2), new Point(1, 2), new Point(3, 4));
            Console.WriteLine(t);
            Console.WriteLine(t.IsValid());
        }
    }
}