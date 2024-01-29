using System;
using Godot;

public partial class StaticBodyComponent : Component
{
    public StaticBody3D staticBody3D;

    public StaticBodyComponent()
    {
        staticBody3D = new StaticBody3D();
        staticBody3D.Name = "StaticBody3D";
        CollisionShape3D collisionShape3D = new CollisionShape3D();
        collisionShape3D.Shape = new BoxShape3D();
        staticBody3D.AddChild(collisionShape3D);
        AddChild(staticBody3D);
    }
}
