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
    public int WalkingRangeMax;
    public int WalkingRangeMin;

    private int _currentWaypoint = 0;
    private StateMachine<VillagerAI> _stateMachine;

    private void Awake()
    {
        _stateMachine = new StateMachine<VillagerAI>(this);
        _stateMachine.AddState<ChasingBuilding>();
        _stateMachine.AddState<ChasingPath>();
        _stateMachine.AddState<Idle>();
    }

    private void Start()
    {
        ChooseTarget();
    }

    private void Update()
    {
        if (_currentWaypoint >= Path.vectorPath.Count)
        {
            EndOfPath();
            _currentWaypoint = 0;
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
        _currentWaypoint = 0;
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

    private void EndOfPath()
    {
        if(_target == Target.Building)
        {
            Collider.enabled = false;
            Sprite.enabled = false;
            ChangeTarget(Target.None);
        }
        else if(_target == Target.Path)
        {
            ChangeTarget(Target.None);
        }
    }

    public void ChangeTarget(Target target)
    {
        _target = target;
        _stateMachine.ChangeState((int)_target);
    }

    public void CalculateDirForce(int waypoint)
    {
        var dir = ((Vector2)Path.vectorPath[_currentWaypoint] - Rb.position).normalized;
        Rb.velocity = dir * _speed;

        float distance = Vector2.Distance(Rb.position, Path.vectorPath[_currentWaypoint]);

        if (distance < _waypointDistance)
        {
            ++_currentWaypoint;
        }
    }
}
