using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SpawnBladeData : RandomSkillData
{
    public List<ITarget.Type> _targetTypes;
    public float _force;
    public BladeData _data;

    public SpawnBladeData(int maxUpgradePoint, float probability, float force, BladeData data, List<ITarget.Type> targetTypes) : base(maxUpgradePoint, probability)
    {
        _targetTypes = targetTypes;
        _force = force;
        _data = data;
    }
}

public class SpawnBladeCreater : SkillCreater
{
    BaseFactory _weaponFactory;

    public SpawnBladeCreater(BaseSkillData data, BaseFactory _weaponFactory) : base(data)
    {
        this._weaponFactory = _weaponFactory;
    }

    public override BaseSkill Create()
    {
        SpawnBladeData data = _buffData as SpawnBladeData;
        return new SpawnBlade(data, _weaponFactory);
    }
}
