using Godot;
using System;

public partial class Walker : Enemy
{
    float distanceToPlayer;
    [Export] float attackDistance;
    [Export] int moveSpeed;
    [Export] AnimatedSprite2D sprite;
    [Export] Hurtbox hurter;
    [Export] AudioStreamPlayer2D walkerSounds;
    [Export] AudioStream hit;
    [Export] AudioStream death;
    Vector2 direction;
    public override void _Ready()
    {
        ChangeState(EnemyState.PursuePlayer);
        player = (CharacterBody2D)GetTree().GetNodesInGroup("Player")[0];
    }

    public override void _PhysicsProcess(double delta)
    {
        if (state != EnemyState.Dead)
        {
            distanceToPlayer = Position.DistanceTo(player.Position);
            direction = (player.Position - Position).Normalized();
            Position += direction * moveSpeed * (float)Engine.TimeScale;
        }
        
        switch (state)
        {
            case EnemyState.PursuePlayer:
                if (Mathf.Abs(direction.Y) > Mathf.Abs(direction.X))
                {
                    sprite.FlipH = false;
                    if (direction.Y > 0)
                        sprite.Play("WalkForward");
                    else
                        sprite.Play("WalkBack");
                }
                else
                {
                    sprite.Play("WalkSide");
                    sprite.FlipH = direction.X < 0;
                }

                if (distanceToPlayer < attackDistance)
                    ChangeState(EnemyState.Attack);
                break;

            case EnemyState.Attack:
                hurter.SetDeferred("monitoring", sprite.Frame == 4);
                if (sprite.Frame == 7)
                {
                    ChangeState(EnemyState.PursuePlayer);
                }
                break;
            case EnemyState.Dead:
                if (sprite.Frame == 7)
                    QueueFree();
                break;
        }
    }
    void Death()
    {
        ChangeState(EnemyState.Dead);
    }
    void ChangeState(EnemyState s)
    {
        if (state == s)
            return;
        
        state = s;
        //GD.Print(this.state);
        switch (state)
        {
            case EnemyState.PursuePlayer:
                //play
                break;
            case EnemyState.Attack:
                walkerSounds.Stream = hit;
                walkerSounds.PitchScale = (float) GD.Randfn(1.0, .05);
                walkerSounds.Play();
                if (Mathf.Abs(direction.Y) > Mathf.Abs(direction.X))
                {
                    sprite.FlipH = false;
                    if (direction.Y > 0)
                        sprite.Play("AttackForward");
                    else
                        sprite.Play("AttackBack");
                }
                else
                {
                    sprite.Play("AttackSide");
                    sprite.FlipH = direction.X < 0;
                }
                //play attack anim
                break;
            case EnemyState.Dead:
                walkerSounds.Stream = death;
                walkerSounds.PitchScale = (float) GD.Randfn(1.0, .05);
                walkerSounds.Play();
                //play death anim
                sprite.Play("Death");
                break;
        }
    }
}

public partial class Enemy : Node2D
{
    public enum EnemyState
    {
        PursuePlayer,
        Attack,
        Dead
    }
    public CharacterBody2D player;
    public EnemyState state;
}
