using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IChangeable<T>
{
    public Action<T> ChangeCallback { get; set; }
}
