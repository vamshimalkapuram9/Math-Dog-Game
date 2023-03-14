using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Sparrow : MonoBehaviour
{
    //public Text num1;
    public GameObject Obj;
    //public static int b = Int32.TryParse(num1.text);
    //Debug.Log("num1"+num1.text);
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(num1);
        //int b = Convert.ToInt32(num1);
        multiplySparrow(3);
    }
   public void multiplySparrow(int a)
    {
        for (int i = 0; i < a; i++)
        {
            GameObject sparrow1 = Instantiate(Obj, new Vector3(i, Obj.transform.position.y, i), Obj.transform.rotation);
        }
    }
}