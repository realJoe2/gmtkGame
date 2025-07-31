using Godot;
using System;

public partial class EffectPiece : CircuitPiece
{
    [Export] Effect effect;
    enum Effect
    {
        Multiply
    }
}

public abstract partial class CircuitPiece : Node2D
{
    public CircuitPiece inputPiece;
    public void SetInputPiece(CircuitPiece i)
    {
        if (i == this)
        {
            return;
        }
        //GD.Print(i);
        inputPiece = i;
    }
}
