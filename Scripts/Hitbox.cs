using Godot;
using System;

public partial class Hitbox : Area2D
{
    [Export] Node healthComponent;

    public void Hit()
    {
        healthComponent.Call("TakeDamage");
    }
}
