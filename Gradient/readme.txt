This C# program generates three different types of gradient images using the System.Drawing namespace. The program includes three distinct methods to create these images, each saved in PNG format.

Features
Full Gradient Image:

Creates a gradient image from #000000 (black) to #FFFFFF (white).
Each pixel's color value is incremented sequentially.
The result is saved as Gradient.png.
Middle Starting Gradient Image:

Starts from the middle hex value #888888.
Increments the color value until #FFFFFF and wraps around to #000000.
Continues incrementing until it reaches #888888 again.
The result is saved as GradientMiddle.png.
Incremental Gradient Image:

Increments the blue component if x % 3 == 0.
Increments the green component if x % 3 == 1.
Increments the red component if x % 3 == 2.
Ensures that each component wraps around to 0 after exceeding 255.
The result is saved as IncrementalGradient.png.
Code Logic
Full Gradient Logic
Iterates over each pixel in a 4096x4096 image.
Sets each pixel's color by incrementing a single color value from #000000 to #FFFFFF.
Middle Starting Gradient Logic
Begins with the color #888888.
Increments the color value until #FFFFFF, wraps around to #000000, and continues until #888888 is reached again.
Incremental Gradient Logic
Iterates over each pixel in a 4096x4096 image.
Uses the modulus operator to determine which color component to increment:
x % 3 == 0 increments blue.
x % 3 == 1 increments green.
x % 3 == 2 increments red.
Each color component wraps around to 0 after exceeding 255.
