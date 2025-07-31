using Godot;
using System;

public partial class TypeModule : CircuitPiece
{
    [Export] Type type;
    enum Type
    {
        Damage,
        Size,
        Speed
    }
}
