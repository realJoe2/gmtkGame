using Godot;
using System;

public partial class Bullet : Projectile
{
    void OnAreaEntered(Area2D a)
    {
        a.Call("Hit", damage);
        QueueFree();
    }
}

public partial class Projectile : Node2D
{
    public Vector2 direction;
    public int speed;
    public int damage;

    public override void _PhysicsProcess(double delta)
    {
        Position += direction * speed * (float) Engine.TimeScale;
    }
    
    void TimerTimeout()
    {
        QueueFree();
    }
}
