using Godot;
using System;

public partial class MainMenu : Node2D
{
	private Texture2D _texture;
	private Vector2 _lastTouchPosition = Vector2.Zero; // Store last touch position

	[Export]
	public Texture2D TextureTouched;
	[Export]
	public Texture2D TextureUntouched;

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventScreenTouch touchEvent)
		{
			if (touchEvent.Pressed)
			{
				_texture = TextureTouched;
				_lastTouchPosition = touchEvent.Position; // Update touch position
				QueueRedraw();
				GD.Print($"Touched at: {touchEvent.Position}");
			}
			else
			{
				_texture = TextureUntouched;
				QueueRedraw();
				GD.Print($"Released at: {touchEvent.Position}");
			}
		}
	}

	public override void _Draw()
	{
		if (_texture != null)
		{
			DrawTexture(_texture, _lastTouchPosition);
		}
	}
}
