using System.Collections.Generic;
using System.Diagnostics;
using Godot;

public partial class Manager : Node
{
    public bool DebugEnabled = false;
    public bool Step = false;

    private Dictionary<int, Entity> Entities;
    private Dictionary<System.Type, Executor> Executors;
    private List<int> EntitiesToDelete;
    private int CurrentID = 0;

    public Manager()
    {
        Name = GetType().ToString();
        Entities = new Dictionary<int, Entity>();
        Executors = new Dictionary<System.Type, Executor>();
        EntitiesToDelete = new List<int>();
    }

    public Entity AddEntity()
    {
        Entity entity = new Entity(CurrentID++);
        Entities[entity.ID] = entity;
        UpdateEntityRegistration(entity);
        AddChild(entity);
        return entity;
    }

    public Entity AddEntity(Entity entity)
    {
        entity.ID = CurrentID++;
        Entities[entity.ID] = entity;
        UpdateEntityRegistration(entity);
        AddChild(entity);
        return entity;
    }

    public void DeleteEntity(int id)
    {
        EntitiesToDelete.Add(id);
    }

    public Entity GetEntityById(int id)
    {
        return Entities[id];
    }

    public void AddExecutor(Executor executor)
    {
        Executors[executor.GetType()] = executor;
        AddChild(executor);
        executor.BindManager(this);
    }

    public T GetExecutor<T>()
        where T : Executor
    {
        return (T)Executors[typeof(T)];
    }

    public void Update(double deltaTime)
    {
        UpdateExecutors(deltaTime);
        Flush();
    }

    private void UpdateExecutors(double deltaTime)
    {
        foreach (Executor executor in Executors.Values)
        {
            executor.UpdateEntities(deltaTime);
        }
    }

    public bool EntityExists(int id)
    {
        return Entities.ContainsKey(id);
    }

    private void Flush()
    {
        foreach (int id in EntitiesToDelete)
        {
            if (!EntityExists(id)) //safeguard against deleting twice
                continue;

            foreach (Executor executor in Executors.Values)
            {
                executor.DeleteEntity(id);
            }
            RemoveChild(Entities[id]);
            Entities.Remove(id);
        }
        EntitiesToDelete.Clear();
    }

    private void UpdateEntityRegistration(Entity entity)
    {
        foreach (Executor executor in Executors.Values)
        {
            executor.UpdateEntityRegistration(entity);
        }
    }

    public void AddComponentToEntity(Entity entity, Component component)
    {
        entity.AddComponent(component);
        component.Name = component.GetType().ToString();
        entity.AddChild(component);
        UpdateEntityRegistration(entity);
    }

    public void RemoveComponentFromEntity(Entity entity, Component component)
    {
        entity.RemoveComponent(component);
        entity.RemoveChild(component);
        UpdateEntityRegistration(entity);
    }
}
