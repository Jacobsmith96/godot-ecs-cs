using Godot;

public partial class Player : Entity
{
    public Player(Color color)
    {
        TransformComponent transformComponent = new TransformComponent();
        InputComponent inputComponent = new InputComponent();
        MeshComponent meshComponent = new MeshComponent(color);
        VelocityComponent velocityComponent = new VelocityComponent();
        PlayerComponent playerComponent = new PlayerComponent();
        AddComponent(transformComponent);
        AddComponent(inputComponent);
        AddComponent(meshComponent);
        AddComponent(velocityComponent);
        AddComponent(playerComponent);
    }
}
