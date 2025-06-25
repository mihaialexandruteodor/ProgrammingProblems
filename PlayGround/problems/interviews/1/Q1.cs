public class Q1 : IBaseSolution
{
    public void printSource()
    {
        SourcePrinter.PrintSource(this.GetType());
    }
    public void solve()
    {
        int[] data = [7, 1, 5, 3, 6, 4];
        Console.WriteLine(Problem(data));
    }

    class Point2D
    {
        public Point2D(int _x, int _y)
        {
            this.x = _x;
            this.y = _y;
        }

        public int getX()
        {
            return this.x;
        }

        public int getY()
        {
            return this.y;
        }

        public double dist2D(Point2D p)
        {
            return Math.Sqrt(Math.Pow(p.getX() - this.x, 2) + Math.Pow(p.getY() - this.y, 2));
        }

        public virtual void printDistance(double d)
        {
            Console.WriteLine("2D distance = " + (int)Math.Ceiling(d));
        }

        protected int x; protected int y; 
    };

    class Point3D : Point2D
    {
        public Point3D(int _x, int _y, int _z):
            base(_x, _y)
        {
            
            this.z = _z;
        }

        public int getZ()
        {
            return this.z;
        }

        public double dist3D(Point3D p)
        {
            return Math.Sqrt(Math.Pow(p.getX() - base.x, 2) + Math.Pow(p.getY() - this.y, 2) + Math.Pow(p.getZ() - this.z, 2));
        }

        public override void printDistance(double d)
        {
            Console.WriteLine("3D distance = " + (int)Math.Ceiling(d));
        }

        private int z;
    };


    public int Problem(int[] prices)
    {

        return 0;
    }
}