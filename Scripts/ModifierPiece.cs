using Godot;
using System;

public partial class ModifierPiece : CircuitPiece
{
    [Export] Modifier type;
    public enum Modifier
    {
        Damage,
        ShotSpeed,
        ShotsPerSecond
    }
    public override void _Ready()
    {
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
