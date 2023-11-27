using UnityEngine;
using System.Collections.Generic;
using Pathfinding;
using System.Threading;

public class ChasingBuilding : StateClass<VillagerAI>
{
    private int _currentWaypoint = 0;
    private VillagerAI _villager;

    public void Enter(VillagerAI agent)
    {
        _villager = agent;
        StartRandPath(agent);
        agent.Seeker.StartPath(agent.Rb.position, agent.CurrentTarget, EndOfPathReached);
    }

    public void Update(VillagerAI agent, float dt)
    {

    }

    public void FixedUpdate(VillagerAI agent)
    {
        agent.CalculateDirForce(_currentWaypoint);
    }

    public void Exit(VillagerAI agent)
    {

    }

    public void CollisionEnter(VillagerAI agent, Collision2D collision)
    {

    }

    private void StartRandPath(VillagerAI agent)
    {
        if(agent.TargetBuildings.Count <= 0)
        {
            agent.ChangeTarget(Target.None);
        }

        int randNum = Random.Range(0, agent.TargetBuildings.Count);
        var bounds = agent.TargetBuildings[randNum].GetComponent<Collider2D>().bounds;
        agent.CurrentTarget = new Vector2(bounds.center.x, bounds.min.y);
    }

    private void EndOfPathReached(Path path)
    {
        if (!path.error)
        {
            _villager.Path = path;
            _currentWaypoint = 0;
        }
    }
}

public class ChasingPath : StateClass<VillagerAI>
{
    private int _currentWaypoint = 0;
    private VillagerAI _villager;

    public void Enter(VillagerAI agent)
    {
        _villager = agent;
        SetRandomPlace(agent);
        agent.Seeker.StartPath(agent.Rb.position, agent.CurrentTarget, EndOfPathReached);
    }

    public void Update(VillagerAI agent, float dt)
    {
        if (_currentWaypoint >= agent.Path.vectorPath.Count)
        {
            agent.ChangeTarget(Target.None);
        }
    }

    public void FixedUpdate(VillagerAI agent)
    {
        agent.CalculateDirForce(_currentWaypoint);
    }

    public void Exit(VillagerAI agent)
    {

    }

    public void CollisionEnter(VillagerAI agent, Collision2D collision)
    {

    }

    private void SetRandomPlace(VillagerAI agent)
    {
        do
        {
            float randX = Random.Range(agent.WalkingRangeMin, agent.WalkingRangeMax);
            float randY = Random.Range(agent.WalkingRangeMin, agent.WalkingRangeMax);
            agent.CurrentTarget = new Vector2(randX, randY);
        }
        while (IsPointOccupied(agent.CurrentTarget));
    }

    private bool IsPointOccupied(Vector2 point)
    {
        RaycastHit2D hit = Physics2D.Raycast(point, Vector2.zero);

        if (hit.collider == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void EndOfPathReached(Path path)
    {
        if (!path.error)
        {
            _villager.Path = path;
            _currentWaypoint = 0;
        }
    }
}

public class Idle : StateClass<VillagerAI>
{
    private float _timer;
    
    public void Enter(VillagerAI agent)
    {
        _timer = Random.Range(10, 26);
        agent.Rb.velocity = Vector2.zero;
    }

    public void Update(VillagerAI agent, float dt)
    {
        _timer -= dt;

        if( _timer <= 0.0f )
        {
            agent.ChooseTarget();
        }
    }

    public void FixedUpdate(VillagerAI agent)
    {

    }

    public void Exit(VillagerAI agent)
    {
        agent.Collider.enabled = true;
        agent.Sprite.enabled = true;
    }

    public void CollisionEnter(VillagerAI agent, Collision2D collision)
    {

    }
}
