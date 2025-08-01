using Godot;
using System;

public partial class Walker : Enemy
{
    float distanceToPlayer;
    [Export] float attackDistance = 10F;
    [Export] int moveSpeed = 1;
    Vector2 direction;
    public override void _PhysicsProcess(double delta)
    {
        distanceToPlayer = GlobalPosition.DistanceTo(player.GlobalPosition);
        //GD.Print(distanceToPlayer);
        switch (state)
        {
            case EnemyState.PursuePlayer:
                direction = (player.Position - Position).Normalized();
                Position += direction * moveSpeed * (float) Engine.TimeScale;
                if (distanceToPlayer < attackDistance)
                    ChangeState(EnemyState.Attack);
                break;
            case EnemyState.Attack:

                break;
            case EnemyState.Dead:

                break;
        }
    }

    void ChangeState(EnemyState s)
    {
        if (state == s)
            return;
        state = s;

        switch (state)
        {
            case EnemyState.PursuePlayer:
                //play run anim
                break;
            case EnemyState.Attack:
                GD.Print("Attack");
                //play attack anim
                break;
            case EnemyState.Dead:
                //play death anim
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
    public override void _Ready()
    {
        player = (CharacterBody2D)GetTree().GetNodesInGroup("Player")[0];
        state = EnemyState.PursuePlayer;
    }
}
