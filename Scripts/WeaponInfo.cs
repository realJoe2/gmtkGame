using Godot;
using System;

public partial class WeaponInfo : Resource
{
    public enum ShotType
    {
        Bullet, //single hitscan shot that deals decent damage
        Grenade, //projectile that explodes after a short delay, dealing AOE
        Laser, //beam that deals continuous damage
        Arrow //deals low damage but pierces enemies
    }
    public ShotType type;
    public int damagePerShot;
    public int numberOfBarrels;
}
