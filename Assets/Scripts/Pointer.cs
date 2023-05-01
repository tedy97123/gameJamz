using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public GameObject delivery;

    public float xOffscreen;
    public float yOffscreen;

    public void setGameObject(GameObject passedDelivery) {
        delivery = passedDelivery;
    }

    private void Update() {

        Vector2 deliveryVector = delivery.transform.position;

        Vector2 fromVector = GameObject.Find("Player").transform.position;

        Vector2 dir = (deliveryVector - fromVector);
        Vector2 dirNormalized = dir.normalized;

        float angle = Mathf.Atan2(dirNormalized.y, dirNormalized.x) * Mathf.Rad2Deg - 90f;

        this.gameObject.GetComponent<RectTransform>().localEulerAngles = new Vector3(0, 0, angle);

        Debug.Log(isOffscreen(dir));

        if (isOffscreen(dir))
        {
            this.gameObject.GetComponent<CanvasGroup>().alpha = 1f;

        }
        else {
            this.gameObject.GetComponent<CanvasGroup>().alpha = 0f;
        }
    }

    private bool isOffscreen(Vector2 dir) {
        return Mathf.Abs(dir.x) >= xOffscreen || Mathf.Abs(dir.y) >= yOffscreen;
    }
}
