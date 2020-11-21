﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystemManager : MonoBehaviour
{
    public static EventSystemManager EventSystemManagerSingleton;

    private void Awake()
    {

        if (EventSystemManagerSingleton == null)
        {
            EventSystemManagerSingleton = this;

        }
        else
        {
            Destroy(gameObject);
        }
    }


    public event Action<int> onInteractProp;
    public void InteractProp(int id)
    {
        if(onInteractProp != null)
        {
            onInteractProp(id);
        }

    }

    public event Action<int,bool,int,bool,GameObject> onLeverSwitch;
    public void LeverSwitch(int id,bool state,int targetId,bool inverseLink, GameObject go)
    {
        if (onLeverSwitch != null)
        {
            onLeverSwitch(id,state,targetId,inverseLink,go);
        }

    }



}