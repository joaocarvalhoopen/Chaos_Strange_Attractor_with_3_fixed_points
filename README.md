# Chaos Strange Attractor with 3 fixed points 

## Description
This is a simple implementation of a Chaos Strange Attractor with 3 fixed points. From a sequence of random dice draws at each time it calculates the next point and in the end a strange attractor emerges! It is the Sierpiński triangle. WoW! <br>
See file [Chaos.cs](./Chaos.cs) <br>
   

![Chaos attractor 10.000 random points](./images/chaos_attractor_49.png?raw=true "Chaos attractor 10.000 random points") <br>

## Algorithm
The process is the following:<br>
 * 1 - Choose any three points. I will choose a equilateral triangle.
 * 2 - Choose a random point inside this virtual triangle.<br>
   I will choose the point (0, 0, 0) but could be any point.<br>
   Consider that point as the last point.
 * 3 - Through the dice 1000 times.<br> 
   At each time if it is a value 0 or 1 choose pointA if it is a value 2 or 3 choose pointB else if it is a value 4 or 5 choose pointC.
 * 4 - Then find the mid point between that point and the last point drowned and draw a point. <br> That will become the last point.         
 * 5 - The process repeats for hundreds of times.
 * 6 - Then from chaos a strange attractor emerges!<br> 
   The Sierpiński triangle.
 * 7 - Draw the canvas in intervals of 200 points.

## Sequence of images that are generated at different intervals along the process
Start zero points <br>
<br>
![Chaos attractor 0 points](./images/chaos_attractor_0.png?raw=true "Chaos attractor 0 points") <br>
<br>
At 200 random points <br>
<br>
![Chaos attractor 200 points](./images/chaos_attractor_1.png?raw=true "Chaos attractor 200 points") <br>
<br>
At 400 random points <br>
<br>
![Chaos attractor 400 points](./images/chaos_attractor_2.png?raw=true "Chaos attractor 400 points") <br>
<br>
At 600 random points <br>
<br>
![Chaos attractor 600 points](./images/chaos_attractor_3.png?raw=true "Chaos attractor 600 points") <br>
<br>
At 1000 random points <br>
<br>
![Chaos attractor 1000 points](./images/chaos_attractor_5.png?raw=true "Chaos attractor 1000 points") <br>
<br>
At 10.000 random points <br>
<br>
![Chaos attractor 10.000 random points](./images/chaos_attractor_49.png?raw=true "Chaos attractor 10.000 random points") <br>
<br>

## Reference links to see
* [Video Chaos Game - Numberphile](https://www.youtube.com/watch?v=kbKtFN71Lfs)
* [Sierpiński triangle - Wikipedia](https://en.wikipedia.org/wiki/Sierpi%C5%84ski_triangle)


## Note
This classes are part my implementation of The Ray Tracer Challenger of the book with the same name and I added the Chaos class for this small project.   

## License
MIT Open Source License

## Have fun!
Best regards, <br>
Joao Nuno Carvalho