using Godot;
using System;

public partial class EffectPiece : CircuitPiece
{
    public override void _Ready()
    {
        label.Text = "double";
    }
    [Export] Effect effect;
    enum Effect
    {
        Multiply
    }
}

public abstract partial class CircuitPiece : Node2D
{
    public CircuitPiece inputPiece;
    [Export] Texture2D onSprite;
    [Export] public Label label;
    [Export] Texture2D offSprite;
    [Export] Sprite2D sprite;
    public void SetInputPiece(CircuitPiece i)
    {
        if (i == this)
        {
            return;
        }
        //GD.Print(i);
        inputPiece = i;
        
        //set sprite
        if (inputPiece == null)
        {
            sprite.Texture = offSprite;
        }
        else
        {
            sprite.Texture = onSprite;
        }
    }
}
