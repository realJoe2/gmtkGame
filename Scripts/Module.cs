using Godot;
using System;

public partial class Module : Area2D
{
    /*
    modules can be grabbed by placing the mouse in their grab-box
    */

    bool mouseTouching = false;
    public void MouseEnter()
    {
        mouseTouching = true;
        GD.Print("yes");
    }
    public void MouseExit()
    {
        mouseTouching = false;
        GD.Print("no");
    }
    public override void _Process(double delta)
    {
        //GD.Print(mouseTouching);
    }
}
