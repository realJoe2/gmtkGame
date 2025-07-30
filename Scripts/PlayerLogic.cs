using Godot;
using System;

public partial class PlayerLogic : Node
{
    [Export] int walkSpeed = 100;
    [Export] Node2D circuit;
    [Export] Button circuitButton;

    enum PlayerState
    {
        Idle,
        Walk,
        Dead
    }
    PlayerState state = PlayerState.Walk;

    CharacterBody2D characterBody;
    public override void _Ready()
    {
        characterBody = (CharacterBody2D) GetParent();
    }

    Vector2 inputDirection;
    public override void _Process(double delta)
    {
        inputDirection = Input.GetVector("Left", "Right", "Up", "Down");

        switch (state)
        {
            case PlayerState.Idle:
                break;

            case PlayerState.Walk:
                characterBody.Call("AddForce", inputDirection * walkSpeed);
                break;

            case PlayerState.Dead:
                break;
        }
    }

    void CircuitButton()
    {
        circuitButton.Hide();
        circuit.Show();
        GetTree().Paused = true;
    }
    void ChangeState(PlayerState s)
    {
        if (state == s)
            return;
        state = s;

        switch (state)
        {
            case PlayerState.Idle:
                break;

            case PlayerState.Walk:
                break;

            case PlayerState.Dead:
                break;
        }
    }
}
