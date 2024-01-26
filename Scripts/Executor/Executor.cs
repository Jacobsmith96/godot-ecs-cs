using System.Collections.Generic;
using System.Linq;
using Godot;

public abstract partial class Executor : Node
{
    private HashSet<int> RegisteredEntityIDs;
    public List<Entity> Entities
    {
        get
        {
            var result = from id in RegisteredEntityIDs
                         where Manager.EntityExists(id)
                         select Manager.GetEntityById(id);

            return result.ToList();
        }
    }

    private List<System.Type> RequiredComponents;

    public bool PauseOnDebugEnabled = false;

    protected Manager Manager;

    protected Executor()
    {
        Name = GetType().ToString();
        RegisteredEntityIDs = new HashSet<int>();
        RequiredComponents = new List<System.Type>();
    }

    public void UpdateEntityRegistration(Entity entity)
    {
        if (EntityHasRequiredComponents(entity))
        {
            RegisteredEntityIDs.Add(entity.ID);
        }
        else
        {
            if (RegisteredEntityIDs.Contains(entity.ID))
            {
                RegisteredEntityIDs.Remove(entity.ID);
            }

        }
    }

    private bool EntityHasRequiredComponents(Entity entity)
    {
        foreach (System.Type required in RequiredComponents)
        {
            if (!entity.HasComponent(required))
                return false;
        }
        return true;
    }

    public void AddRequiredComponent<T>() where T : Component
    {
        RequiredComponents.Add(typeof(T));
    }

    public virtual void UpdateEntities(double deltaTime)
    {
        foreach (Entity entity in Entities)
        {
            Update(entity, deltaTime);
        }
    }

    protected abstract void Update(Entity entity, double deltaTime);

    public virtual void DeleteEntity(int id)
    {
        if (RegisteredEntityIDs.Contains(id))
        {
            RegisteredEntityIDs.Remove(id);
        }
    }

    public void BindManager(Manager manager)
    {
        Manager = manager;
    }
}