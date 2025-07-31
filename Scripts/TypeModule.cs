using Godot;
using System;

public partial class TypeModule : Node2D
{
    [Export] Type type;
    enum Type
    {
        Damage,
        Size,
        Speed
    }
}
