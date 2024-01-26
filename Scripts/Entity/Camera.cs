using Godot;

public partial class Camera : Entity
{
    public Camera(Vector3 position, Vector3 rotation)
    {
        CameraComponent cameraComponent = new CameraComponent();
        TransformComponent transformComponent = new TransformComponent(
            position,
            rotation,
            new Vector3(1, 1, 1)
        );

        AddComponent(cameraComponent);
        AddComponent(transformComponent);
    }
}
