using System;
using UnityEngine;

[Serializable]
public class DynamicVariable<T> : IChangeable<T> {
    public DynamicVariable() {
    }

    public DynamicVariable(T variable) {
        _variable = variable;
    }


    [SerializeField]
    private T _variable = default;

    public Action<T> ChangeCallback { get; set; }

    public T Accessor {
        get => _variable;
        set {
            if (_variable.Equals(value))
                return;

            _variable = value;

            if (ChangeCallback != null)
                ChangeCallback(value);
        }
    }

}
