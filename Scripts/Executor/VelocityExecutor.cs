using System.Diagnostics;
using System.Reflection.Metadata;
using Godot;

public partial class VelocityExecutor : Executor
{
    World world;

    public VelocityExecutor()
    {
        AddRequiredComponent<TransformComponent>();
        AddRequiredComponent<VelocityComponent>();
    }

    public override void _EnterTree()
    {
        world = GetNode<World>("/root/Main/World");
    }

    protected override void Update(Entity entity, double deltaTime)
    {
        HandleVelocity(entity, deltaTime);
    }

    private void HandleVelocity(Entity entity, double deltaTime)
    {
        TransformComponent transformComponent = entity.GetComponent<TransformComponent>();
        VelocityComponent velocityComponent = entity.GetComponent<VelocityComponent>();

        transformComponent.TransformPosition =
            transformComponent.TransformPosition
            + velocityComponent.Velocity * velocityComponent.Speed * (float)deltaTime;
    }
}
