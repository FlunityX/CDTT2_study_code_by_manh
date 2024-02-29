using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IHasHpBar
{
    public event EventHandler<OnHpChangeEventArgs> OnHpChange;
    public class OnHpChangeEventArgs
    {
        public float HpNormalized;
    }
}
