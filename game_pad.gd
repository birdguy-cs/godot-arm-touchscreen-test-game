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
	return Vector2(relative_position.x * screen_size.x, relative_position.y * screen_size.y)

# Check if the position is inside circle0
func is_inside_circle0(pos: Vector2) -> bool:
	var screen_pos = get_screen_position(circle0_relative_position)
	if pos.distance_to(screen_pos) > circle0_radius:
		return false
	return true

# Check if the position is inside circle1
func is_inside_circle1(pos: Vector2) -> bool:
	var screen_pos = get_screen_position(circle1_relative_position)
	if pos.distance_to(screen_pos) > circle1_radius:
		return false
	return true

# Handle touch input
func _input(event: InputEvent) -> void:
	if event is InputEventScreenTouch:
		if event.pressed:
			if is_inside_circle0(event.position):
				circle0_pressing = true
				circle0_index = event.index
				circle0_position = event.position  # Update position to current touch position
			elif is_inside_circle1(event.position):
				circle1_pressing = true
				circle1_index = event.index
				circle1_position = event.position  # Update position to current touch position
		else:
			if event.index == circle0_index: 
				circle0_pressing = false
				circle0_index = -1
			elif event.index == circle1_index: 
				circle1_pressing = false
				circle1_index = -1
	elif event is InputEventScreenDrag:
		if event.index == circle0_index:
			circle0_position = event.position  # Update position during drag
		elif event.index == circle1_index:
			circle1_position = event.position  # Update position during drag

# Update positions of circles when pressing or dragging
func _process(delta: float) -> void:
	# No need to move anything here since circles' positions are already updated in input events

# Draw the circles on screen
func _draw() -> void:
	# Draw circles at their positions
	draw_circle(circle0_position, circle0_radius, circle0_color)
	draw_circle(circle1_position, circle1_radius, circle1_color)
