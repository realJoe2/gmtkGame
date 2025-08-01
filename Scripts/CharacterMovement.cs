using Godot;
using System;

public partial class CharacterMovement : CharacterBody2D
{
    [Export(PropertyHint.Range, "0,1,0.1")] float dragForce = .4F;

    Vector2 momentum = Vector2.Zero;
    Vector2 addedForce = Vector2.Zero;
    public override void _PhysicsProcess(double delta)
    {
        momentum = Velocity;

        //apply drag
        if (Mathf.Abs(momentum.X) > .1F)
            momentum.X -= momentum.X * dragForce;
        else
            momentum.X = 0F;
        if (Mathf.Abs(momentum.Y) > .1F)
            momentum.Y -= momentum.Y * dragForce;
        else
            momentum.Y = 0F;

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
