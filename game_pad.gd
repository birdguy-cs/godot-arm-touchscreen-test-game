extends Node2D

@export var circle0_radius: float = 50.0
@export var circle0_color: Color = Color.WHITE

@export var circle1_radius: float = 50.0
@export var circle1_color: Color = Color.WHITE

var circle0_index: int = -1
var circle1_index: int = -1

var circle0_pressing: bool = false
var circle1_pressing: bool = false

var circle0_position: Vector2 = Vector2.ZERO
var circle1_position: Vector2 = Vector2.ZERO

# Adjust these to center the circles more sensibly
@export var circle0_relative_position: Vector2 = Vector2(-0.35, 0.3)  # 20% of width, 50% of height
@export var circle1_relative_position: Vector2 = Vector2(0.35, 0.3)  # 80% of width, 50% of height

# Function to calculate screen position from relative coordinates
func get_screen_position(relative_position: Vector2) -> Vector2:
	# Get the screen size from the viewport
	var screen_size = get_viewport().size
	# Return position scaled to the screen size
	return relative_position * screen_size

# Check if the position is inside a circle
func is_inside_circle(pos: Vector2, circle_position: Vector2, circle_radius: float) -> bool:
	# Check the distance between the touch position and the circle's center
	if pos.distance_to(circle_position) <= circle_radius:
		return true
	return false

# Handle touch input
func _input(event: InputEvent) -> void:
	if event is InputEventScreenTouch:
		if event.pressed:
			# Get screen positions for the circles
			var circle0_screen_pos = get_screen_position(circle0_relative_position)
			var circle1_screen_pos = get_screen_position(circle1_relative_position)
			
			# Check if the touch is inside circle0 or circle1
			if is_inside_circle(event.position, circle0_screen_pos, circle0_radius):
				circle0_pressing = true
				circle0_index = event.index
				circle0_position = event.position  # Update position to current touch position
			elif is_inside_circle(event.position, circle1_screen_pos, circle1_radius):
				circle1_pressing = true
				circle1_index = event.index
				circle1_position = event.position  # Update position to current touch position
		else:
			# Reset the pressing states when touch ends
			if event.index == circle0_index:
				circle0_pressing = false
				circle0_index = -1
			elif event.index == circle1_index:
				circle1_pressing = false
				circle1_index = -1
	elif event is InputEventScreenDrag:
		# Update position during drag for the active circle
		if event.index == circle0_index:
			circle0_position = event.position
		elif event.index == circle1_index:
			circle1_position = event.position

# Draw the circles on screen
func _draw() -> void:
	# Calculate the screen positions of the circles
	var circle0_screen_pos = get_screen_position(circle0_relative_position)
	var circle1_screen_pos = get_screen_position(circle1_relative_position)

	# Draw circles at their screen positions
	draw_circle(circle0_screen_pos, circle0_radius, circle0_color)
	draw_circle(circle1_screen_pos, circle1_radius, circle1_color)
