﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using System;

public class MaterialTweenerController : MonoBehaviour
{
    public List<MaterialTweener> m_MaterialTweeners = new List<MaterialTweener>();

    public List<TweenProperties> m_PropertyList;

    public bool m_OverrideTweenSettings = false;

    [ShowIf("m_OverrideTweenSettings")] public string m_MaterialProperty = "_OffsetY";
    [ShowIf("m_OverrideTweenSettings")] public int m_OffsetDirection = 1;
    [ShowIf("m_OverrideTweenSettings")] public float m_TweenLength = 30f;
    [ShowIf("m_OverrideTweenSettings")] public int m_LoopAmount = 1;

    // Start is called before the first frame update
    void Start()
    {
        FindTweenersOnObject();
    }

    void FindTweenersOnObject()
    {
        if(gameObject.GetComponent<MaterialTweener>() != null)
        {
            m_MaterialTweeners.Add(gameObject.GetComponent<MaterialTweener>());
        }
        MaterialTweener[] childTweeners = GetComponentsInChildren<MaterialTweener>();
        m_MaterialTweeners.AddRange(childTweeners);
    }
    
    [Button]
    public void TweenStart()
    {
        //if (m_OverrideTweenSettings)
        //{
        //    foreach (MaterialTweener tweener in m_MaterialTweeners)
        //    {
        //        tweener.m_MaterialProperty = m_MaterialProperty;
        //        tweener.m_OffsetDirection = m_OffsetDirection;
        //        tweener.m_TweenLength = m_TweenLength;
        //        tweener.m_LoopAmount = m_LoopAmount;
        //    }
        //}

        foreach (MaterialTweener tweener in m_MaterialTweeners)
        {
            tweener.Setup(m_PropertyList);
        }


        foreach (MaterialTweener tweener in m_MaterialTweeners)
        {
            tweener.StartTween();
        }
    }

    [Button]
    public void TweenStop()
    {
        foreach (MaterialTweener tweener in m_MaterialTweeners)
        {
            tweener.StopTween();
        }
    }
}

[Serializable]
public class TweenProperties{
    public string m_MaterialProperty = "_OffsetY";
    public int m_OffsetDirection = 1;
    public float m_TweenLength = 30f;
    public int m_LoopAmount = 1;
}
