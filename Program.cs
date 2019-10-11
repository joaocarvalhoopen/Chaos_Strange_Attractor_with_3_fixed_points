/******************************************************************************
 *                                                                            *
 *  Chaos Strange Attractor with 3 points                                     *
 *                                                                            *
 ******************************************************************************
 * Author: Joao Nuno Carvalho                                                 *
 * Date: 2019.10.11                                                           *
 * License: MIT Open Source License                                           *
 * Description: This is a simple implementation of a Chaos Strange Attractor  *
 *              with 3 fixed points. In the end it draws the attractor and it *
 * is the Sierpiński triangle. WoW!                                           *
 * The process is the following:                                              *
 *    1 - Choose any three points. I will choose a equilateral triangle.      *
 *    2 - Choose a random point inside this virtual triangle.                 *
 *         I will choose the point (0, 0, 0) but could be any point.          *
 *         Consider that point as the last point.                             *
 *    3 - Through the dice 1000 times.                                        *
 *          At each time if it is a value 0 or 1 choose pointA if it is a     *
 *          value 2 or 3 choose pointB else if it is a value 4 or 5 choose    *
 *          pointC.                                                           *
 *    4 - Then find the mid point between that point and the last point       *
 *        drawned and draw a point.                                           *
 *        That will become the last point.                                    *
 *    5 - The process repeats for hundreds of times.                          *
 *    6 - Then from chaos a strange attractor emerges!                        *
 *        The Sierpiński triangle.                                            *
 *                                                                            *
 *    7 - Draw the canvas in intervals of 200 points.                         *
 *                                                                            *
 * See references on the project page.                                        *
 ******************************************************************************
 * Note: This classes are part my implementation of The Ray Tracer Challenger *
 *       of the book with the same name and I added the Chaos class for this  *
 *       small project.                                                       *
 ******************************************************************************
*/  

using System;

public static class Constants
{
    public const double Epsilon = 0.00001; 
}

class Program
{
    static void Main(string[] args)
    {
        Chaos.drawChaosStrangeAttractor();
    }
}
