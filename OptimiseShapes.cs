using System;
using System.Linq;
using System.Collections.Generic;


namespace OptimiseShapes
 {
     class Program
     {
         static void Main (string[] args)
         {
             Answer a = new Answer(3.0f, 2.5f, 3.0f, 2.5f, 3.0f);
             Console.WriteLine("Total area of shapes to match with container: " + a.SumArea());
         }
     }
    public class Answer
    {
        private float _triangleBreadth;
        private float _triangleHeight;
        private float _squareBreadth;
        private float _squareHeight; 
        private float _rad;
        private float _triangleArea;
        private float _circleArea;
        private float _squareArea;
        public Answer(float Tb=2.0f, float Th=2.0f, float Sb=2.0f, float Sh = 2.0f, float radius=2.0f)
        {
            _triangleBreadth = Tb;
            _triangleHeight = Th;
            _squareBreadth = Sb;
            _squareHeight = Sh;
            _rad = radius;
        }

        // getters and setters
        public float TriangleBreadthGet 
        { 
            get {return _triangleBreadth;}
        }
        public float TriangleHeightGet 
        { 
            get {return _triangleHeight;} 
        }
        public float SquareBreadthGet 
        { 
            get {return _squareBreadth;}
        }
        public float SquareHeightGet 
        { 
            get {return _squareHeight;} 
        }
        public float RadGet 
        {
            get { return _rad;}
        }
        public float TriangleAreaGetSet 
        {
            get { return _triangleArea;}
            private set {_triangleArea = value;}
        }
        public float CircleAreaGetSet 
        {
            get { return _circleArea;}
            private set {_circleArea = value;}
        }
        public float SquareAreaGetSet 
        {
            get { return _squareArea;}
            private set {_squareArea = value;}
        }

        // Functions
        public void AddTriangle()
        {
            
            this.TriangleAreaGetSet = 0.5f*this.TriangleBreadthGet*this.TriangleHeightGet;
            Console.WriteLine("Triangle: "+this.TriangleAreaGetSet);
        
        }
        public void AddSquare()
        {         
            this.SquareAreaGetSet = this.SquareBreadthGet*this.SquareHeightGet;
            Console.WriteLine("Square: "+this.SquareAreaGetSet);
       
        }
        public void AddCircle()
        {
            float pi = MathF.PI;    
            this.CircleAreaGetSet = pi*(float)Math.Pow(this.RadGet, 2);
            Console.WriteLine("Circle: "+this.CircleAreaGetSet);
        }

        public float SumArea()
        {
            int numOfTriangleShapes = 0;
            int numOfCircleShapes = 0;
            int numOfSquareShapes = 0;
            float containerArea = 155.7680f;
            float optimalArea = 0.0f;

            AddTriangle();
            AddSquare();
            AddCircle();

            // set as dictionary to iterate values and count number for each shape used to optimise containerArea
            var dictShapes = new Dictionary<string, float>()
            {
                {"Triangle", this.TriangleAreaGetSet},
                {"Circle", this.CircleAreaGetSet},
                {"Square", this.SquareAreaGetSet}
            };

            //use sort to start with highest
            var sortByDescending = from shape in dictShapes orderby shape.Value descending select shape;

                float tempVal = containerArea;
                foreach (KeyValuePair<string, float> shape in sortByDescending)
                { 
                        while(shape.Value < tempVal)
                        {
                            optimalArea += shape.Value;
                            tempVal -= shape.Value;
                            if(shape.Key == "Triangle") {
                                numOfTriangleShapes += 1;
                            } else if(shape.Key == "Circle")
                            {
                                numOfCircleShapes += 1;
                            } else if(shape.Key == "Square")
                            {
                                numOfSquareShapes += 1;
                            }
                        } 
                }
            
            // write to console number of each shapes used to match for optimum area to match with given containerArea
            Console.WriteLine("Number of triangles: "+numOfTriangleShapes);
            Console.WriteLine("Number of circles: "+numOfCircleShapes);
            Console.WriteLine("Number of squares: "+numOfSquareShapes);
            Console.WriteLine("Size of container: "+containerArea);

            return optimalArea;
        }
    }

}




