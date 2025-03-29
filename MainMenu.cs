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
        if (@event is InputEventScreenTouch touchEvent)
        {
            if (touchEvent.Pressed)
            {
                _isTouched = true; // Mark as touched
                _texture = TextureTouched; // Use Touched texture
                _lastTouchPosition = touchEvent.Position; // Update touch position
                QueueRedraw(); // Ensure screen is redrawn
                GD.Print($"Touched at: {touchEvent.Position}");
            }
            else
            {
                _isTouched = false; // Mark as not touched
                _texture = TextureUntouched; // Use Untouched texture
                QueueRedraw(); // Ensure screen is redrawn
                GD.Print($"Released at: {touchEvent.Position}");
            }
        }
    }

    public override void _Draw()
    {
        if (_texture != null)
        {
            // Draw the texture at the touch position, considering the correct coordinate system
            DrawTexture(_texture, _lastTouchPosition);
        }
    }
}
