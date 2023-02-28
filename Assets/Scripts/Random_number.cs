using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Random_number : MonoBehaviour
{
   [SerializeField] public TMP_Text screenText;
void getRandom_number()
{
   int a = Random.Range(1,10);
   screenText.text=a.ToString();
}   
        
}