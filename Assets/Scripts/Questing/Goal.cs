using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Goal
{
    [SerializeField] protected Quest Quest;
    [SerializeField] protected bool _completedStatus = false;

    public virtual void Init()
    {
    }

    public bool IsCompleted()
    {
        return _completedStatus;
    }
}
