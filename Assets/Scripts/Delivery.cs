using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{

    public float deliverDistance;

    void Update()
    {
        GameObject player = GameObject.Find("Player");

        if ((player.transform.position - this.transform.position).sqrMagnitude < deliverDistance && Manager.pizza > 1)
        {
            GameObject.Find("Manager").GetComponent<Manager>().SpawnDelivery(this.gameObject);
            Manager.score += 1;
            Manager.pizza -= 1; 
        }
    }
}
