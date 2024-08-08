using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeparationBehavior : BaseBehavior
{
    public override Vector3 ReturnVelocity(BehaviorData behaviorData)
    {
        if (behaviorData.NearAgents.Count == 0) return Vector3.zero;

        Vector3 combinedPos = new Vector3();
        for (int i = behaviorData.NearAgents.Count - 1; i >= 0; i--)
        {
            if ((behaviorData.NearAgents[i] as UnityEngine.Object) == null) continue;
            combinedPos += behaviorData.NearAgents[i].ReturnPosition();
        }

        combinedPos /= behaviorData.NearAgents.Count;
        return (_myTransform.position - combinedPos).normalized * _weight;
    }
}
