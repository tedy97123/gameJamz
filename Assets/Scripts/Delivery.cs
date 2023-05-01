using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{

    public float deliverDistance;

    public GameObject pointerPrefab;

    void Start() {
        GameObject canvas = GameObject.Find("Canvas");
        GameObject pointer = Instantiate(pointerPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity, canvas.transform);
        pointer.GetComponent<Pointer>().setGameObject(this.gameObject);
        pointer.GetComponent<RectTransform>().anchoredPosition = new Vector3(0f, 0f, 0f);
    }

    void Update()
    {
        GameObject player = GameObject.Find("Player");

        if ((player.transform.position - this.transform.position).sqrMagnitude < deliverDistance && Manager.pizza > 0)
        {
            GameObject.Find("Manager").GetComponent<Manager>().SpawnDelivery(this.gameObject);
            Manager.score += 1;
            Manager.pizza -= 1; 
        }
    }
}
