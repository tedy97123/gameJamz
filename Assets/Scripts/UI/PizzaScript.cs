using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PizzaScript : MonoBehaviour
{
    public Text PizzaText;

    // Update is called once per frame
    void Update()
    {
        PizzaText.text = string.Format("X{0}", Manager.pizza);
    }
}
