using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
public class BenchmarkMorpeh : MonoBehaviour
{
    public void IterationTest(int entitiesCount)
    {
        WorldExtensions.InitializationDefaultWorld();
        var sg = World.Default.CreateSystemsGroup();
        sg.AddSystem(new MorpehIterationSystem(entitiesCount));
        World.Default.AddSystemsGroup(0, sg);
    }
    
    public void SingleMigrationTest(int entitiesCount)
    {
        WorldExtensions.InitializationDefaultWorld();
        var sg = World.Default.CreateSystemsGroup();
        sg.AddSystem(new MorpehSingleMigrationSystem(entitiesCount));
        World.Default.AddSystemsGroup(0, sg);
    }
    
    public void TripleMigrationTest(int entitiesCount)
    {
        WorldExtensions.InitializationDefaultWorld();
        var sg = World.Default.CreateSystemsGroup();
        sg.AddSystem(new MorpehTripleMigrationSystem(entitiesCount));
        World.Default.AddSystemsGroup(0, sg);
    }
}

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
public class MorpehIterationSystem : ISystem
{
    public World World { get; set; }

    private Filter _filter0;
    private Filter _filter1;
    private Filter _filter2;
    private Filter _filter3;
    
    private Stash<TestComponent0> _stash0;
    private Stash<TestComponent1> _stash1;
    private Stash<TestComponent2> _stash2;
    private Stash<TestComponent3> _stash3;

    private int entitiesCount;

    public MorpehIterationSystem(int entitiesCount)
    {
        this.entitiesCount = entitiesCount;
    }
    
    public void OnAwake()
    {
        _filter0 = World.Filter.With<TestComponent0>().Build();
        _filter1 = World.Filter.With<TestComponent0>().With<TestComponent1>().Build();
        _filter2 = World.Filter.With<TestComponent0>().With<TestComponent1>().With<TestComponent2>().Build();
        _filter3 = World.Filter.With<TestComponent0>().With<TestComponent1>().With<TestComponent2>().With<TestComponent3>().Build();

        _stash0 = World.GetStash<TestComponent0>();
        _stash1 = World.GetStash<TestComponent1>();
        _stash2 = World.GetStash<TestComponent2>();
        _stash3 = World.GetStash<TestComponent3>();
        
        for (int i = 0; i < entitiesCount; i++)
        {
            var e = World.CreateEntity();
            _stash0.Add(e);
            _stash1.Add(e);
            _stash2.Add(e);
            _stash3.Add(e);
        }
    }

    public void OnUpdate(float deltaTime)
    {
        foreach (var ent in _filter3)
        {
            _stash0.Get(ent).Test++;
            _stash1.Get(ent).Test++;
            _stash2.Get(ent).Test++;
            _stash3.Get(ent).Test++;
        }
    }
    
    public void Dispose()
    {
        
    }
}

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
public class MorpehSingleMigrationSystem : ISystem
{
    public World World { get; set; }

    private Filter _filter0;
    private Filter _filter1;
    private Filter _filter2;
    private Filter _filter3;
    
    private Stash<TestComponent0> _stash0;
    private Stash<TestComponent1> _stash1;
    private Stash<TestComponent2> _stash2;
    private Stash<TestComponent3> _stash3;

    private int entitiesCount;

    public MorpehSingleMigrationSystem(int entitiesCount)
    {
        this.entitiesCount = entitiesCount;
    }
    
    public void OnAwake()
    {
        _filter0 = World.Filter.With<TestComponent0>().Build();
        _filter1 = World.Filter.With<TestComponent0>().With<TestComponent1>().Build();
        _filter2 = World.Filter.With<TestComponent0>().With<TestComponent1>().With<TestComponent2>().Build();
        _filter3 = World.Filter.With<TestComponent0>().With<TestComponent1>().With<TestComponent2>().With<TestComponent3>().Build();

        _stash0 = World.GetStash<TestComponent0>();
        _stash1 = World.GetStash<TestComponent1>();
        _stash2 = World.GetStash<TestComponent2>();
        _stash3 = World.GetStash<TestComponent3>();
        
        for (int i = 0; i < entitiesCount; i++)
        {
            var e = World.CreateEntity();
            _stash0.Add(e);
            _stash1.Add(e);
            _stash2.Add(e);
            _stash3.Add(e);
        }
    }

    public void OnUpdate(float deltaTime)
    {
        foreach (var ent in _filter3)
        {
            _stash1.Remove(ent);
        }
        
        World.Commit();
        
        foreach (var ent in _filter0)
        {
            _stash1.Add(ent);
        }
    }
    
    public void Dispose()
    {
        
    }
}

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
public class MorpehTripleMigrationSystem : ISystem
{
    public World World { get; set; }

    private Filter _filter0;
    private Filter _filter1;
    private Filter _filter2;
    private Filter _filter3;
    
    private Stash<TestComponent0> _stash0;
    private Stash<TestComponent1> _stash1;
    private Stash<TestComponent2> _stash2;
    private Stash<TestComponent3> _stash3;

    private int entitiesCount;

    public MorpehTripleMigrationSystem(int entitiesCount)
    {
        this.entitiesCount = entitiesCount;
    }
    
    public void OnAwake()
    {
        _filter0 = World.Filter.With<TestComponent0>().Build();
        _filter1 = World.Filter.With<TestComponent0>().With<TestComponent1>().Build();
        _filter2 = World.Filter.With<TestComponent0>().With<TestComponent1>().With<TestComponent2>().Build();
        _filter3 = World.Filter.With<TestComponent0>().With<TestComponent1>().With<TestComponent2>().With<TestComponent3>().Build();

        _stash0 = World.GetStash<TestComponent0>();
        _stash1 = World.GetStash<TestComponent1>();
        _stash2 = World.GetStash<TestComponent2>();
        _stash3 = World.GetStash<TestComponent3>();
        
        for (int i = 0; i < entitiesCount; i++)
        {
            var e = World.CreateEntity();
            _stash0.Add(e);
            _stash1.Add(e);
            _stash2.Add(e);
            _stash3.Add(e);
        }
    }

    public void OnUpdate(float deltaTime)
    {
        foreach (var ent in _filter3)
        {
            _stash1.Remove(ent);
            _stash2.Remove(ent);
            _stash3.Remove(ent);
        }
        
        World.Commit();
        
        foreach (var ent in _filter0)
        {
            _stash1.Add(ent);
            _stash2.Add(ent);
            _stash3.Add(ent);
        }
    }
    
    public void Dispose()
    {
        
    }
}

public struct TestComponent0 : IComponent { public int Test; }
public struct TestComponent1 : IComponent { public int Test; }
public struct TestComponent2 : IComponent { public int Test; }
public struct TestComponent3 : IComponent { public int Test; }