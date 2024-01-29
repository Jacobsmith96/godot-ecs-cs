using System.Diagnostics;
using System.Reflection.Metadata;
using Godot;

public partial class InputExecutor : Executor
{
    World world;

    public InputExecutor()
    {
        AddRequiredComponent<PlayerComponent>();
        AddRequiredComponent<InputComponent>();
        AddRequiredComponent<VelocityComponent>();
    }

    public override void _EnterTree()
    {
        world = GetNode<World>("/root/Main/World");
    }

    protected override void Update(Entity entity, double deltaTime)
    {
        InputComponent InputComponent = entity.GetComponent<InputComponent>();
        VelocityComponent velocityComponent = entity.GetComponent<VelocityComponent>();
        PlayerComponent playerComponent = entity.GetComponent<PlayerComponent>();

        InputComponent.IsLeftPressed = Input.IsActionPressed("left");
        InputComponent.IsRightPressed = Input.IsActionPressed("right");
        InputComponent.IsUpPressed = Input.IsActionPressed("up");
        InputComponent.IsDownPressed = Input.IsActionPressed("down");
        InputComponent.IsJumpPressed = Input.IsActionPressed("jump");

        Vector3 inputVector = new Vector3();

        if (InputComponent.IsLeftPressed)
        {
            inputVector.X -= 1;
        }
        if (InputComponent.IsRightPressed)
        {
            inputVector.X += 1;
        }
        if (InputComponent.IsUpPressed)
        {
            inputVector.Z -= 1;
        }
        if (InputComponent.IsDownPressed)
        {
            inputVector.Z += 1;
        }
        if (InputComponent.IsJumpPressed && playerComponent.IsJumpAllowed)
        {
            velocityComponent.Velocity = new Vector3(
                velocityComponent.Velocity.X,
                velocityComponent.jumpSpeed,
                velocityComponent.Velocity.Z
            );
            playerComponent.IsJumpAllowed = false;
        }

        velocityComponent.Velocity = new Vector3(
            inputVector.X,
            velocityComponent.Velocity.Y,
            inputVector.Z
        );
    }
}
