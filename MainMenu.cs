using Godot;
using System.Collections.Generic;

public partial class MainMenu : Node2D
{
/*	[Export] PackedScene touchPointScene;
	[Export] PackedScene originalTouchPointScene;
	
	private Dictionary<int, TouchData> touchData = new Dictionary<int,TouchData>();
	
	public override void _Input(InputEvent @event)
	{
		if(@event is InputEventScreenTouch touch)
		{
			if(touch.IsPressed())
			{
				Node2D newTouchPoint = touchPointScene.Instantiate<Node2D>();
				Node2D newOriginalTouchPoint = originalTouchPointScene.Instantiate<Node2D>();
				
				AddChild(newTouchPoint);
				AddChild(newOriginalTouchPoint);
				
				newTouchPoint.Poisition = touch.Position;
				newOriginalTouchPoint.Position = touch.Position;
				TouchData tempTouchData = new TouchData(
					touchPoint = newTouchPoint,
					originalTouchPoint = newOriginalTouchPoint
				);
				
				touchData.Add(touch.Index, tempTouchData);
			}
			else
			{
				touchData[touch.Index].originalTouchPoint.QueueFree();
				touchData[touch.Index].touchPoint.QueueFree();
				
				touchData.Remove(touch.Index);
			}
		}
	}
	
	private struct TouchData()
	{
		public Node2D touchPoint;
		public Node2D originalTouchPoint;
	}
	
	
	
	
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
	}*/
}
