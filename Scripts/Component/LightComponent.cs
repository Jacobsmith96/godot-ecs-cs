using Godot;

public partial class LightComponent : Component
{
    DirectionalLight3D directionalLight3D;

    public LightComponent()
    {
        directionalLight3D = new DirectionalLight3D();
        directionalLight3D.Name = "DirectionalLight3D";
        AddChild(directionalLight3D);
    }
}
