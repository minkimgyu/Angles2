using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coin : MonoBehaviour, IInteractable
{
    int _upCount;
    float _moveSpeed;

    Command<int> AddCoin;
    TrackComponent _trackComponent;

    public void OnInteractEnter(IInteracter interacter)
    {
        _trackComponent.FreezePosition(false);

        IFollowable followable = interacter.ReturnFollower();
        _trackComponent.ResetFollower(followable);
    }

    public void OnInteract(IInteracter interacter) 
    {
        AddCoin.Execute(_upCount);
        Destroy(gameObject);
    }

    public void OnInteractExit(IInteracter interacter) { }

    public void ResetPosition(Vector3 pos)
    {
        transform.position = pos;
    }

    public void Initialize(CoinData data) 
    {
        _upCount = data._upCount;
        _moveSpeed = data._moveSpeed;

        _trackComponent = GetComponent<TrackComponent>();
        _trackComponent.Initialize(_moveSpeed);
        _trackComponent.FreezePosition(true);
    }

    GameObject IInteractable.ReturnGameObject() { return gameObject; }

    public void AddCommand(Command<int> AddCoin) 
    { 
        this.AddCoin = AddCoin; 
    }
}
