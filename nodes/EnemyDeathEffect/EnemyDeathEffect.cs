using Godot;
using System;

public partial class EnemyDeathEffect : GpuParticles2D
{
	public override void _Ready()
	{
		GetNode<Timer>("Lifetime").Timeout += QueueFree;
		GetNode<AudioStreamPlayer2D>("Sound").Play();
	}
}
