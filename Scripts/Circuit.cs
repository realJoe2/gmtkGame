using Godot;
using System;

public partial class Circuit : Node2D
{
    [Export] Button circuitButton;

    public void EvaluateCircuit()
    {
        
    }

    public void OnFinishButton()
    {
        EvaluateCircuit();
        GetTree().Paused = false;
        circuitButton.Show();
        Hide();
    }
}
