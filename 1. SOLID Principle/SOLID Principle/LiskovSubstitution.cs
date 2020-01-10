using System.Net.NetworkInformation;

namespace SOLID_Principle
{
    public class Rectangle
    {
        // LISKOV SUBSTITUTION PRINCIPLE
        // Any class that is the child of a parent class should be usable
        // in place of its parent without any unexpected behaviour
        
        
        /*// initial approach
        public int Width { get; set; }
        public int Height { get; set; }*/
        
        // better approach
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        public Rectangle()
        {

        }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
        }
    }

    public class Square : Rectangle
    {
        /*// initial approach
        public new int Width
        {
            set { base.Width = base.Height = value; }
        }

        public new int Height
        {
            set { base.Width = base.Height = value; }
        }*/
        
        // better approach
        public override int Width
        {
            set { base.Width = base.Height = value; }
        }

        public override int Height
        {
            set { base.Width = base.Height = value; }
        }
    }

}