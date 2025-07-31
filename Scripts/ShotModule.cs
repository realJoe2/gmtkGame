using Godot;
using System;

public partial class ShotModule : Module
{
    [Export] Shot shot;
    enum Shot
    {
        Bullet,
        Grenade,
        Laser,
        Arrow,
        Battery
    }
}
