using Godot;
using System;

public partial class Hurtbox : Area2D
{
    [Export] int damage;
    [Export] bool removeParentOnHit = false;
    void OnEnter(Hitbox h)
    {
        h.Hit(damage);
        if (removeParentOnHit)
            GetParent().QueueFree();
    }
}
