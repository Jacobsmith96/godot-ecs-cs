using Godot;

public partial class CameraComponent : Component
{
    Camera3D camera3D;

    public CameraComponent()
    {
        camera3D = new Camera3D();
        camera3D.Name = "Camera3D";
        AddChild(camera3D);
    }
}
