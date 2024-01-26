using Godot;

public partial class SkyboxComponent : Component
{
    WorldEnvironment worldEnvironment;

    public SkyboxComponent()
    {
        worldEnvironment = new WorldEnvironment();
        Environment environment = new Environment();
        environment.BackgroundMode = Environment.BGMode.Sky;
        ProceduralSkyMaterial proceduralSkyMaterial = new ProceduralSkyMaterial();
        Sky sky = new Sky();
        sky.SkyMaterial = proceduralSkyMaterial;
        environment.Sky = sky;
        worldEnvironment.Environment = environment;
        worldEnvironment.Name = "WorldEnvironment";
        AddChild(worldEnvironment);
    }
}
