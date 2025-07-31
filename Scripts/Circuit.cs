using Godot;
using System;

public partial class Circuit : Node2D
{
    [Export] Button circuitButton;
    [Export] Node circuitHead;
    [Export] Node wonderGun;

    WeaponInfo info;
    public void EvaluateCircuit()
    {
        info = new WeaponInfo();
        //evaluate circuit (duh)
        //send results to wondergun as weaponinfo resource
        wonderGun.Call("SetInfo", info);
    }

    public void OnFinishButton()
    {
        EvaluateCircuit();
        Engine.TimeScale = 1F;
        circuitButton.Show();
        Hide();
    }
}
