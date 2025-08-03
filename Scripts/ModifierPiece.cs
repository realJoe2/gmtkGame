using Godot;
using System;

public partial class ModifierPiece : CircuitPiece
{
    Modifier type;
    public enum Modifier
    {
        Damage,
        ShotSpeed,
        ShotsPerSecond
    }
    public override void _Ready()
    {
        type = (Modifier) (GD.Randi() % 2);
        label.Text = GetModifier();
    }
    public string GetModifier()
    {
        switch (type)
        {
            case Modifier.Damage:
                return "damage";
            case Modifier.ShotSpeed:
                return "shotSpeed";
            default:
                return "shotsPerSecond";
        }
    }
}
