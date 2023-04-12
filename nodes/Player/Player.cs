using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export]
	public float Speed = 100.0f;
	
	[Export]
	public float RotationOffset = 0.0f;
	[Export]
	public PackedScene ProjectileScene;
	
	public bool IsShooting = false;
	
	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event.IsActionPressed("Space"))
		{
			IsShooting = true;
		}
		else if (@event.IsActionReleased("Space")) 
		{
			IsShooting = false;
		}
	}
	
	public override void _PhysicsProcess(double delta) {
		Vector2 direction = GetDirection();
		Velocity = direction * Speed;\
		
		if (!direction.IsZeroApprox())
		{
			Rotation = Velocity.Angle() + Mathf.DegToRad(RotationOffset);
		}
		
		MoveAndSlide();
		
		if (IsShooting)
		{
			Shoot();
		}
	}
	
	public Vector2 GetDirection() {
		Vector2 direction = Vector2.Zero;
		if (!Controlled) return direction;
		direction[0] = Input.GetAxis("MoveLeft", "MoveRight");
		direction[1] = Input.GetAxis("MoveUp", "MoveDown");
		return direction;
	}

	public void Shoot()
	{
		Projectile projectile = ProjectileScene.Instantiate<Projectile>();
		Vector2 direction = (new Vector2(1, 0)).Rotated(Rotation - Mathf.DegToRad(RotationOffset));
		projectile.Direction = direction; 
		projectile.Position = Position;
		AddSibling(projectile);
	}
}
