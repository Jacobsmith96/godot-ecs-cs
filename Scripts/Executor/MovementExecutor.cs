using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using Godot;

public partial class MovementExecutor : Executor
{
    World world;

    public MovementExecutor()
    {
        AddRequiredComponent<TransformComponent>();
        AddRequiredComponent<VelocityComponent>();
        AddRequiredComponent<CharacterBodyComponent>();
    }

    public override void _EnterTree()
    {
        world = GetNode<World>("/root/Main/World");
    }

    public override void UpdateEntities(double deltaTime)
    {
        foreach (Entity entity in Entities)
        {
            Update(entity, deltaTime);
            if (entity.HasComponent(typeof(PlayerComponent)))
            {
                CheckPlayerGrounded(entity);
            }
        }
    }

    protected override void Update(Entity entity, double deltaTime)
    {
        TransformComponent transformComponent = entity.GetComponent<TransformComponent>();
        VelocityComponent velocityComponent = entity.GetComponent<VelocityComponent>();
        CharacterBodyComponent characterBodyComponent =
            entity.GetComponent<CharacterBodyComponent>();

        if (characterBodyComponent.characterBody3D.IsOnFloor())
        {
            if (velocityComponent.Velocity.Y < 0)
            {
                velocityComponent.Velocity.Y = 0;
            }
        }

        int clampedVelocityX = Mathf.Clamp(
            Mathf.RoundToInt(velocityComponent.Velocity.X),
            -velocityComponent.maxX,
            velocityComponent.maxX
        );

        int clampedVelocityZ = Mathf.Clamp(
            Mathf.RoundToInt(velocityComponent.Velocity.Z),
            -velocityComponent.maxZ,
            velocityComponent.maxZ
        );

        characterBodyComponent.characterBody3D.Velocity = new Vector3(
            clampedVelocityX,
            velocityComponent.Velocity.Y,
            clampedVelocityZ
        );

        characterBodyComponent.characterBody3D.MoveAndSlide();

        transformComponent.TransformPosition = characterBodyComponent
            .characterBody3D
            .GlobalPosition;
    }

    protected void CheckPlayerGrounded(Entity entity)
    {
        CharacterBodyComponent characterBodyComponent =
            entity.GetComponent<CharacterBodyComponent>();

        if (characterBodyComponent.characterBody3D.IsOnFloor())
        {
            PlayerComponent playerComponent = entity.GetComponent<PlayerComponent>();
            playerComponent.IsJumpAllowed = true;
        }
    }
}
