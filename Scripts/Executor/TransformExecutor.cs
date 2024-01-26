using System.Diagnostics;
using System.Reflection.Metadata;
using Godot;

public partial class TransformExecutor : Executor
{
    World world;

    public TransformExecutor()
    {
        AddRequiredComponent<TransformComponent>();
    }

    public override void _EnterTree()
    {
        world = GetNode<World>("/root/Main/World");
    }

    protected override void Update(Entity entity, double deltaTime)
    {
        UpdateTransform(entity, deltaTime);
    }

    private void UpdateTransform(Entity entity, double deltaTime)
    {
        TransformComponent transformComponent = entity.GetComponent<TransformComponent>();
        entity.Position = transformComponent.TransformPosition;
        entity.Rotation = transformComponent.TransformRotation;
        entity.Scale = transformComponent.TransformScale;
    }
}
