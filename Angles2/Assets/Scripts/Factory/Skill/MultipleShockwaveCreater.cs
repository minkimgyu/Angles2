using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MultipleShockwaveData : SkillData
{
    public float _waveSizeMultiply;
    public float _waveDelay;
    public int _maxWaveCount;

    public float _delay;
    public float _damage;
    public float _range;
    public List<ITarget.Type> _targetTypes;

    public MultipleShockwaveData(int maxUpgradePoint, float waveSizeMultiply, float waveDelay, int maxWaveCount, float damage, float range, float delay, List<ITarget.Type> targetTypes) : base(maxUpgradePoint)
    {
        _waveSizeMultiply = waveSizeMultiply;
        _waveDelay = waveDelay;
        _maxWaveCount = maxWaveCount;

        _delay = delay;
        _damage = damage;
        _range = range;
        _targetTypes = targetTypes;
    }

    public override SkillData Copy()
    {
        return new MultipleShockwaveData(
            _maxUpgradePoint, // SkillData에서 상속된 값
            _waveSizeMultiply,
            _waveDelay,
            _maxWaveCount,
            _damage,
            _range,
            _delay,
            new List<ITarget.Type>(_targetTypes) // 리스트 깊은 복사
        );
    }
}


public class MultipleShockwaveCreater : SkillCreater
{
    BaseFactory _effectFactory;

    public MultipleShockwaveCreater(SkillData data, BaseFactory effectFactory) : base(data)
    {
        _effectFactory = effectFactory;
    }

    public override BaseSkill Create()
    {
        MultipleShockwaveData data = _skillData as MultipleShockwaveData;
        return new MultipleShockwave(data, _effectFactory);
    }
}
