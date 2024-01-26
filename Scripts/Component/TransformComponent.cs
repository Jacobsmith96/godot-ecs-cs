using Godot;

public partial class TransformComponent : Component
{
    public Vector3 TransformPosition;
    public Vector3 TransformRotation;
    public Vector3 TransformScale;

    public TransformComponent()
    {
        TransformPosition = new Vector3(0, 0, 0);
        TransformRotation = new Vector3(0, 0, 0);
        TransformScale = new Vector3(1, 1, 1);
    }

    public TransformComponent(Vector3 position, Vector3 rotation, Vector3 scale)
    {
        TransformPosition = position;
        TransformRotation = rotation;
        TransformScale = scale;
    }

    public TransformComponent(Vector3 position)
    {
        TransformPosition = position;
        TransformRotation = new Vector3(0, 0, 0);
        TransformScale = new Vector3(1, 1, 1);
    }
}
