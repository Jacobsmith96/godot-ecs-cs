using Godot;

public partial class Skybox : Entity
{
    public Skybox()
    {
        SkyboxComponent skyboxComponent = new SkyboxComponent();
        AddComponent(skyboxComponent);
    }
}
