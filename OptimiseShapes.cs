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
             Answer a = new Answer();
             a.AddTriangle(3.0f, 2.5f);
             a.AddCircle(3.0f);
             a.AddSquare(4.876f);
             Console.WriteLine(a.SumArea());
         }
     }
    public class Answer
    {
        private float Breadth;
        private float Height;
        
        private float Sizes;
        private float Rad;
        private float TriangleArea;
        private float CircleArea;
        public Answer(float b=2.0f, float h=2.0f, float size=2.0f, float radius=2.0f)
        {
            Breadth = b;
            Height = h;
            Sizes = size;
            Rad = radius;
        }

        // getters and setters
        public float BreadthGetSet 
        { 
            get {return this.Breadth;}
            set {this.Breadth = value;}
        }
        public float HeightGetSet 
        { 
            get {return this.Height;} 
            set {this.Height = value;}
        }
        
        public float SizesGetSet 
        {
            get { return this.Sizes;}
            set {this.Sizes = value;}
        }
        public float RadGetSet 
        {
            get { return this.Rad;}
            set {this.Rad = value;}
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

        // Functions
        public void AddTriangle(float b=0.0f, float h=0.0f)
        {
            if(b>0.0f & h>0.0f){
                BreadthGetSet = b;
                HeightGetSet = h;
                TriangleAreaGetSet = this.BreadthGetSet*this.HeightGetSet;
                Console.WriteLine("Triangle "+TriangleAreaGetSet);
            } else {
                TriangleAreaGetSet = this.BreadthGetSet*this.HeightGetSet;
                Console.WriteLine("Triangle "+TriangleAreaGetSet);
            }
        }

        public void AddSquare(float size=0.0f)
        {
            if(size>0.0f)
            {
                SizesGetSet = size;
                Console.WriteLine("Square "+SizesGetSet);
            } 
        }
        public void AddCircle(float radius=0.0f)
        {
            float pi = MathF.PI;
            if(radius>0.0f){
                RadGetSet = radius;
                CircleAreaGetSet = pi*this.Rad*this.Rad;
                Console.WriteLine("Circle "+CircleAreaGetSet);
            } else {
                CircleAreaGetSet = pi*this.Rad*this.Rad;
                Console.WriteLine("Circle "+CircleAreaGetSet);
            }
        }

        public float SumArea()
        {
            int numOfTriangleShapes = 0;
            int numOfCircleShapes = 0;
            int numOfSquareShapes = 0;
            float containerArea = 124.7680f;
            float areaLeft = 0.0f;
            
            // set as dictionary to iterate values and count number for each shape used to optimise containerArea
            var dictShapes = new Dictionary<string, float>()
            {
                {"Triangle", TriangleAreaGetSet},
                {"Circle", CircleAreaGetSet},
                {"Square", SizesGetSet}
            };

            //use sort to start with highest
            var sortByDescending = from entry in dictShapes orderby entry.Value descending select entry;

                float tempVal = containerArea;
                foreach (KeyValuePair<string, float> shape in sortByDescending)
                { 
                        while(shape.Value < tempVal)
                        {
                            Console.WriteLine("tempVal: "+tempVal);
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

            return areaLeft;
        }
    }

}




