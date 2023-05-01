using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaShop : MonoBehaviour
{
    public float reloadDistance;

    void Update()
    {
        GameObject player = GameObject.Find("Player");

        if ((player.transform.position - this.transform.position).sqrMagnitude < reloadDistance)
        {
            Manager.pizza = 3;
        }
    }
}
