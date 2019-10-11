using System;
using System.Collections.Generic;

public class Chaos
{

    public static void drawChaosStrangeAttractor(){

        // Choose any tree points. I will choose a triangle Isosteles.
        Tuple pT1 = Tuple.Point(   0, 0, 1); 
        Tuple pT2 = Tuple.Point(-0.5, 0, 0);
        Tuple pT3 = Tuple.Point( 0.5, 0, 0);

        // Choose a random point inside this virtual triangle.
        // I will choose the point (0, 0, 0) but could be any point.
        Tuple pTStart = Tuple.Point(0, 0, 0);

        // Consider that point as the last point.
        Tuple pTLast = Tuple.Point(0, 0, 0);

        // Through the dice 1000 times and at each time if it is a value 0 or 1 choose pointA
        // if it is a value 2 or 3 choose pointB else if it is a value 4 or 5 choose pointC.
        // Then find the mid point between that point and the last point drawned and draw a point.
        // That will become the last point and the process repeats for hundreds of times.
        // Then from chaos a strange attractor emerges!
        // The Sierpiński triangle 
        int numOfPoints = 10000;
        var rand = new Random();
        List<Tuple> ptList = new List<Tuple>(numOfPoints);         
        for (int i = 0; i < numOfPoints; i++){
            int dice = rand.Next(6);
            switch (dice)
            {
                case 0:
                case 1:
                    pTLast = midPoint(pT1, pTLast);
                    break;
                case 2:
                case 3:
                    pTLast = midPoint(pT2, pTLast);
                    break;
                case 4:
                case 5:
                    pTLast = midPoint(pT3, pTLast);
                    break;
            }
            ptList.Add(pTLast);
        }

        // Draw the canvas in intervals of 100 points.
        Console.WriteLine("Drawing Chaos Attractor...");
        const int width  = 300;
        const int height = 300; 
        const int margin = 5;
        Canvas canv = new Canvas(width, height);

        Color green = new Color(0, 1, 0);
        foreach (Tuple pt in new []{pT1, pT2, pT3} ){
            int x =          (int) (pt.x * (width - margin)  +  width / 2.0) ;
            int y = height - (int) (pt.z * (height - margin) + 2 );

            canv.writePixel(x,     y, green);
            canv.writePixel(x+1,   y, green);
            canv.writePixel(x,   y+1, green);
            canv.writePixel(x+1, y+1, green);
        }

        Color white = new Color(1, 1, 1);
        int index = 0;
        int output_index = 0;
        foreach (Tuple pt in ptList)
        {
            int x =          (int) (pt.x * (width - margin)  +  width / 2.0) ;
            int y = height - (int) (pt.z * (height - margin)  + 2 );
            if (x >= 0 && x < width-1 &&
                y >= 0 && y < height-1){
                canv.writePixel(x, y, white);
            }

            if (index % 200 == 0){
                string filename = string.Format(@".\images_chaos\chaos_attractor_{0}.ppm", output_index);
                canv.canvasToPpmFile(filename);
                output_index++;
            } 
            index++;
        }
    }

    private static Tuple midPoint(Tuple ptA, Tuple ptB){
        return (ptA + ptB) / 2.0;
    }

}