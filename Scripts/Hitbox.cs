using Godot;
using System;

public partial class Hitbox : Area2D
{
    [Export] Node healthComponent;

    public void Hit(int damage)
    {
        healthComponent.Call("TakeDamage", damage);
    }
}
