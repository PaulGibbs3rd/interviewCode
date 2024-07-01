using System;
using System.Drawing;
using System.Drawing.Imaging;

class Program
{
    static void Main()
    {
        CreateFullGradient();
        CreateMiddleStartingGradient();
        CreateIncrementalGradient();
    }

    static void CreateFullGradient()
    {
        // Define image dimensions
        int width = 4096;
        int height = 4096;

        // Create a new Bitmap
        using (Bitmap bitmap = new Bitmap(width, height))
        {
            long colorValue = 0x000000;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // Create color from colorValue
                    Color color = Color.FromArgb((int)((colorValue >> 16) & 0xFF),
                                                 (int)((colorValue >> 8) & 0xFF),
                                                 (int)(colorValue & 0xFF));

                    // Set pixel color
                    bitmap.SetPixel(x, y, color);

                    // Increment color value
                    colorValue++;

                    // Ensure the colorValue stays within bounds
                    if (colorValue > 0xFFFFFF)
                    {
                        colorValue = 0xFFFFFF;
                    }
                }
            }

            // Save the bitmap as PNG
            bitmap.Save("Gradient.png", ImageFormat.Png);
        }

        Console.WriteLine("Full gradient image created successfully.");
    }

    static void CreateMiddleStartingGradient()
    {
        // Define image dimensions
        int width = 4096;
        int height = 4096;

        // Starting color value
        long startColorValue = 0x888888;
        long colorValue = startColorValue;

        // Create a new Bitmap
        using (Bitmap bitmap = new Bitmap(width, height))
        {
            bool wrappedAround = false;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // Create color from colorValue
                    Color color = Color.FromArgb((int)((colorValue >> 16) & 0xFF),
                                                 (int)((colorValue >> 8) & 0xFF),
                                                 (int)(colorValue & 0xFF));

                    // Set pixel color
                    bitmap.SetPixel(x, y, color);

                    // Increment color value
                    colorValue++;

                    // Check if we've wrapped around the color range
                    if (colorValue > 0xFFFFFF)
                    {
                        colorValue = 0x000000;
                        wrappedAround = true;
                    }

                    // Stop when we hit the start color value again after wrapping around
                    if (wrappedAround && colorValue == startColorValue)
                    {
                        bitmap.Save("GradientMiddle.png", ImageFormat.Png);
                        Console.WriteLine("Middle starting gradient image created successfully.");
                        return;
                    }
                }
            }
        }

        Console.WriteLine("Middle starting gradient image created successfully.");
    }

    static void CreateIncrementalGradient()
    {
        // Define image dimensions
        int width = 4096;
        int height = 4096;

        // Create a new Bitmap
        using (Bitmap bitmap = new Bitmap(width, height))
        {
            int red = 0;
            int green = 0;
            int blue = 0;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // Create color from red, green, and blue components
                    Color color = Color.FromArgb(red, green, blue);

                    // Set pixel color
                    bitmap.SetPixel(x, y, color);

                    // Increment color components based on x % 3
                    if (x % 3 == 0)
                    {
                        blue++;
                        if (blue > 255) blue = 0;
                    }
                    else if (x % 3 == 1)
                    {
                        green++;
                        if (green > 255) green = 0;
                    }
                    else if (x % 3 == 2)
                    {
                        red++;
                        if (red > 255) red = 0;
                    }
                }
            }

            // Save the bitmap as PNG
            bitmap.Save("IncrementalGradient.png", ImageFormat.Png);
        }

        Console.WriteLine("Incremental gradient image created successfully.");
    }
}
