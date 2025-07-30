using Godot;
using System;

public partial class HealthComponent : Node
{
    [Export] int maxHealth = 1;
    [Export] Timer timer;
    int currentHealth;
    bool isDead = false;
    bool hasIFrames = false;

    [Signal] public delegate void HealthDepletedEventHandler();

    public override void _Ready()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (isDead || hasIFrames)
            return;

        if (timer.WaitTime > 0.1)
        {
            hasIFrames = true;
            timer.Start();
        }
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            isDead = true;
            EmitSignal(SignalName.HealthDepleted);
        }
    }

    void OnTimerTimeout()
    {
        hasIFrames = false;
    }
}
