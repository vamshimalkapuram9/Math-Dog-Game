using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;


public class RandomObjects : MonoBehaviour
{
    public Text num1;
    public Text num2;
    //public Button answer1Button;
    //public Button answer2Button;
    //public Button answer3Button;
    //public Button nextButton; // button to go to next problem

    public Sprite ObjectSprite1;
    public Sprite ObjectSprite2;
    public Sprite ObjectSprite3;
    public Sprite ObjectSprite4;
    public Sprite ObjectSprite5;
    public Sprite ObjectSprite6;
    public GameObject Object1;
    public GameObject Object2;
    public GameObject Object3;
    public GameObject Object4;
    public GameObject Object5;
    public GameObject Object6;
    public GameObject Object7;
    public GameObject Object8;
    public GameObject Object9;
    public GameObject Object10;
    //public GameObject RandomAddGameObjects; // parent of all the game objects for this game


    public void Start()
    {
        updateObjectSprites();
    }

    public void updateObjectSprites()
    {
        int a = Convert.ToInt32(num1.text);
        int b = Convert.ToInt32(num2.text);
        int objNum = UnityEngine.Random.Range(1, 7); // randomly select sprite 
        Sprite newSprite = ObjectSprite1;
        if (objNum == 1)
        {
            newSprite = ObjectSprite1;
        }
        else if (objNum == 2)
        {
            newSprite = ObjectSprite2;
        }
        else if (objNum == 3)
        {
            newSprite = ObjectSprite3;
        }
        else if (objNum == 4)
        {
            newSprite = ObjectSprite4;
        }
        else if (objNum == 5)
        {
            newSprite = ObjectSprite5;
        }
        else if (objNum == 6)
        {
            newSprite = ObjectSprite6;
        }
        // panel objects
        if (a == 1)
        {
            GameObject obj = Object1.transform.GetChild(0).gameObject;
            obj.GetComponentInChildren<Image>().sprite = newSprite;
            Object1.SetActive(true);
        }
        else if (a == 2)
        {
            GameObject obj1 = Object2.transform.GetChild(0).gameObject;
            GameObject obj2 = Object2.transform.GetChild(1).gameObject;
            obj1.GetComponentInChildren<Image>().sprite = newSprite;
            obj2.GetComponentInChildren<Image>().sprite = newSprite;
            Object2.SetActive(true);
        }
        else if (a == 3)
        {
            GameObject obj1 = Object3.transform.GetChild(0).gameObject;
            GameObject obj2 = Object3.transform.GetChild(1).gameObject;
            GameObject obj3 = Object3.transform.GetChild(2).gameObject;
            obj1.GetComponentInChildren<Image>().sprite = newSprite;
            obj2.GetComponentInChildren<Image>().sprite = newSprite;
            obj3.GetComponentInChildren<Image>().sprite = newSprite;
            Object3.SetActive(true);
        }
        else if (a == 4)
        {
            GameObject obj1 = Object4.transform.GetChild(0).gameObject;
            GameObject obj2 = Object4.transform.GetChild(1).gameObject;
            GameObject obj3 = Object4.transform.GetChild(2).gameObject;
            GameObject obj4 = Object4.transform.GetChild(3).gameObject;
            obj1.GetComponentInChildren<Image>().sprite = newSprite;
            obj2.GetComponentInChildren<Image>().sprite = newSprite;
            obj3.GetComponentInChildren<Image>().sprite = newSprite;
            obj4.GetComponentInChildren<Image>().sprite = newSprite;
            Object4.SetActive(true);
        }
        else if (a == 5)
        {
            GameObject obj = Object5.transform.GetChild(0).gameObject;
            GameObject obj1 = Object5.transform.GetChild(1).gameObject;
            GameObject obj2 = Object5.transform.GetChild(2).gameObject;
            GameObject obj3 = Object5.transform.GetChild(3).gameObject;
            GameObject obj4 = Object5.transform.GetChild(4).gameObject;
            obj.GetComponentInChildren<Image>().sprite = newSprite;
            obj1.GetComponentInChildren<Image>().sprite = newSprite;
            obj2.GetComponentInChildren<Image>().sprite = newSprite;
            obj3.GetComponentInChildren<Image>().sprite = newSprite;
            obj4.GetComponentInChildren<Image>().sprite = newSprite;
            Object5.SetActive(true);
        }
        else if (a == 6)
        {
            GameObject obj1 = Object6.transform.GetChild(0).gameObject;
            GameObject obj2 = Object6.transform.GetChild(1).gameObject;
            GameObject obj3 = Object6.transform.GetChild(3).gameObject;
            GameObject obj4 = Object6.transform.GetChild(4).gameObject;
            GameObject obj5 = Object6.transform.GetChild(5).gameObject;
            GameObject obj6 = Object6.transform.GetChild(6).gameObject;
            obj1.GetComponentInChildren<Image>().sprite = newSprite;
            obj2.GetComponentInChildren<Image>().sprite = newSprite;
            obj3.GetComponentInChildren<Image>().sprite = newSprite;
            obj4.GetComponentInChildren<Image>().sprite = newSprite;
            obj5.GetComponentInChildren<Image>().sprite = newSprite;
            obj6.GetComponentInChildren<Image>().sprite = newSprite;
            Object6.SetActive(true);
        }
        else if (a == 7)
        {
            GameObject obj1 = Object7.transform.GetChild(0).gameObject;
            GameObject obj2 = Object7.transform.GetChild(1).gameObject;
            GameObject obj3 = Object7.transform.GetChild(2).gameObject;
            GameObject obj4 = Object7.transform.GetChild(3).gameObject;
            GameObject obj5 = Object7.transform.GetChild(4).gameObject;
            GameObject obj6 = Object7.transform.GetChild(5).gameObject;
            GameObject obj7 = Object7.transform.GetChild(6).gameObject;
            obj1.GetComponentInChildren<Image>().sprite = newSprite;
            obj2.GetComponentInChildren<Image>().sprite = newSprite;
            obj3.GetComponentInChildren<Image>().sprite = newSprite;
            obj4.GetComponentInChildren<Image>().sprite = newSprite;
            obj5.GetComponentInChildren<Image>().sprite = newSprite;
            obj6.GetComponentInChildren<Image>().sprite = newSprite;
            obj7.GetComponentInChildren<Image>().sprite = newSprite;
            Object7.SetActive(true);
        }
        else if (a == 8)
        {
            GameObject obj1 = Object8.transform.GetChild(0).gameObject;
            GameObject obj2 = Object8.transform.GetChild(1).gameObject;
            GameObject obj3 = Object8.transform.GetChild(2).gameObject;
            GameObject obj4 = Object8.transform.GetChild(3).gameObject;
            GameObject obj5 = Object8.transform.GetChild(4).gameObject;
            GameObject obj6 = Object8.transform.GetChild(5).gameObject;
            GameObject obj7 = Object8.transform.GetChild(6).gameObject;
            GameObject obj8 = Object8.transform.GetChild(7).gameObject;
            obj1.GetComponentInChildren<Image>().sprite = newSprite;
            obj2.GetComponentInChildren<Image>().sprite = newSprite;
            obj3.GetComponentInChildren<Image>().sprite = newSprite;
            obj4.GetComponentInChildren<Image>().sprite = newSprite;
            obj5.GetComponentInChildren<Image>().sprite = newSprite;
            obj6.GetComponentInChildren<Image>().sprite = newSprite;
            obj7.GetComponentInChildren<Image>().sprite = newSprite;
            obj8.GetComponentInChildren<Image>().sprite = newSprite;
            Object8.SetActive(true);
        }
        else if (a == 9)
        {
            GameObject obj1 = Object9.transform.GetChild(0).gameObject;
            GameObject obj2 = Object9.transform.GetChild(1).gameObject;
            GameObject obj3 = Object9.transform.GetChild(2).gameObject;
            GameObject obj4 = Object9.transform.GetChild(3).gameObject;
            GameObject obj5 = Object9.transform.GetChild(4).gameObject;
            GameObject obj6 = Object9.transform.GetChild(5).gameObject;
            GameObject obj7 = Object9.transform.GetChild(6).gameObject;
            GameObject obj8 = Object9.transform.GetChild(7).gameObject;
            GameObject obj9 = Object9.transform.GetChild(8).gameObject;
            obj1.GetComponentInChildren<Image>().sprite = newSprite;
            obj2.GetComponentInChildren<Image>().sprite = newSprite;
            obj3.GetComponentInChildren<Image>().sprite = newSprite;
            obj4.GetComponentInChildren<Image>().sprite = newSprite;
            obj5.GetComponentInChildren<Image>().sprite = newSprite;
            obj6.GetComponentInChildren<Image>().sprite = newSprite;
            obj7.GetComponentInChildren<Image>().sprite = newSprite;
            obj8.GetComponentInChildren<Image>().sprite = newSprite;
            obj9.GetComponentInChildren<Image>().sprite = newSprite;
            Object9.SetActive(true);
        }
        else if (a == 10)
        {
            GameObject obj1 = Object10.transform.GetChild(0).gameObject;
            GameObject obj2 = Object10.transform.GetChild(1).gameObject;
            GameObject obj3 = Object10.transform.GetChild(2).gameObject;
            GameObject obj4 = Object10.transform.GetChild(3).gameObject;
            GameObject obj5 = Object10.transform.GetChild(4).gameObject;
            GameObject obj6 = Object10.transform.GetChild(5).gameObject;
            GameObject obj7 = Object10.transform.GetChild(6).gameObject;
            GameObject obj8 = Object10.transform.GetChild(7).gameObject;
            GameObject obj9 = Object10.transform.GetChild(8).gameObject;
            GameObject obj10 = Object10.transform.GetChild(9).gameObject;
            obj1.GetComponentInChildren<Image>().sprite = newSprite;
            obj2.GetComponentInChildren<Image>().sprite = newSprite;
            obj3.GetComponentInChildren<Image>().sprite = newSprite;
            obj4.GetComponentInChildren<Image>().sprite = newSprite;
            obj5.GetComponentInChildren<Image>().sprite = newSprite;
            obj6.GetComponentInChildren<Image>().sprite = newSprite;
            obj7.GetComponentInChildren<Image>().sprite = newSprite;
            obj8.GetComponentInChildren<Image>().sprite = newSprite;
            obj9.GetComponentInChildren<Image>().sprite = newSprite;
            obj10.GetComponentInChildren<Image>().sprite = newSprite;
            Object10.SetActive(true);
        }
    }
}