using Godot;
using Scripts.Enum;

public partial class Platform : Entity
{
    public Platform(Vector3 position, Vector3 rotation, Vector3 scale, Color color)
    {
        TransformComponent transformComponent = new TransformComponent(position, rotation, scale);
        StaticBodyComponent staticBodyComponent = new StaticBodyComponent();
        MeshComponent meshComponent = new MeshComponent(color, MeshTypes.PLATFORM);
        PhysicsComponent physicsComponent = new PhysicsComponent();
        AddComponent(transformComponent);
        AddComponent(meshComponent);
        AddComponent(physicsComponent);
        AddComponent(staticBodyComponent);
    }
}
