using Godot;
using System;

public partial class MainMenu : Node2D
{
    private Texture2D _texture;
    private Vector2 _lastTouchPosition = Vector2.Zero; // Store last touch position
    private bool _isTouched = false; // Track touch state

    [Export] public Texture2D TextureTouched;
    [Export] public Texture2D TextureUntouched;

    public override void _Ready()
    {
        // Set default texture on ready
        _texture = TextureUntouched;
    }

    public override void _Input(InputEvent @event)
    {
        // Make sure we are handling touch input correctly in Godot 4.3
        if (@event is InputEventScreenTouch touchEvent)
        {
            if (touchEvent.Pressed)
            {
                _isTouched = true; // Mark as touched
                _texture = TextureTouched ?? _texture; // Use Touched texture
                _lastTouchPosition = touchEvent.Position; // Update touch position
                QueueRedraw(); // Ensure screen is redrawn
                GD.Print($"Touched at: {touchEvent.Position}");
            }
            else
            {
                _isTouched = false; // Mark as not touched
                _texture = TextureUntouched ?? _texture; // Use Untouched texture
                QueueRedraw(); // Ensure screen is redrawn
                GD.Print($"Released at: {touchEvent.Position}");
            }
        }
    }

    public override void _Process(float delta)
    {
        if (_isTouched && _texture != null)
        {
            // If the screen is being touched, update the last position continuously
            _lastTouchPosition = GetViewport().GetMousePosition(); // Get the live touch position
            QueueRedraw(); // Ensure the texture is drawn at the updated position
        }
    }

    public override void _Draw()
    {
        // Make sure we're drawing the texture at the last recorded touch position
        if (_texture != null)
        {
            DrawTexture(_texture, _lastTouchPosition); // Draw the texture at touch position
        }
    }
}
