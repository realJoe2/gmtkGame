using Godot;
using System;

public partial class WonderGun : Node2D
{
    public enum GunState
    {
        Idle,
        Fire
    }
    Node2D parent;
    GunState state;
    WeaponInfo stats;

    [Export] Timer delayTimer;
    const int distanceFromPlayer = 50;

    [Export] PackedScene bulletResource;
    [Export] PackedScene grenadeResource;

    public override void _Ready()
    {
        state = GunState.Idle;
        parent = (Node2D)GetParent();
        stats = new WeaponInfo();
    }

    Vector2 aimDirection;
    public override void _Process(double delta)
    {
        //point sprite at mouse
        aimDirection = (GetGlobalMousePosition() - parent.GlobalPosition).Normalized();
        if (Engine.TimeScale == 1F) //easy way of knowing if the circuit menu is open
            LookAt(GetGlobalMousePosition());

        if (state == GunState.Idle)
        {
            if (Input.IsActionPressed("Grab") && Engine.TimeScale == 1F)
            {
                ChangeState(GunState.Fire);
            }
        }
    }
    void ChangeState(GunState s)
    {
        if (state == s)
            return;
        state = s;

        switch (state)
        {
            case GunState.Idle:
                break;
            case GunState.Fire:
                Fire();
                delayTimer.Start();
                break;
        }
    }
    public void SetInfo(WeaponInfo newInfo)
    {
        if (newInfo == null)
            return;
        stats = newInfo;
        delayTimer.WaitTime = 1 / (float) stats.shotsPerSecond;
    }

    Projectile shot;
    void Fire()
    {
        switch (stats.shotType)
        {
            case 0:
                shot = (Bullet) bulletResource.Instantiate();
                break;
            case 1:
                //shot = (Grenade)bulletResource.Instantiate();
                break;
            default:
                return;
        }
        GetTree().GetNodesInGroup("Level")[0].AddChild(shot);
        shot.speed = stats.shotSpeed;
        shot.damage = stats.damagePerShot;
        shot.direction = (GetGlobalMousePosition() - GlobalPosition).Normalized();
        shot.GlobalPosition = GlobalPosition + (shot.direction * distanceFromPlayer);
    }

    void OnTimerTimeout()
    {
        ChangeState(GunState.Idle);
    }
}
