using Godot;
using System;

public partial class LevelChanger : Node
{
    Node gameManager;
    [Export] string nextLevelPath = "";
    public override void _Ready()
    {
        gameManager = GetTree().GetNodesInGroup("GameManager")[0];
    }
    public void Activate()
    {
        gameManager.Call("ChangeLevel", nextLevelPath);
    }
}
