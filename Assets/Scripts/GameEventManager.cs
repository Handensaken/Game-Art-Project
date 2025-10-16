using UnityEngine;
using System;
using Mono.Cecil.Cil;
public class GameEventManager : MonoBehaviour
{

    public GameEventManager instance { get; private set; }

    public void Awake()
    {
        instance = this;
    }

    public event Action<string> OnSendAnimationParams;
    public void SendAnimationParams(string name)
    {
        if (OnSendAnimationParams != null)
        {
            OnSendAnimationParams(name);
        }
    }
}
