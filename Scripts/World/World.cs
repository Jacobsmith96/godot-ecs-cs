using System.Diagnostics;
using Godot;

public partial class World : Node
{
    Manager manager;

    public PlayerInputExecutor playerInputExecutor;
    public TransformExecutor transformExecutor;
    public VelocityExecutor velocityExecutor;
    public PlayerMovementExecutor playerMovementExecutor;

    public override void _Ready()
    {
        manager = new Manager();
        AddManager(manager);

        playerInputExecutor = new PlayerInputExecutor();
        transformExecutor = new TransformExecutor();
        velocityExecutor = new VelocityExecutor();
        playerMovementExecutor = new PlayerMovementExecutor();
        manager.AddExecutor(playerInputExecutor);
        manager.AddExecutor(transformExecutor);
        manager.AddExecutor(velocityExecutor);
        manager.AddExecutor(playerMovementExecutor);

        Player player = new Player(Colors.White);
        Camera camera = new Camera(
            new Vector3(0, 3f, 10f),
            new Vector3(Mathf.DegToRad(-20f), 0, 0)
        );
        Light light = new Light();
        Skybox skybox = new Skybox();

        manager.AddEntity(player);
        manager.AddEntity(camera);
        manager.AddEntity(light);
        manager.AddEntity(skybox);
    }

    public override void _Process(double delta)
    {
        manager.Update(delta);
        HandleQuit();
    }

    public void AddManager(Manager manager)
    {
        AddChild(manager);
    }

    public void HandleQuit()
    {
        if (Input.IsActionJustPressed("exit"))
        {
            GetTree().Quit();
        }
    }
}
