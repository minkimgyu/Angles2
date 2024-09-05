using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Player.FSM
{
    public class ShootState : State<Player.ActionState>
    {
        Action<bool, float> ChangeBodyScale;

        Action<bool> SetInvincible;
        Action<Collision2D> OnReflect;

        float _shootSpeed;
        BuffFloat _shootDuration;

        float _ratio;

        Timer _timer;
        Transform _myTransform;
        MoveComponent _moveComponent;

        public ShootState(
            FSM<Player.ActionState> fsm,
            float shootSpeed,
            BuffFloat shootDuration,

            Transform myTransform,
            MoveComponent moveComponent,

            Action<bool, float> ChangeBodyScale,
            Action<Collision2D> OnReflect,

            Action<bool> SetInvincible) : base(fsm)
        {
            _shootSpeed = shootSpeed;
            _shootDuration = shootDuration;
            _myTransform = myTransform;
            _moveComponent = moveComponent;

            this.ChangeBodyScale = ChangeBodyScale;
            this.OnReflect = OnReflect;

            _timer = new Timer();
            this.SetInvincible = SetInvincible;
        }

        public override void OnCollisionEnter(Collision2D collision)
        {
            OnReflect?.Invoke(collision);
            ServiceLocater.ReturnSoundPlayer().PlaySFX(ISoundPlayable.SoundName.Bounce);

            Vector2 reflectDirection = Vector2.Reflect(_myTransform.right, collision.contacts[0].normal);
            _myTransform.right = reflectDirection;

            Debug.DrawRay(_myTransform.position, reflectDirection, Color.red, 5);

            Shoot(reflectDirection);
        }

        public override void OnStateEnter(Vector2 direction, float ratio, string message)
        {
            ServiceLocater.ReturnSoundPlayer().PlaySFX(ISoundPlayable.SoundName.Shooting);

            _ratio = ratio;

            _timer.Reset();
            _timer.Start(_shootDuration.Value);

            ChangeBodyScale?.Invoke(false, 0);
            Shoot(direction);
        }

        public override void OnStateUpdate()
        {
            if(_timer.CurrentState == Timer.State.Finish)
            {
                GoToReadyState();
                return;
            }
        }

        // move가 검출된다면 바로 Ready로 보냄
        public override void OnMove(Vector2 vec2)
        {
            GoToReadyState();
        }

        void Shoot(Vector2 direction)
        {
            _moveComponent.Stop();
            _moveComponent.AddForce(direction, _shootSpeed * _ratio);
        }

        void GoToReadyState()
        {
            SetInvincible?.Invoke(false);

            ChangeBodyScale?.Invoke(false, 1);
            _baseFSM.SetState(Player.ActionState.Ready);
        }
    }
}