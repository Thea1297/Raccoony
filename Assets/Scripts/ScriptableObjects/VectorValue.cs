using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class VectorValue : ScriptableObject, ISerializationCallbackReceiver
{
    public Vector2 initialValue; //value running in game
    public Vector2 defaultValue; //where we want vector to be in the scene by default (at start)
    public void OnAfterDeserialize()
    {
        //when we hit play
        initialValue = defaultValue;
    }
    public void OnBeforeSerialize()  
    { 
        
    }
}
