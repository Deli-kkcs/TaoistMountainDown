using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ObservableValue<T>
{
    private T value;
    private readonly string valueType;
    /*public */
    delegate void OnValueChangeDelegate(T oldValue, T newValue, string valueType);
    /*public */
    event OnValueChangeDelegate OnValueChangeEvent;
    public ObservableValue(T value, string valueType)
    {
        this.value = value;
        this.valueType = valueType;
        this.OnValueChangeEvent += OnValueChange;

    }
    public T Value
    {
        get => value;
        set
        {
            T oldValue = this.value;
            if (this.value.Equals(value))
                return;
            //if (typeof(T) == typeof(int) && (int.Parse(value.ToString()) < 0))
            //    return;

            //if (valueType == 7 && (int.Parse(value.ToString()) < 0))
            //{
            //    T t = (T)(object)Convert.ToInt32(0);
            //    this.value = t;
            //}

            this.value = value;
            OnValueChangeEvent?.Invoke(oldValue, value, this.valueType);
        }
    }
    public void OnValueChange(T oldValue, T newValue, string valueType)
    {

        //if (valueType == 0 && typeof(T) == typeof(int) && int.Parse(newValue.ToString()) >= 2)
        //{
        //    //Debug.Log("int�ﵽ��ֵ2 ����");
        //}
        //if (valueType == 1 && typeof(T) == typeof(float) && float.Parse(newValue.ToString()) >= 0.2f)
        //{
        //    //Debug.Log("float�ﵽ��ֵ0.2f ����");
        //}

        switch (valueType)
        {
            case ("Room"):
            {
                Debug.Log("RefreshRoom!");
                break;
            }
            default:
                break;
        }
    }
}
