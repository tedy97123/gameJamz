using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    
    public Transform target;
    public float speed = 3f;
    public float rotateSpeed = 0.025f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Get the target
    private void getPlayer() {
        if( GameObject.Find("Player")){
            target = GameObject.Find("Player").transform;

        }
        
    }

    private void onCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            Destroy(other.gameObject);
            target = null;
        }
    }


    // Update is called once per frame
    private void Update() {
        //Rotate towards the target (Player)
        //Get the target.
        if (!target) {
             getPlayer();
        } else {
            RotateTowardsTarget();
        }
    }

    
    // Move towards the target
    private void FixedUpdate() {
        // Move Forawrds                      
        rb.velocity = transform.up * speed;
    }


    // Rotate towards the target
private void RotateTowardsTarget() {
    //Get the direction of player in relation to the enemy
    Vector2 targetDirection = target.position - transform.position;

    //Get the angle; Mathf.Atan2 returns the angle in radians and we convert to degrees with Mathf.Rad2Deg and subtract 90 degrees to make the enemy face the player
    float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;

    //Get the Quaternion rotation (postion of player in the scene) from the angle we calculated previously and assign it to the enemy's rotation
    Quaternion q = Quaternion.Euler(new Vector3(1, 0, angle));

    //Rotate only around the z-axis to keep the enemy upright
    Vector3 eulerAngles = q.eulerAngles;
    eulerAngles.x = 0;
    eulerAngles.y = 0;
    transform.rotation = Quaternion.Euler(eulerAngles);
}
 
}