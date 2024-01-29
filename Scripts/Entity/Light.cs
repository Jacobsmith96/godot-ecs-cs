using Godot;

public partial class Light : Entity
{
    public Light(Vector3 position)
    {
        LightComponent lightComponent = new LightComponent();
        TransformComponent transformComponent = new TransformComponent();
        transformComponent.TransformPosition = position;

        AddComponent(lightComponent);
        AddComponent(transformComponent);
    }
}
