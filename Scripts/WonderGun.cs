using Godot;
using System;

public partial class WonderGun : Node2D
{
    public enum GunState
    {
        Idle,
        Fire
    }
    GunState state;
    WeaponInfo stats;
    public override void _Ready()
    {
        state = GunState.Idle;
    }
    public override void _Process(double delta)
    {
        //point sprite at mouse

        if (state == GunState.Idle)
        {
            if (Input.IsActionJustPressed("Grab") && Engine.TimeScale == 1F)
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
                GD.Print("Blam!");
                ChangeState(GunState.Idle);
                break;
        }
    }
    public void SetInfo(WeaponInfo newInfo)
    {
        if (newInfo == null)
            return;
        stats = newInfo;
    }
}
