using Godot;

public partial class Light : Entity
{
    public Light()
    {
        LightComponent lightComponent = new LightComponent();
        TransformComponent transformComponent = new TransformComponent(new Vector3(0, 0, 10));
        AddComponent(lightComponent);
        AddComponent(transformComponent);
    }
}
