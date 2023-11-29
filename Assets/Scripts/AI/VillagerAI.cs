using UnityEngine;
using System.Collections.Generic;
using Pathfinding;

public enum Target
{
    Building,
    Path,
    None
}

public class VillagerAI : MonoBehaviour
{
    [Header("Attachable")]
    public List<Transform> TargetBuildings = new();
    public Rigidbody2D Rb;
    public Seeker Seeker;

    [HideInInspector] public Path Path;
    [HideInInspector] public Vector2 CurrentTarget;

    [Space, Header("Info")]
    [SerializeField] private float _speed;
    [SerializeField] private float _waypointDistance;
    [SerializeField] private Target _target = Target.None;
    public Collider2D Collider;
    public SpriteRenderer Sprite;

    [Space, Header("Walking Range")]
    public Vector2 WalkingRangeMax;
    public Vector2 WalkingRangeMin;

    private StateMachine<VillagerAI> _stateMachine;

    private void Awake()
    {
        _stateMachine = new StateMachine<VillagerAI>(this);
        _stateMachine.AddState<ChasingBuilding>();
        _stateMachine.AddState<ChasingPath>();
        _stateMachine.AddState<Idle>();
    }

    public void Initialize(List<Building> buildings)
    {
        foreach (Building building in buildings)
        {
            TargetBuildings.Add(building.transform);
        }
    }

    private void Start()
    {
        ChooseTarget();
    }

    private void Update()
    {
        if(Path == null)
        {
            return;
        }

        _stateMachine.Update(Time.deltaTime);
    }

    private void FixedUpdate()
    {
        if (Path == null)
        {
            return;
        }

        _stateMachine.FixedUpdate();
    }

    public void ChooseTarget()
    {
        switch (Random.Range(0, 10) % 2)
        {
            case 0:
                {
                    ChangeTarget(Target.Building);
                }
                break;
            case 1:
                {
                    ChangeTarget(Target.Path);
                }
                break;
            default: break;
        }
    }

    public void ChangeTarget(Target target)
    {
        _target = target;
        _stateMachine.ChangeState((int)_target);
    }

    public void CalculateDirForce(ref int waypoint)
    {
        var d = (Vector2)Path.vectorPath[waypoint];
        var f = Rb.position;
        d -= f;
        d = d.normalized;
        var dir = ((Vector2)Path.vectorPath[waypoint] - Rb.position).normalized;
        Rb.velocity = dir * _speed;

        float distance = Vector2.Distance(Rb.position, Path.vectorPath[waypoint]);

        if (distance < _waypointDistance)
        {
            ++waypoint;
        }
    }
}
