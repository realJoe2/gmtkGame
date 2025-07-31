using Godot;
using System;

public partial class ShotModule : CircuitPiece
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
