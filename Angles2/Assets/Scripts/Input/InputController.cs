using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputController : MonoBehaviour
{
    public enum Side
    {
        Left,
        Right
    }

    public enum Type
    {
        None,
        OnInputStart,
        OnInput,
        OnInputEnd,
        OnDoubleTab
    }

    [SerializeField] HandlerDictionary _handler;

    public void AddEvent(Side side, Type type, Action Event)
    {
        _handler[side].AddEvent(type, Event);
    }

    public void AddEvent(Side side, Type type, Action<Vector2> Event)
    {
        _handler[side].AddEvent(type, Event);
    }

    public void ClearEvent(Side side)
    {
        _handler[side].ClearEvent();
    }

    public void RemoveEvent(Side side, Type type, Action Event)
    {
        _handler[side].RemoveEvent(type, Event);
    }

    public void RemoveEvent(Side side, Type type, Action<Vector2> Event)
    {
        _handler[side].RemoveEvent(type, Event);
    }
}
