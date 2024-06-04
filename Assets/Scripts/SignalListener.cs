using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class SignalListener : MonoBehaviour
{
    public Signals signal;
    public UnityEvent signalEvent;


    public void OnSignalRaised()
    {
        //when we raise the signal in Signals, do this
        signalEvent.Invoke();
    }

    private void OnEnable()
    {
        signal.RegisterListener(this);
    }

    private void OnDisable()
    {
        signal.DeregisterListener(this);
    }


}
