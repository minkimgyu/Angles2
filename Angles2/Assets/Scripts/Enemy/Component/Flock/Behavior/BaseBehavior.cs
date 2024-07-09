using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public struct BehaviorData
{
    public BehaviorData(List<IFlock> nearAgents, List<IObstacle> nearObstacles, Vector3 playerPos)
    {
        _nearAgents = nearAgents;
        _nearObstacles = nearObstacles;
        PlayerPos = playerPos;
    }

    List<IFlock> _nearAgents;
    public List<IFlock> NearAgents { get { return _nearAgents; } }

    List<IObstacle> _nearObstacles;
    public List<IObstacle> NearObstacles { get { return _nearObstacles; } }

    public Vector3 PlayerPos { get; }
}

abstract public class BaseBehavior
{
    protected float _weight = 1;
    protected Transform _myTransform;

    public virtual void Intialize(Transform target, float weight) { _myTransform = target; _weight = weight; }
    public abstract Vector3 ReturnVelocity(BehaviorData behaviorData);
}
