using Godot;

using Scripts.Enum;

public partial class Player : Entity
{
    public Player(Vector3 position, Color color)
    {
        TransformComponent transformComponent = new TransformComponent(position);
        InputComponent inputComponent = new InputComponent();
        MeshComponent meshComponent = new MeshComponent(color, MeshTypes.PLAYER);
        VelocityComponent velocityComponent = new VelocityComponent();
        PhysicsComponent physicsComponent = new PhysicsComponent();
        PlayerComponent playerComponent = new PlayerComponent();
        CharacterBodyComponent characterBodyComponent = new CharacterBodyComponent();
        AddComponent(transformComponent);
        AddComponent(inputComponent);
        AddComponent(meshComponent);
        AddComponent(velocityComponent);
        AddComponent(physicsComponent);
        AddComponent(playerComponent);
        AddComponent(characterBodyComponent);
    }
}
