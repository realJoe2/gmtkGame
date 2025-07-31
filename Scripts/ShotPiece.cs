using Godot;
using System;

public partial class ShotPiece : CircuitPiece
{
    public override void _Ready()
    {
        switch (shot)
        {
            case Shot.Bullet:
                label.Text = "bullet";
                break;
            case Shot.Grenade:
                label.Text = "grenade";
                break;
            case Shot.Laser:
                label.Text = "laser";
                break;
            case Shot.Arrow:
                label.Text = "arrow";
                break;
            case Shot.Random:
                label.Text = "random";
                break;
            default:
                label.Text = "battery";
                break;
        }
    }
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
