using Godot;
using System;

public partial class Projectile : Area2D
{
	public Vector2 Direction;
	public float Speed = 10.0f;

	public override void _Process(double delta)
	{
		Position += Direction * Speed;
	}
}
