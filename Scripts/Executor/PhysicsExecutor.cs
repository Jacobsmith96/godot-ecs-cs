using System.Diagnostics;
using System.Reflection.Metadata;
using Godot;

public partial class PhysicsExecutor : Executor
{
    World world;

    public PhysicsExecutor()
    {
        AddRequiredComponent<PhysicsComponent>();
        AddRequiredComponent<VelocityComponent>();
    }

    public override void _EnterTree()
    {
        world = GetNode<World>("/root/Main/World");
    }

    protected override void Update(Entity entity, double deltaTime)
    {
        PhysicsComponent physicsComponent = entity.GetComponent<PhysicsComponent>();
        VelocityComponent velocityComponent = entity.GetComponent<VelocityComponent>();

        velocityComponent.Velocity += physicsComponent.Gravity * (float)deltaTime;
    }
}
