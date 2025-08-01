using Godot;
using System;

public partial class GameManager : Node
{
    [Export] string defaultLevel;
    string currentLevelPath;

    public override void _Ready()
    {
        Engine.MaxFps = 60;

        ChangeLevel(defaultLevel);
    }

    Node currentLevel;
    PackedScene nextLevel;
    public void ChangeLevel(string levelPath)
    {
        currentLevelPath = levelPath;
        if (levelPath == null || levelPath == "" || !ResourceLoader.Exists(levelPath))
        {
            GD.PushError("Invalid level path");
            return;
        }

        if (currentLevel != null)
            currentLevel.QueueFree();

        nextLevel = (PackedScene)ResourceLoader.Load(levelPath);
        currentLevel = nextLevel.Instantiate();
        AddChild(currentLevel);
        GD.Print("Changed level to " + currentLevel.Name);
    }
    public void ResetLevel()
    {
        if (nextLevel == null)
        {
            GD.PushError("Level reset failed");
            return;
        }

        currentLevel.Free();
        currentLevel = nextLevel.Instantiate();
        AddChild(currentLevel);
    }
}

public partial class QuickFetch : Node
{
	//In order to keep the game running smoothly, resources should only be loaded during the "_Ready()" of whichever node instances them.
	public static PackedScene Fetch(string path)
	{
		if(ResourceLoader.Exists(path) == false)
		{
				GD.PushError("Path " + path + " invalid.");
				return null;
		}
		if(!ResourceLoader.HasCached(path))
			GD.Print("Loaded resource at path: " + path);
		return (PackedScene) ResourceLoader.Load(path, "", ResourceLoader.CacheMode.Reuse);
	}
}
