using Godot;

public partial class VelocityComponent : Component
{
    public Vector3 Velocity;

    public int maxX = 10;
    public int maxZ = 10;

    public float jumpSpeed = 5f;

    public VelocityComponent()
    {
        Velocity = new Vector3(0, 0, 0);
    }
}
