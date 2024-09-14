using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BaseViewer : MonoBehaviour
{
    public enum Name
    {
        CardViewer,
        CostCardViewer,

        HpViewer,
        SkillViewer,
        DashViewer,
        DirectionViewer,

        BossHPViewer,
    }

    public virtual void Initialize() { }
    public virtual void Initialize(Action OnReturnToMenuRequested) { }
    public virtual void Initialize(Sprite skillIcon) { }
    public virtual void Initialize(SKillCardData cardData, Action OnClick) { }

    public virtual void SetFollower(IFollowable followTarget) { }

    public virtual void UpdateViewer(float skillCoolTimeRatio, int stackCount, bool showStackCount) { }
    public virtual void UpdateViewer(Vector3 pos, Vector2 direction) { }
    public virtual void UpdateViewer(float ratio) { }
    public virtual void UpdateViewer(int count) { }
    public virtual void UpdateViewer(float current, float total) { }
    public virtual void UpdateViewer(string info) { }
    public virtual void UpdateViewer(GameState model) { }

    public virtual void TurnOnViewer(bool show) { }
    public virtual void TurnOnViewer(bool show, float backgroundFadeRatio, float backgroundFadeDuration, string endInfo, Color labelColor, Color labelTxtColor) { }
}
