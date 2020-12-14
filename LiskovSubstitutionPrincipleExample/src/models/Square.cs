
namespace LiskovSubstitutionPrincipleExample.src.models
{
    public class Square : Rectangle
    {
        public Square(int lengthAndWidth) : base(lengthAndWidth, lengthAndWidth)
        {
            this.length = lengthAndWidth;
            this.width = lengthAndWidth;
        }

        private int width;
        public override int Width
        {
            get { return width; }
            set { width = value; length = value; }
        }
        private int length;
        public override int Length
        {
            get { return length; }
            set { length = value; width = value;  }
        }
        


    }
}