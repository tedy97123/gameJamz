using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // Speed of the player's movement
    public Rigidbody2D rb; // Reference to the Rigidbody2D component attached to the player
    private float mx; // The player's horizontal input
    private float my; // The player's vertical input
<<<<<<< HEAD
    private Vector2 mousePos; // The position of the mouse in the game world

    public float spinDamping = 0.5f; // The damping of the spin of the player on colission

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get a reference to the Rigidbody2D component attached to the player
    }
=======
>>>>>>> 0469a9bac235372d9caacbef37edf2377d295a54

      private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        
        mx = Input.GetAxis("Horizontal"); // Get the horizontal input from the player
        my = Input.GetAxis("Vertical"); // Get the vertical input from the player

<<<<<<< HEAD
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Get the position of the mouse in the game world

        // if the mouse is on the right side of the screen then flip the player sprite to the right side
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void FixedUpdate()
    {
=======
>>>>>>> 0469a9bac235372d9caacbef37edf2377d295a54
        // Move the player based on the input from the player and the speed of the player
        rb.velocity = new Vector2(mx, my) * speed;
    }
}