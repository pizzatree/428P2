using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAmountVisual : MonoBehaviour
{
    private float maxHeightScale;
    
    private Transform water;
    private Vector3   waterScale;

    private Health health;
    
    // Start is called before the first frame update
    void Start()
    {
        water          = transform.Find("Water");
        waterScale     = water.localScale;
        maxHeightScale = waterScale.z;

        health                 =  GetComponent<Health>();
        health.OnHealthChanged += UpdateVisual;
    }

    private void OnDisable()
    {
        health.OnHealthChanged -= UpdateVisual;
    }

    private void UpdateVisual(float pct)
    {
        if(pct < 0f)
            return;

        waterScale.z     = maxHeightScale * pct;
        water.localScale = waterScale;
    }
}
