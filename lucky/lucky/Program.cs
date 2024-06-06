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
        Raylib.DrawRectangle(100, 100, screenWidth - 200, screenHeight - 200, Raylib_cs.Color.Brown);

        // Draw furniture (example)
        Raylib.DrawRectangle(150, 150, 300, 150, Raylib_cs.Color.DarkGray); // Bed
        Raylib.DrawRectangle(500, 250, 150, 75, Raylib_cs.Color.DarkGray); // Desk
        Raylib.DrawRectangle(700, 150, 75, 200, Raylib_cs.Color.DarkGray); // Wardrobe
        Raylib.DrawRectangle(900, 400, 150, 150, Raylib_cs.Color.DarkGray); // Chair
    }

    static void DrawPlayer()
    {
        // Draw the player
        Raylib.DrawRectangleV(playerPosition, new Vector2(playerSize, playerSize), Raylib_cs.Color.Black);
    }
}
