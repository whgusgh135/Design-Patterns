using System;

namespace Factories
{
    public class Point
    {
        // factory method
        public static Point NewCartesianPoint(double x, double y)
        {
            return new Point(x, y);
        }

        public static Point NewPolarPoint(double rho, double theta)
        {
            return new Point(rho*Math.Cos(theta), rho*Math.Sin(theta));
        }

        private double x, y;

        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }
    }
    
    
    // Alternate method
    // seperate factory to external own class
    // consequence is that the constructor is public again
    public static class Point2Factory
    {
        public static Point2 NewCartesianPoint(double x, double y)
        {
            return new Point2(x, y);
        }
        
        public static Point2 NewPolarPoint(double rho, double theta)
        {
            return new Point2(rho*Math.Cos(theta), rho*Math.Sin(theta));
        }
    }

    public class Point2
    {
        private double x, y;

        // public constructor - not good
        // alternatively we can have internal Point2(double x, double y)
        public Point2(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }
    
    
    // Inner Factory method
    public class Point3
    {
        private double x, y;

        private Point3(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }

        public static Point3 Origin => new Point3(0, 0);
        public static Point3 Origin2 = new Point3(0, 0); // better
        
        public static class Factory
        {
            public static Point3 NewCartesianPoint(double x, double y)
            {
                return new Point3(x, y);
            }

            public static Point3 NewPolarPoint(double rho, double theta)
            {
                return new Point3(rho*Math.Cos(theta), rho*Math.Sin(theta));
            }
        }
    }
}