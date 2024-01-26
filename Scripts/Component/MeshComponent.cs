using Godot;

public partial class MeshComponent : Component
{
    MeshInstance3D meshInstance3D;

    public MeshComponent(Color color)
    {
        MeshInstance3D mesh = new MeshInstance3D();
        mesh.Mesh = new CapsuleMesh();
        mesh.Name = "MeshInstance3D";
        StandardMaterial3D material = new StandardMaterial3D();
        material.AlbedoColor = color;
        mesh.MaterialOverride = material;
        AddChild(mesh);
    }
}
