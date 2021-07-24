using System;
using System.IO;
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
        private float TriangleBreadth;
        private float TriangleHeight;
        private float SquareBreadth;
        private float SquareHeight; 
        private float Rad;
        private float TriangleArea;
        private float CircleArea;
        private float SquareArea;
        public Answer(float Tb=2.0f, float Th=2.0f, float Sb=2.0f, float Sh = 2.0f, float radius=2.0f)
        {
            TriangleBreadth = Tb;
            TriangleHeight = Th;
            SquareBreadth = Sb;
            SquareHeight = Sh;
            Rad = radius;
        }

        // getters and setters
        public float TriangleBreadthGetSet 
        { 
            get {return this.TriangleBreadth;}
        }
        public float TriangleHeightGetSet 
        { 
            get {return this.TriangleHeight;} 
        }
        public float SquareBreadthGetSet 
        { 
            get {return this.SquareBreadth;}
        }
        public float SquareHeightGetSet 
        { 
            get {return this.SquareHeight;} 
        }
        public float RadGetSet 
        {
            get { return this.Rad;}
        }
        public float TriangleAreaGetSet 
        {
            get { return this.TriangleArea;}
            set {this.TriangleArea = value;}
        }
        public float CircleAreaGetSet 
        {
            get { return this.CircleArea;}
            set {this.CircleArea = value;}
        }
        public float SquareAreaGetSet 
        {
            get { return this.SquareArea;}
            set {this.SquareArea = value;}
        }

        // Functions
        public void AddTriangle()
        {
            
            this.TriangleAreaGetSet = 0.5f*this.TriangleBreadthGetSet*this.TriangleHeightGetSet;
            Console.WriteLine("Triangle: "+TriangleAreaGetSet);
        
        }

        public void AddSquare()
        {
         
            this.SquareAreaGetSet = this.SquareBreadthGetSet*this.SquareHeightGetSet;
            Console.WriteLine("Square: "+SquareAreaGetSet);
       
        }
        public void AddCircle()
        {
            float pi = MathF.PI;    
            CircleAreaGetSet = pi*this.Rad*this.Rad;
            Console.WriteLine("Circle: "+CircleAreaGetSet);
        }

        public float SumArea()
        {
            int numOfTriangleShapes = 0;
            int numOfCircleShapes = 0;
            int numOfSquareShapes = 0;
            float containerArea = 124.7680f;
            float areaLeft = 0.0f;

            AddTriangle();
            AddSquare();
            AddCircle();

            // set as dictionary to iterate values and count number for each shape used to optimise containerArea
            var dictShapes = new Dictionary<string, float>()
            {
                {"Triangle", TriangleAreaGetSet},
                {"Circle", CircleAreaGetSet},
                {"Square", SquareAreaGetSet}
            };

            //use sort to start with highest
            var sortByDescending = from entry in dictShapes orderby entry.Value descending select entry;

                float tempVal = containerArea;
                foreach (KeyValuePair<string, float> shape in sortByDescending)
                { 
                        while(shape.Value < tempVal)
                        {
                            areaLeft += shape.Value;
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

            return areaLeft;
        }
    }

}




