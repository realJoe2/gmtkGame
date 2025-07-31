using Godot;
using System;

public partial class EffectModule : Module
{
    [Export] Effect effect;
    enum Effect
    {
        Multiply
    }
}

public abstract partial class Module : Node2D
{
    public Module input;
    public Module output;
}
