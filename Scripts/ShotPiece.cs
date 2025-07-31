using Godot;
using System;

public partial class ShotPiece : CircuitPiece
{
    [Export] Shot shot;
    public enum Shot
    {
        Bullet,
        Grenade,
        Laser,
        Arrow,
        Random,
        Battery
    }
    public byte GetShot()
    {
        return (byte) shot;
    }
}
