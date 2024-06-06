using Raylib_cs;
using System.Numerics;

public class Program
{
    static string title = "Game Title"; // Window title
    static int screenWidth = 1200; // Screen width
    static int screenHeight = 1000; // Screen height
    static int targetFps = 60; // Target frames-per-second
    static Vector2 playerPosition; // Player position
    static int playerSize = 60; // Player size
    static int playerSpeed = 5; // Player movement speed
    static Color backgroundColor = new Color(85, 92, 61, 255); // Custom background color
    static Color playerColor = new Color(158, 115, 62, 255); // Player color (#9e733e)
    static Color bedColor = new Color(117, 47, 57, 255); // Bed color (#752f39)
    static Color deskColor = new Color(61, 51, 37, 255); // Desk color (#3d3325)
    static Color wardrobeColor = new Color(128, 90, 41, 255); // Wardrobe color (#805a29)
    static Color chairColor = new Color(140, 108, 76, 255); // Chair color (#8c6c4c)
    static Color floorColor = new Color(33, 24, 14, 255); // Custom color (#21180e)

    static void Main()
    {
        // Create a window to draw to. The arguments define width and height
        Raylib.InitWindow(screenWidth, screenHeight, title);
        // Set the target frames-per-second (FPS)
        Raylib.SetTargetFPS(targetFps);
        // Setup your game. This is a function YOU define.
        Setup();
        // Loop so long as window should not close
        while (!Raylib.WindowShouldClose())
        {
            // Enable drawing to the canvas (window)
            Raylib.BeginDrawing();
            // Clear the canvas with the custom background color
            Raylib.ClearBackground(backgroundColor);
            // Your game code here. This is a function YOU define.
            Update();
            // Stop drawing to the canvas, begin displaying the frame
            Raylib.EndDrawing();
        }
        // Close the window
        Raylib.CloseWindow();
    }

    static void Setup()
    {
        // Initialize player position to the center of the screen
        playerPosition = new Vector2(screenWidth / 2, screenHeight / 2);
    }

    static void Update()
    {
        // Handle player movement
        if (Raylib.IsKeyDown(KeyboardKey.W)) playerPosition.Y -= playerSpeed;
        if (Raylib.IsKeyDown(KeyboardKey.S)) playerPosition.Y += playerSpeed;
        if (Raylib.IsKeyDown(KeyboardKey.A)) playerPosition.X -= playerSpeed;
        if (Raylib.IsKeyDown(KeyboardKey.D)) playerPosition.X += playerSpeed;

        // Draw the room
        DrawRoom();

        // Draw the player
        DrawPlayer();
    }

    static void DrawRoom()
    {
        // Draw the room floor
        Raylib.DrawRectangle(100, 100, screenWidth - 200, screenHeight - 200, Raylib_cs.Color.RayWhite);

        // Draw the room border with increased thickness
        int borderThickness = 10;
        Raylib.DrawRectangle(90, 90, screenWidth - 180, borderThickness, Raylib_cs.Color.Black); // Top border
        Raylib.DrawRectangle(90, screenHeight - 110, screenWidth - 180, borderThickness, Raylib_cs.Color.Black); // Bottom border
        Raylib.DrawRectangle(90, 90, borderThickness, screenHeight - 180, Raylib_cs.Color.Black); // Left border
        Raylib.DrawRectangle(screenWidth - 110, 90, borderThickness, screenHeight - 180, Raylib_cs.Color.Black); // Right border

        // Draw furniture (example)
        Raylib.DrawRectangle(150, 130, 300, 150, bedColor); // Bed
        Raylib.DrawRectangle(675, 130, 150, 75, deskColor); // Desk
        Raylib.DrawRectangle(545, 130, 75, 200, wardrobeColor); // Wardrobe
        Raylib.DrawRectangle(725, 210, 50, 50, deskColor); // Chair
    }

    static void DrawPlayer()
    {
        // Draw the player
        Raylib.DrawRectangleV(playerPosition, new Vector2(playerSize, playerSize), playerColor);
    }
}
