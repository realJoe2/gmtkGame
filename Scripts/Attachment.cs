using Godot;
using System;

public partial class Attachment : Line2D
{
    Node2D parent;
    [Export] Area2D end;
    [Export] float firstPointOffset = 40F;
    [Export] AudioStreamPlayer connect;
    [Export] AudioStreamPlayer disconnect;
    bool entered;
    public override void _Ready()
    {
        parent = (Node2D)GetParent();
        SetPointPosition(0, ToLocal(parent.GlobalPosition) + Vector2.Right * firstPointOffset);
    }
    void Entered(Area2D a)
    {
        a.GetParent().Call("SetInputPiece", GetParent());
        //play a little animation which shows the piece is connected, such as turning a little light on
        connect.Play();
    }
    void Exited(Area2D a)
    {
        //play a little animation which shows the piece is disconnected, such as turning a little light off
        disconnect.Play();
    }

    public override void _Process(double delta)
    {
        SetPointPosition(1, end.Position);
    }
}
