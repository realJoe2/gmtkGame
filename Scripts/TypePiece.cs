using Godot;
using System;

public partial class TypePiece : CircuitPiece
{
    [Export] Type type;
    enum Type
    {
        Damage,
        Size,
        Speed
    }
}
