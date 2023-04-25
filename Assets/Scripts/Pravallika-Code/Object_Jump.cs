using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Object_Jump : MonoBehaviour
{
    public float amp;

    public GameObject Object_;

    public float x; 

    public float y;

    // Start is called before the first frame update
    //void Start()
    //{
    //    Object_ = Ans1.transform.position;
    //}

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(x, (Mathf.Sin(Time.time) * amp) + y, 0);
        
    }
}
