using Leopotam.EcsLite;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
public class BenchmarkLeo : MonoBehaviour
{
    private EcsWorld _world;
    private IEcsSystems _systems;
    
    public void IterationTest(int entitiesCount)
    {
        _world = new EcsWorld ();
        _systems = new EcsSystems (_world);
        _systems
            .Add (new LeoIterationSystem (entitiesCount))
            .Init ();
    }
    
    public void SingleMigrationTest(int entitiesCount)
    {
        _world = new EcsWorld ();
        _systems = new EcsSystems (_world);
        _systems
            .Add (new LeoSingleMigrationSystem (entitiesCount))
            .Init ();
    }
    
    public void TripleMigrationTest(int entitiesCount)
    {
        _world = new EcsWorld ();
        _systems = new EcsSystems (_world);
        _systems
            .Add (new LeoTripleMigrationSystem (entitiesCount))
            .Init ();
    }
    
    private void Update () 
    {
        _systems?.Run ();
    }

    private void OnDestroy () 
    {
        if (_systems != null) 
        {
            _systems.Destroy ();
            _systems = null;
        }
        if (_world != null) 
        {
            _world.Destroy ();
            _world = null;
        }
    }
}

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
public class LeoIterationSystem : IEcsInitSystem, IEcsRunSystem 
{
    private EcsFilter _filter0;
    private EcsFilter _filter1;
    private EcsFilter _filter2;
    private EcsFilter _filter3;
    
    private EcsPool<TestComponent0> _pool0;
    private EcsPool<TestComponent1> _pool1;
    private EcsPool<TestComponent2> _pool2;
    private EcsPool<TestComponent3> _pool3;
    
    private int entitiesCount;

    public LeoIterationSystem(int entitiesCount)
    {
        this.entitiesCount = entitiesCount;
    }
    
    public void Init(IEcsSystems systems) 
    {
        var world = systems.GetWorld();
        
        _filter0 = world.Filter<TestComponent0>().End();
        _filter1 = world.Filter<TestComponent0>().Inc<TestComponent1>().End();
        _filter2 = world.Filter<TestComponent0>().Inc<TestComponent1>().Inc<TestComponent2>().End();
        _filter3 = world.Filter<TestComponent0>().Inc<TestComponent1>().Inc<TestComponent2>().Inc<TestComponent3>().End();
        
        _pool0 = world.GetPool<TestComponent0>();
        _pool1 = world.GetPool<TestComponent1>();
        _pool2 = world.GetPool<TestComponent2>();
        _pool3 = world.GetPool<TestComponent3>();
        
        for (int i = 0; i < entitiesCount; i++)
        {
            var e = world.NewEntity();
            _pool0.Add(e);
            _pool1.Add(e);
            _pool2.Add(e);
            _pool3.Add(e);
        }
    }

    public void Run(IEcsSystems systems)
    {
        foreach (var ent in _filter3)
        {
            _pool0.Get(ent).Test++;
            _pool1.Get(ent).Test++;
            _pool2.Get(ent).Test++;
            _pool3.Get(ent).Test++;
        }
    }
}

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
public class LeoSingleMigrationSystem : IEcsInitSystem, IEcsRunSystem 
{
    private EcsFilter _filter0;
    private EcsFilter _filter1;
    private EcsFilter _filter2;
    private EcsFilter _filter3;
    
    private EcsPool<TestComponent0> _pool0;
    private EcsPool<TestComponent1> _pool1;
    private EcsPool<TestComponent2> _pool2;
    private EcsPool<TestComponent3> _pool3;
    
    private int entitiesCount;

    public LeoSingleMigrationSystem(int entitiesCount)
    {
        this.entitiesCount = entitiesCount;
    }
    
    public void Init(IEcsSystems systems) 
    {
        var world = systems.GetWorld();
        
        _filter0 = world.Filter<TestComponent0>().End();
        _filter1 = world.Filter<TestComponent0>().Inc<TestComponent1>().End();
        _filter2 = world.Filter<TestComponent0>().Inc<TestComponent1>().Inc<TestComponent2>().End();
        _filter3 = world.Filter<TestComponent0>().Inc<TestComponent1>().Inc<TestComponent2>().Inc<TestComponent3>().End();
        
        _pool0 = world.GetPool<TestComponent0>();
        _pool1 = world.GetPool<TestComponent1>();
        _pool2 = world.GetPool<TestComponent2>();
        _pool3 = world.GetPool<TestComponent3>();
        
        for (int i = 0; i < entitiesCount; i++)
        {
            var e = world.NewEntity();
            _pool0.Add(e);
            _pool1.Add(e);
            _pool2.Add(e);
            _pool3.Add(e);
        }
    }

    public void Run(IEcsSystems systems)
    {
        foreach (var ent in _filter3)
        {
            _pool1.Del(ent);
        }
        
        foreach (var ent in _filter0)
        {
            _pool1.Add(ent);
        }
    }
}

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
public class LeoTripleMigrationSystem : IEcsInitSystem, IEcsRunSystem 
{
    private EcsFilter _filter0;
    private EcsFilter _filter1;
    private EcsFilter _filter2;
    private EcsFilter _filter3;
    
    private EcsPool<TestComponent0> _pool0;
    private EcsPool<TestComponent1> _pool1;
    private EcsPool<TestComponent2> _pool2;
    private EcsPool<TestComponent3> _pool3;
    
    private int entitiesCount;

    public LeoTripleMigrationSystem(int entitiesCount)
    {
        this.entitiesCount = entitiesCount;
    }
    
    public void Init(IEcsSystems systems) 
    {
        var world = systems.GetWorld();
        
        _filter0 = world.Filter<TestComponent0>().End();
        _filter1 = world.Filter<TestComponent0>().Inc<TestComponent1>().End();
        _filter2 = world.Filter<TestComponent0>().Inc<TestComponent1>().Inc<TestComponent2>().End();
        _filter3 = world.Filter<TestComponent0>().Inc<TestComponent1>().Inc<TestComponent2>().Inc<TestComponent3>().End();
        
        _pool0 = world.GetPool<TestComponent0>();
        _pool1 = world.GetPool<TestComponent1>();
        _pool2 = world.GetPool<TestComponent2>();
        _pool3 = world.GetPool<TestComponent3>();
        
        for (int i = 0; i < entitiesCount; i++)
        {
            var e = world.NewEntity();
            _pool0.Add(e);
            _pool1.Add(e);
            _pool2.Add(e);
            _pool3.Add(e);
        }
    }

    public void Run(IEcsSystems systems)
    {
        foreach (var ent in _filter3)
        {
            _pool1.Del(ent);
            _pool2.Del(ent);
            _pool3.Del(ent);
        }
        
        foreach (var ent in _filter0)
        {
            _pool1.Add(ent);
            _pool2.Add(ent);
            _pool3.Add(ent);
        }
    }
}

public struct TestComponent0 { public int Test; }
public struct TestComponent1 { public int Test; }
public struct TestComponent2 { public int Test; }
public struct TestComponent3 { public int Test; }

#if ENABLE_IL2CPP
// Unity IL2CPP performance optimization attribute.
namespace Unity.IL2CPP.CompilerServices {
    using System;
    enum Option {
        NullChecks = 1,
        ArrayBoundsChecks = 2,
        DivideByZeroChecks = 3
    }

    [AttributeUsage (AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    class Il2CppSetOptionAttribute : Attribute {
        public Option Option { get; private set; }
        public object Value { get; private set; }

        public Il2CppSetOptionAttribute (Option option, object value) { Option = option; Value = value; }
    }
}
#endif