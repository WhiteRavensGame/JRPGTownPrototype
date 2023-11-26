using UnityEngine;
using System.Collections.Generic;
using Pathfinding;

public class VillagerAI : MonoBehaviour
{
    [SerializeField] private List<Transform> _targetBuildings = new();
    [SerializeField] private float _speed;
    [SerializeField] private float _waypointDistance;

    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Seeker _seeker;
    private Path _path;

    [SerializeField, Range(0.0f, 30.0f)] int _WalkingRangeMax;
    [SerializeField, Range(-30.0f, 0.0f)] int _WalkingRangeMin;
    private Vector2 _currentTarget;
    private int _currentWaypoint = 0;

    private void Start()
    {
        ChooseTarget();
        InvokeRepeating("PathUpdate", 0.0f, 0.5f);
    }

    private void EndOfPathReached(Path path)
    {
        if (!path.error)
        {
            _path = path;
            _currentWaypoint = 0;
        }
    }

    private void FixedUpdate()
    {
        if (_path == null)
        {
            return;
        }

        if (_currentWaypoint >= _path.vectorPath.Count)
        {
            ChooseTarget();
        }

        CalculateDirForce();
    }

    private void CalculateDirForce()
    {
        var dir = ((Vector2)_path.vectorPath[_currentWaypoint] - _rb.position).normalized;
        var forceDir = dir * _speed * Time.deltaTime;
        _rb.AddForce(forceDir);

        float distance = Vector2.Distance(_rb.position, _path.vectorPath[_currentWaypoint]);

        if (distance < _waypointDistance)
        {
            ++_currentWaypoint;
        }
    }

    private void PathUpdate()
    {
        if (_seeker.IsDone())
        {
            _seeker.StartPath(_rb.position, _currentTarget, EndOfPathReached);
        }
    }

    private void ChooseTarget()
    {
        _currentWaypoint = 0;
        switch (Random.Range(0, 10) % 2)
        {
            case 0:
                _currentTarget = GetTargetsEntrance(Random.Range(0, _targetBuildings.Count));
                break;
            case 1:
                SetRandomPlace();
                break;
            default: break;
        }
        _seeker.StartPath(_rb.position, _currentTarget, EndOfPathReached);
    }

    private Vector2 GetTargetsEntrance(int randNum)
    {
        var bounds = _targetBuildings[randNum].GetComponent<Collider2D>().bounds;
        return new Vector2(bounds.center.x, bounds.min.y);
    }

    private void SetRandomPlace()
    {
        do
        {
            float randX = Random.Range(_WalkingRangeMin, _WalkingRangeMax);
            float randY = Random.Range(_WalkingRangeMin, _WalkingRangeMax);
            _currentTarget = new Vector2(randX, randY);
        }
        while (IsPointOccupied(_currentTarget));
    }

    private bool IsPointOccupied(Vector2 point)
    {
        RaycastHit2D hit = Physics2D.Raycast(point, Vector2.zero);

        if(hit.collider == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
