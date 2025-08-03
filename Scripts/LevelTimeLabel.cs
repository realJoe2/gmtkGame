using Godot;
using System;

public partial class LevelTimeLabel : Label
{
    [Export] Timer timer;
    int minutes;
    int seconds;
    public override void _Process(double delta)
    {
        if (Engine.GetFramesDrawn() % 60 == 0)
        {
            minutes = (int)timer.TimeLeft / 60;
            seconds = (int)timer.TimeLeft % 60;
            Text = minutes + ":" + seconds;
        }
    }
}
