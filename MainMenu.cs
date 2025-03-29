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
        _texture = TextureUntouched; // Set default texture
    }

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventScreenTouch touchEvent)
        {
            if (touchEvent.Pressed)
            {
                _isTouched = true; // Set the flag when touched
                _texture = TextureTouched ?? _texture; // Use TextureTouched if available
                _lastTouchPosition = touchEvent.Position; // Update position
                QueueRedraw();
                GD.Print($"Touched at: {touchEvent.Position}");
            }
            else
            {
                _isTouched = false; // Reset flag when released
                _texture = TextureUntouched ?? _texture; // Use TextureUntouched when released
                QueueRedraw();
                GD.Print($"Released at: {touchEvent.Position}");
            }
        }
    }

    public override void _Process(float delta)
    {
        if (_isTouched && _texture != null)
        {
            // Update position continuously when touch is active
            _lastTouchPosition = GetViewport().GetMousePosition(); // Update with live touch position
            QueueRedraw();
        }
    }

    public override void _Draw()
    {
        if (_texture != null)
        {
            // Draw the texture at the current touch position
            DrawTexture(_texture, _lastTouchPosition);
        }
    }
}
