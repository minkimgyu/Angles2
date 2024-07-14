using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : BaseWeapon, IProjectile
{
    protected float _force;
    protected float _lifeTime;
    protected MoveComponent _moveComponent;

    public Vector2 ReturnDirectionVector()
    {
        return transform.right;
    }

    protected bool IsTarget(ITarget target)
    {
        return target.IsTarget(_targetTypes);
    }

    protected void ApplyDamage(IDamageable damageable)
    {
        DamageData damageData = new DamageData(_damage, _targetTypes);
        damageable.GetDamage(damageData);
    }

    public void Shoot(Vector3 direction, float force)
    {
        transform.right = direction;
        _force = force;

        _moveComponent.Stop();
        _moveComponent.AddForce(direction, _force);
    }
}
