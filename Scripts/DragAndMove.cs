using Godot;
using System;
using System.Numerics;

public partial class DragAndMove : Control
{
    Node2D parent;
    bool mouseTouching;
    bool grabbed;
    Godot.Vector2 offset;

    public override void _Ready()
    {
        parent = (Node2D) GetParent();
    }

    void MouseEnter()
    {
        mouseTouching = true;
    }
    void MouseExit()
    {
        mouseTouching = false;
    }

    Godot.Vector2 target;
    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("Grab") && mouseTouching)
        {
            grabbed = true;
            offset = GetGlobalMousePosition() - parent.GlobalPosition;
        }
        if (Input.IsActionJustReleased("Grab"))
            grabbed = false;

        if (grabbed)
        {
            parent.GlobalPosition = GetGlobalMousePosition() - offset;
        }
        
    }
}
