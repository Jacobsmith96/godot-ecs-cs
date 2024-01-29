using System.Diagnostics;
using System.Reflection.Metadata;
using Godot;

public partial class MeshExecutor : Executor
{
    World world;

    public MeshExecutor()
    {
        AddRequiredComponent<TransformComponent>();
        AddRequiredComponent<MeshComponent>();
    }

    public override void _EnterTree()
    {
        world = GetNode<World>("/root/Main/World");
    }

    protected override void Update(Entity entity, double deltaTime)
    {
        TransformComponent transformComponent = entity.GetComponent<TransformComponent>();
        MeshComponent meshComponent = entity.GetComponent<MeshComponent>();

        meshComponent.meshInstance3D.GlobalPosition = transformComponent.TransformPosition;
        meshComponent.meshInstance3D.GlobalRotation = transformComponent.TransformRotation;
        meshComponent.meshInstance3D.Scale = transformComponent.TransformScale;
    }
}
