using System.Diagnostics;
using System.Reflection.Metadata;
using Godot;

public partial class PlayerMovementExecutor : Executor
{
    World world;

    public PlayerMovementExecutor()
    {
        AddRequiredComponent<InputComponent>();
        AddRequiredComponent<PlayerComponent>();
        AddRequiredComponent<TransformComponent>();
        AddRequiredComponent<VelocityComponent>();
    }

    public override void _EnterTree()
    {
        world = GetNode<World>("/root/Main/World");
    }

    protected override void Update(Entity entity, double deltaTime)
    {
        HandleMovement(entity, deltaTime);
    }

    private void HandleMovement(Entity entity, double deltaTime)
    {
        InputComponent InputComponent = entity.GetComponent<InputComponent>();
        VelocityComponent velocityComponent = entity.GetComponent<VelocityComponent>();

        if (InputComponent.IsLeftPressed)
        {
            velocityComponent.Velocity = new Vector3(-1, 0, 0);
        }
        else if (InputComponent.IsRightPressed)
        {
            velocityComponent.Velocity = new Vector3(1, 0, 0);
        }
        else if (InputComponent.IsUpPressed)
        {
            velocityComponent.Velocity = new Vector3(0, 0, -1);
        }
        else if (InputComponent.IsDownPressed)
        {
            velocityComponent.Velocity = new Vector3(0, 0, 1);
        }
        else
        {
            velocityComponent.Velocity = new Vector3(0, 0, 0);
        }
    }
}
