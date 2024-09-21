using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeShooting : BaseSkill
{
    UpgradeShootingData _data;

    public UpgradeShooting(UpgradeShootingData data) : base(Type.Active, data._maxUpgradePoint)
    {
        _data = data;
    }

    public override void Upgrade()
    {
        base.Upgrade();
        UpgradeStat();
    }

    public override void OnAdd()
    {
        _useConstraint = new NoConstraintComponent();
        UpgradeStat();
    }

    void UpgradeStat()
    {
        GameObject myObject = _castingData.MyObject;
        IStatUpgradable visitor = myObject.GetComponent<IStatUpgradable>();
        if (visitor == null) return;

        visitor.Upgrade(_data._shootingDatas[UpgradePoint]);
    }
}
