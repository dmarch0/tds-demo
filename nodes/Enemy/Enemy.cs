using Godot;
using System;

public partial class Enemy : Area2D
{
	public Vector2 Direction;
	public float Speed = 5.0f;
	
	[Export]
	public PackedScene DeathEffectScene;

	public override void _Ready()
	{
		AreaEntered += HandleAreaEntered;
	}

	public override void _Process(double delta)
	{
		Position += Direction * Speed;
	}
	
	public void HandleAreaEntered(Area2D body)
	{
		if (body is Projectile)
		{
			QueueFree();
			
			EnemyDeathEffect effect = DeathEffectScene.Instantiate<EnemyDeathEffect>();
			effect.Position = Position;
			AddSibling(effect);
		}
	}
}
