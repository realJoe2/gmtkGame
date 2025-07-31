using Godot;
using System;

public partial class EffectModule : CircuitPiece
{
    [Export] Effect effect;
    enum Effect
    {
        Multiply
    }
}

public abstract partial class CircuitPiece : Node2D
{
    public CircuitPiece input;
    public CircuitPiece output;
}
