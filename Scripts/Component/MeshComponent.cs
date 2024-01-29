using Godot;

using Scripts.Enum;

public partial class MeshComponent : Component
{
    public MeshInstance3D meshInstance3D;

    public MeshComponent(Color color, MeshTypes meshType)
    {
        meshInstance3D = new MeshInstance3D();
        switch (meshType)
        {
            case MeshTypes.PLAYER:
                meshInstance3D.Mesh = new CapsuleMesh();
                break;
            case MeshTypes.PLATFORM:
                meshInstance3D.Mesh = new BoxMesh();
                break;
        }
        meshInstance3D.Name = "MeshInstance3D";
        StandardMaterial3D material = new StandardMaterial3D();
        material.AlbedoColor = color;
        meshInstance3D.MaterialOverride = material;
        AddChild(meshInstance3D);
    }
}
