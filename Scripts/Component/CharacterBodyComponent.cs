using Godot;

public partial class CharacterBodyComponent : Component
{
    public CharacterBody3D characterBody3D;

    public CharacterBodyComponent()
    {
        characterBody3D = new CharacterBody3D();
        characterBody3D.Name = "CharacterBody3D";
        CollisionShape3D collisionShape3D = new CollisionShape3D();
        collisionShape3D.Shape = new CapsuleShape3D();
        characterBody3D.AddChild(collisionShape3D);
        AddChild(characterBody3D);
    }
}
