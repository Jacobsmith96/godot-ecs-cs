using System.Collections.Generic;
using Godot;

public partial class Entity : Node3D
{
    public int ID { get; set; }
    protected Dictionary<System.Type, Component> Components;

    public Entity(int id)
    {
        Name = GetType().ToString();
        ID = id;
        Components = new Dictionary<System.Type, Component>();
    }

    public Entity()
    {
        Name = GetType().ToString();
        Components = new Dictionary<System.Type, Component>();
    }

    public void AddComponent(Component component)
    {
        Components[component.GetType()] = component;
        component.Name = component.GetType().ToString();
        AddChild(component);
    }

    public void RemoveComponent(Component component)
    {
        Components.Remove(component.GetType());
    }

    public T GetComponent<T>()
        where T : Component
    {
        return (T)Components[typeof(T)];
    }

    public bool HasComponent(System.Type componentType)
    {
        return Components.ContainsKey(componentType);
    }

    public bool HasComponent<T>()
        where T : Component
    {
        return Components.ContainsKey(typeof(T));
    }
}
