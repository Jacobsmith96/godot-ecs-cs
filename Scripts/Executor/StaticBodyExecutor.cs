using System.Diagnostics;
using System.Reflection.Metadata;
using Godot;

public partial class StaticBodyExecutor : Executor
{
    World world;

    public StaticBodyExecutor()
    {
        AddRequiredComponent<TransformComponent>();
        AddRequiredComponent<StaticBodyComponent>();
    }

    public override void _EnterTree()
    {
        world = GetNode<World>("/root/Main/World");
    }

    protected override void Update(Entity entity, double deltaTime)
    {
        TransformComponent transformComponent = entity.GetComponent<TransformComponent>();
        StaticBodyComponent staticBodyComponent = entity.GetComponent<StaticBodyComponent>();

        staticBodyComponent.staticBody3D.GlobalPosition = transformComponent.TransformPosition;
        staticBodyComponent.staticBody3D.GlobalRotation = transformComponent.TransformRotation;
        staticBodyComponent.staticBody3D.Scale = transformComponent.TransformScale;
    }
}
