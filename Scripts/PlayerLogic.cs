using Godot;
using System;

public partial class PlayerLogic : Node
{
    [Export] int walkSpeed = 100;
    [Export] Node2D circuit;
    [Export] Button circuitButton;
    [Export] AnimatedSprite2D sprite;

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
        characterBody = (CharacterBody2D)GetParent();
        sprite.Play("Idle");
    }

    Vector2 inputDirection;
    float highest;
    public override void _PhysicsProcess(double delta)
    {
        inputDirection = Input.GetVector("Left", "Right", "Up", "Down");
        switch (state)
        {
            case PlayerState.Idle:
                break;

            case PlayerState.Walk:
                characterBody.Call("AddForce", inputDirection * walkSpeed);

                if (characterBody.Velocity == Vector2.Zero)
                {
                    sprite.Play("Idle");
                    break;
                }
                
                if (Mathf.Abs(characterBody.Velocity.Y) > Mathf.Abs(characterBody.Velocity.X))
                {
                    sprite.FlipH = false;
                    if (characterBody.Velocity.Y > 0)
                        sprite.Play("WalkForward");
                    else
                        sprite.Play("WalkBack");
                }
                else
                {
                    sprite.Play("WalkSide");
                    sprite.FlipH = characterBody.Velocity.X < 0;
                }
                break;

            case PlayerState.Dead:
                break;
        }
    }

    void CircuitButton()
    {
        circuitButton.Hide();
        circuit.Show();
        Engine.TimeScale = .03F;
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
