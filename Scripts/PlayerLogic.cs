using Godot;
using System;

public partial class PlayerLogic : Node
{
    [Export] int walkSpeed = 100;
    [Export] int jumpHeight = 12;
    [Export] byte defaultCoyoteBuffer = 6;
    [Export] byte defaultJumpBuffer = 6;

    enum PlayerState
    {
        Idle,
        Walk,
        Airborne,
        Dead
    }
    PlayerState state = PlayerState.Walk;

    CharacterBody2D characterBody;
    public override void _Ready()
    {
        characterBody = (CharacterBody2D) GetParent();
    }

    Vector2 inputDirection;
    byte jumpBuffer, coyoteBuffer = 0;
    public override void _Process(double delta)
    {
        inputDirection.X = Input.GetAxis("Left", "Right");

        if (jumpBuffer > 0)
            jumpBuffer--;
        if (coyoteBuffer > 0)
            coyoteBuffer--;
        
        switch (state)
        {
            case PlayerState.Idle:
                break;

            case PlayerState.Walk:
                characterBody.Call("AddForce", inputDirection * walkSpeed);

                if (Input.IsActionJustPressed("Jump") || jumpBuffer > 0)
                {
                    jumpBuffer = 0;
                    characterBody.Call("AddForce", Vector2.Up * jumpHeight);
                }

                if (characterBody.IsOnFloor() == false)
                {
                    ChangeState(PlayerState.Airborne);
                    coyoteBuffer = defaultCoyoteBuffer;
                }
                
                break;

            case PlayerState.Airborne:
                characterBody.Call("AddForce", inputDirection * walkSpeed);
                
                if (Input.IsActionJustPressed("Jump"))
                {
                    Vector2 yForce = (Vector2) characterBody.Call("GetMomentum");
                    if (coyoteBuffer > 0 && yForce.Y >= 0)
                        characterBody.Call("AddForce", Vector2.Up * jumpHeight);

                    coyoteBuffer = 0;
                    jumpBuffer = defaultJumpBuffer;
                }

                if (characterBody.IsOnFloor() == true)
                    ChangeState(PlayerState.Walk);
                break;

            case PlayerState.Dead:
                break;
        }
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

            case PlayerState.Airborne:
                break;

            case PlayerState.Dead:
                break;
        }
    }
}
