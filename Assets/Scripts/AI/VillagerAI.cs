using UnityEngine;
using Pathfinding;

public class VillagerAI : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;
    [SerializeField] private float _waypointDistance;

    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Seeker _seeker;
    private Path _path;

    private int _currentWaypoint = 0;
    bool _reachedEndOfPath = false;

    private void Start()
    {
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
            _reachedEndOfPath = true;
            return;
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
            _seeker.StartPath(_rb.position, _target.position, EndOfPathReached);
        }
    }
}
