using Godot;
using System;

public partial class ShotPiece : CircuitPiece
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
