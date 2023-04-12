using Godot;
using System;

public partial class Main : Node2D
{
	[Export]
	public PackedScene EnemyScene;
	
	public override void _Ready()
	{
		GetNode<Timer>("EnemyTimer").Timeout += HandleEnemyTimerTimeout;
	}

	public override void _Process(double delta)
	{
		
	}
	
	public void HandleEnemyTimerTimeout()
	{
		RandomNumberGenerator random = new RandomNumberGenerator();
		random.Randomize();
		
		Enemy enemy = EnemyScene.Instantiate<Enemy>();
		enemy.Position = new Vector2(random.RandfRange(0.0f, 480.0f), 0.0f);
		enemy.Direction = new Vector2(0, 1);
		enemy.Speed = random.RandfRange(2.0f, 7.0f);
		AddChild(enemy);
	}
}
