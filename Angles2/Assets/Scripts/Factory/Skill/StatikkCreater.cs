using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Newtonsoft.Json;


// 업그레이드 가능한 스킬 데이터를 따로 Struct로 빼서 관리하자
[Serializable]
public class StatikkData : CooltimeSkillData
{
    public float _damage;
    public float _range;
    public int _maxTargetCount;
    public List<ITarget.Type> _targetTypes;

    // + 연산자 오버로딩
    public static StatikkData operator +(StatikkData a, StatikkUpgrader.UpgradableData b)
    {
        return new StatikkData(
            a._maxUpgradePoint, // 수정될 없음
            a._coolTime,
            a._maxStackCount,
            a._damage + b.Damage,
            a._range + b.Range,
            a._maxTargetCount + b.MaxTargetCount,
            a._targetTypes
        );
    }

    public StatikkData(
        int maxUpgradePoint,
        float coolTime,
        int maxStackCount,
        float damage,
        float range,
        int maxTargetCount,
        List<ITarget.Type> targetTypes) : base(maxUpgradePoint, coolTime, maxStackCount)
    {
        _damage = damage;
        _range = range;
        _maxTargetCount = maxTargetCount;
        _targetTypes = targetTypes;
    }
}

public class StatikkCreater : SkillCreater
{
    BaseFactory _effectFactory;

    public StatikkCreater(SkillData data, StatikkUpgrader upgrader, BaseFactory effectFactory) : base(data) 
    {
        _effectFactory = effectFactory;
    }

    public override BaseSkill Create()
    {
        StatikkData data = _skillData as StatikkData;
        return new Statikk(data, _effectFactory);
    }
}
