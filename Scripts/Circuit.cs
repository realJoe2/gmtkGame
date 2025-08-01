using Godot;
using System;

public partial class Circuit : Node2D
{
    [Export] Button circuitButton;
    [Export] CircuitPiece circuitHead;
    [Export] Node wonderGun;

    WeaponInfo info;
    CircuitPiece current;
    int terminator = 0;
    public void EvaluateCircuit()
    {
        info = new WeaponInfo();
        current = circuitHead.inputPiece;
        string property = "";
        while (current != circuitHead && current != null)
        {
            if (current is ShotPiece)
            {
                info.shotType = (byte)current.Call("GetShot");
                property = "shotPiece";
            }
            else if (current is ModifierPiece)
            {
                property = (string)current.Call("GetModifier");
            }
            else if (current is EffectPiece)
            {
                switch (property)
                {
                    case "shotPiece":
                        info.numberOfBarrels *= 2;
                        break;
                    case "damage":
                        info.damagePerShot *= 2;
                        break;
                    case "shotSpeed":
                        info.shotSpeed *= 2;
                        break;
                    case "shotsPerSecond":
                        info.shotsPerSecond *= 2;
                        break;
                    default:
                        break;
                }
            }
            current = current.inputPiece;
            terminator++;
        }

        if (current == null)
        {
            GD.Print("Set as default");
            info = new WeaponInfo();
        }
        //send results to wondergun as weaponinfo resource
            wonderGun.Call("SetInfo", info);
    }

    public void OnFinishButton()
    {
        EvaluateCircuit();
        Engine.TimeScale = 1F;
        circuitButton.Show();
        Hide();
    }
}
