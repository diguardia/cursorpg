using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


    public enum AttributeType
    {
        Strength,
        Intelligence,
        Dexterity
    }

public class ButtonAddAttribute : MonoBehaviour
{
    public static Action <AttributeType> AddAttributeEvent;

    [SerializeField]  AttributeType type;

    public void AddAttribute() {
        AddAttributeEvent?.Invoke(type);
    }
    
}
