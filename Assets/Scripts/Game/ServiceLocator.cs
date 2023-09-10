using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class ServiceLocator : MonoBehaviour
{
    private readonly Dictionary<Type, object> _serviceBindings = new Dictionary<Type, object>();

    public T Get<T>()
    {
        return (T)Get(typeof(T));
    }

    public object Get(Type type)
    {
        object instance = null;
        _serviceBindings.TryGetValue(type, out instance);

        return instance;
    }

    public void DestroyComponentService(Type t)
    {
        object instance;
        if (t.IsSubclassOf(typeof(Component)) && _serviceBindings.TryGetValue(t, out instance))
        {
            Destroy((Component)instance);
        }
    }

    public T Add<T>()
    {
        return (T)Add(typeof(T), typeof(T));
    }


    public T Add<T, U>() where U : T
    {
        return (T)Add(typeof(T), typeof(U));
    }

    public object Add(Type t, Type u)
    {
        return AddInternal(t, u);
    }

    public void AddExisting<T>(T existing)
    {
        Type bindingType = existing.GetType();
        AddExistingInternal(bindingType, existing);
    }

    public void AddExisting<T, U>(U existing) where U : T
    {
        Type bindingType = typeof(T);
        AddExistingInternal(bindingType, existing);
    }

    public void Remove<T>()
    {
        Remove(typeof(T));
    }

    public void RemoveWithoutDestroying<T>()
    {
        RemoveWithoutDestroying(typeof(T));
    }


    public void Remove(Type bindingType)
    {
        DestroyComponentService(bindingType);

        _serviceBindings.Remove(bindingType);
    }

    public void RemoveWithoutDestroying(Type bindingType)
    {
        _serviceBindings.Remove(bindingType);
    }

    private object AddInternal(Type bindingType, Type concreteType)
    {
        var concreteInstance = concreteType.IsSubclassOf(typeof(Component))
            ? gameObject.AddComponent(concreteType)
            : Activator.CreateInstance(concreteType);

        _serviceBindings[bindingType] = concreteInstance;
        return concreteInstance;
    }

    private void AddExistingInternal<T>(Type bindingType, T existing)
    {
        DestroyComponentService(bindingType);

        _serviceBindings[bindingType] = existing;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine("Service Locator");

        foreach (var binding in _serviceBindings)
        {
            sb.Append("  ").Append(binding.Key).Append(" -> ").AppendLine(binding.Value.ToString());
        }

        return sb.ToString();
    }
}
