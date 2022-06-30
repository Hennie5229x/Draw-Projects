# Draw-Projects
C# Draw Projects

Draw Circle
----------------
This is a small win forms C# program that uses Pythagoras theorem and the Sine function to create triangles to draw a circle with straight lines.

Draw Spiral
----------------
Using the same triangle logic from the circle I now just increase the triangle every time the circle makes a full rotation. There is a linear method that consistently increases the triangle and then a exponential increase where I make use of the Fibonacci sequence.

Draw Ellipse
----------------
Once again using the same triangle logic from the circle, but this time making two circles, a large outer and a smaller inner circle. Using triangles between the circles to create the oval shape. I took inspiration from Philippe de La Hire’s (Mathematician) method of constructing an ellipse.

Using the code in a project
-------------------------------------
If you would like to recreate exactly what I did you can simply create a new win forms project in visual studio and add an event on the form for Paint. This will create the Form1_Paint() method, furthermore just copy the rest in your project and everything should work.


