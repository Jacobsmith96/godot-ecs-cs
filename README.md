# godot-ecs-cs 

Simple implementation of ECS in Godot with C#.

## Description

This project serves to provide a basic example of how to implement ECS in Godot with C#. It's intended to be primarily used as a shell for quickstarting Game Dev.

This ECS implementation defines the following generic classes:

- `Entity`
- `Component`
- `Executor` (`System` equivalent)

These classes extend the Godot base classes `Node` and `Node3D`. All Godot base nodes (such as Camera3D and WorldEnvironment) are created programatically as `Entity` types and added to the ECS system and Godot Scene tree at run time.

The `Manager` class handles registration and deletion of `Entity` types and their `Components`.

The `World` class instantiates the `Manager` and `Executors`, as well as `Entities` used in the example scene.

The term `Executor` was chosen in place of `System` due to it's reserved status in C#.

## Getting Started

### Dependencies

- Install Godot with C# support (.Net option) from the [Official Website](https://godotengine.org/download/windows/). This project is built on Godot version 4.2.1.

### Cloning the project

- Run the following command in the location of your choice.

```
git clone https://github.com/Jacobsmith96/godot-ecs-cs.git
```

### Opening in Godot

- Run Godot, click Import and browse to the location of the cloned repo.

### Running the Example

- Run the `main` scene by clicking the play button in the top right of Godot editor window.
- You can test input with the `WASD` keys.

## Help

- Please submit issues or feature requests using the `Issues` tab of the Github Repository.

## Authors

Contributors names and contact info

Jacob Smith

## Version History

- 0.1
  - Initial Release

## License

This project is licensed under the MIT License - see the LICENSE.md file for details.

## Acknowledgments

- [Godot Docs](https://docs.godotengine.org/en/4.2/)
