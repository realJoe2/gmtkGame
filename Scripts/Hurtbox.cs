using Godot;
using System;

public partial class Hurtbox : Area2D
{
    int damage;
    void SetDamage(int d)
    {
        damage = d;
    }
    [Export] bool removeParentOnHit = false;
    void OnEnter(Hitbox h)
    {
        h.Hit(damage);
        //GD.Print(damage);
        if (removeParentOnHit)
            GetParent().QueueFree();
    }
}
