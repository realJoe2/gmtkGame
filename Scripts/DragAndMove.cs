using Godot;
using System;
using System.Numerics;

public partial class DragAndMove : Control
{
    Node2D parent;
    bool mouseTouching;
    bool grabbed;
    Godot.Vector2 offset;
    [Export] bool canRotate = true;
    [Export] bool careIfOffScreen = false;
    [Export] VisibleOnScreenNotifier2D vis;

    public override void _Ready()
    {
        parent = (Node2D)GetParent();
        camera = (Node2D)GetTree().GetNodesInGroup("Camera")[0];
    }

    void MouseEnter()
    {
        mouseTouching = true;
    }
    void MouseExit()
    {
        mouseTouching = false;
    }

    Node2D camera;
    void OffScreen()
    {
        grabbed = false;
        parent.GlobalPosition = camera.GlobalPosition;
    }

    Godot.Vector2 target;
    public override void _Process(double delta)
    {
        if(!vis.IsOnScreen() && grabbed && careIfOffScreen)
            OffScreen();
        
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
            if (Input.IsActionJustPressed("RotateModule") && canRotate)
            {
                parent.GlobalRotation += 45F * (Mathf.Pi / 180F);
            }
        }
        
    }
}
