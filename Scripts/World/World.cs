using System.Diagnostics;
using Godot;

public partial class World : Node
{
    Manager manager;

    public InputExecutor inputExecutor;
    public PhysicsExecutor physicsExecutor;
    public MeshExecutor meshExecutor;
    public MovementExecutor movementExecutor;
    public StaticBodyExecutor staticBodyExecutor;
    public CameraExecutor cameraExecutor;

    public override void _Ready()
    {
        // Instantiate Manager and add it to scene
        manager = new Manager();
        AddManager(manager);

        // Instantiate Executors and add them to Manager
        inputExecutor = new InputExecutor();
        physicsExecutor = new PhysicsExecutor();
        meshExecutor = new MeshExecutor();
        movementExecutor = new MovementExecutor();
        staticBodyExecutor = new StaticBodyExecutor();
        cameraExecutor = new CameraExecutor();

        manager.AddExecutor(inputExecutor);
        manager.AddExecutor(physicsExecutor);
        manager.AddExecutor(meshExecutor);
        manager.AddExecutor(movementExecutor);
        manager.AddExecutor(staticBodyExecutor);
        manager.AddExecutor(cameraExecutor);

        // Instantiate Entities and add them to Manager
        Player player = new Player(new Vector3(0, 0, 0), Colors.White);
        Platform platform = new Platform(
            new Vector3(0, -4, 0),
            new Vector3(0, 0, 0),
            new Vector3(10, 1, 10),
            Colors.White
        );
        Camera camera = new Camera(
            new Vector3(0, 2f, 10f),
            new Vector3(Mathf.DegToRad(-20f), 0, 0)
        );
        Light light = new Light(new Vector3(0, 0, 10));
        Skybox skybox = new Skybox();

        manager.AddEntity(player);
        manager.AddEntity(platform);
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
        if (Input.IsActionJustPressed("quit"))
        {
            GetTree().Quit();
        }
    }
}
