using Godot;
using System;

public partial class HealthComponent : Node
{
    [Export] int maxHealth = 1;
    [Export] bool shake;
    Timer shakeTimer;
    [Export] Node2D sprite;
    [Export] Timer iframes;
    bool canTakeDamage;

    int currentHealth;
    bool isDead = false;

    [Signal] public delegate void HealthDepletedEventHandler();

    public override void _Ready()
    {
        currentHealth = maxHealth;
        shakeTimer = (Timer)GetNode("Timer");
        //sprite = (Node2D) GetParent();
    }


    public override void _PhysicsProcess(double delta)
    {
        if (shakeTimer.TimeLeft > 0F && shake)
        {
            sprite.Rotation = Mathf.Sin((float)shakeTimer.TimeLeft) * (float) shakeTimer.TimeLeft;
        }
    }

    public void TakeDamage(int damage)
    {
        if (isDead)
            return;
        if (iframes != null)
        {
            if (iframes.TimeLeft > 0)
                return;
        }
        
        shakeTimer.Start();

        if (iframes != null)
            iframes.Start();
        
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            isDead = true;
            EmitSignal(SignalName.HealthDepleted);
        }
    }
}
