using Godot;

public partial class VelocityComponent : Component
{
    public Vector3 Velocity;
    public float Speed = 2;

    public VelocityComponent()
    {
        Velocity = new Vector3(0, 0, 0);
    }
}
