using System.Diagnostics;
using System.Reflection.Metadata;
using Godot;

public partial class CameraExecutor : Executor
{
    World world;

    public CameraExecutor()
    {
        AddRequiredComponent<TransformComponent>();
        AddRequiredComponent<CameraComponent>();
    }

    public override void _EnterTree()
    {
        world = GetNode<World>("/root/Main/World");
    }

    protected override void Update(Entity entity, double deltaTime)
    {
        TransformComponent transformComponent = entity.GetComponent<TransformComponent>();
        CameraComponent cameraComponent = entity.GetComponent<CameraComponent>();

        cameraComponent.camera3D.GlobalPosition = transformComponent.TransformPosition;
        cameraComponent.camera3D.GlobalRotation = transformComponent.TransformRotation;
        cameraComponent.camera3D.Scale = transformComponent.TransformScale;
    }
}
