namespace LiskovSegregationPrincipleExample.src.models
{
    public class Rectangle
    {
        public Rectangle(int length, int width)
        {
            this.length = length;
            this.width = width;
        }
        private int length;
        public virtual int Length
        {
            get { return length; }
            set { length = value; }
        }

        private int width;
        public virtual int Width
        {
            get { return width; }
            set { width = value; }
        }



        public int GetArea()
        {
            return this.length * this.width;
        }
    }
}
