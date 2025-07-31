using Godot;
using System;

public partial class Attachment : Line2D
{
    CircuitPiece parent;
    [Export] Area2D end;
    [Export] float firstPointOffset = 40F;
    [Export] AudioStreamPlayer connect;
    [Export] AudioStreamPlayer disconnect;
    bool entered;
    public override void _Ready()
    {
        parent = (CircuitPiece) GetParent();
        SetPointPosition(0, ToLocal(parent.GlobalPosition) + Vector2.Right * firstPointOffset);
    }
    CircuitPiece input;
    void Entered(Area2D a)
    {
        input = (CircuitPiece) a.GetParent();
        input.SetInputPiece((CircuitPiece) GetParent());
        //play a little animation which shows the piece is connected, such as turning a little light on
        connect.Play();
    }
    void Exited(Area2D a)
    {
        input = (CircuitPiece) a.GetParent();
        input.SetInputPiece(null);
        //play a little animation which shows the piece is disconnected, such as turning a little light off
        disconnect.Play();
    }

    public override void _Process(double delta)
    {
        SetPointPosition(1, end.Position);
    }
}
