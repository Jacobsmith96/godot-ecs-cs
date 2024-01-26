using System.Diagnostics;
using System.Reflection.Metadata;
using Godot;

public partial class PlayerInputExecutor : Executor
{
    World world;

    public PlayerInputExecutor()
    {
        AddRequiredComponent<PlayerComponent>();
        AddRequiredComponent<InputComponent>();
    }

    public override void _EnterTree()
    {
        world = GetNode<World>("/root/Main/World");
    }

    protected override void Update(Entity entity, double deltaTime)
    {
        HandleInput(entity, deltaTime);
    }

    private void HandleInput(Entity entity, double deltaTime)
    {
        InputComponent InputComponent = entity.GetComponent<InputComponent>();
        InputComponent.IsLeftPressed = Input.IsActionPressed("left");
        InputComponent.IsRightPressed = Input.IsActionPressed("right");
        InputComponent.IsUpPressed = Input.IsActionPressed("up");
        InputComponent.IsDownPressed = Input.IsActionPressed("down");
    }
}
