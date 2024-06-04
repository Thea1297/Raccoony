using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ScriptableObjects are not attached to anything in the Scene, doesnt have start or update, so its not reseting after leaving the scene

[CreateAssetMenu]
[System.Serializable]
public class FloatValue : ScriptableObject
{
    public float initialValue;
    
    public float RuntimeValue;

}
