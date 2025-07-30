using Godot;
using System;

public partial class CharacterMovement : CharacterBody2D
{
    [Export(PropertyHint.Range, "0,1,0.1")] float dragForce = .4F;
    [Export(PropertyHint.Range, "0,100,5")] float fallingForce = 40;
    [Export(PropertyHint.Range, "0,100,5")] float risingForce = 20;

    float gravityForce;
    Vector2 momentum = Vector2.Zero;
    Vector2 addedForce = Vector2.Zero;
    public override void _PhysicsProcess(double delta)
    {
        momentum = Velocity;

        if (momentum.Y <= 0F)
            gravityForce = risingForce;
        else
            gravityForce = fallingForce;

        //apply drag
        if (Mathf.Abs(momentum.X) > 0F)
            momentum.X -= momentum.X * dragForce;
        else
            momentum.X = 0F;

        //apply gravity
        if (IsOnFloor())
            momentum.Y = 0;
        else
            momentum.Y += gravityForce;

        if (IsOnCeiling() && momentum.Y < 0F)
            momentum.Y *= -.5F;

        momentum += addedForce;
        Velocity = momentum;
        MoveAndSlide();
    }


    public void AddForce(Vector2 force)
    {
        addedForce = force;
    }
    public Vector2 GetMomentum()
    {
        return momentum;
    }
}
