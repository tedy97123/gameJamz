using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // Speed of the player's movement
    public Rigidbody2D rb; // Reference to the Rigidbody2D component attached to the player
    private float mx; // The player's horizontal input
    private float my; // The player's vertical input
    private Vector2 mousePos; // The position of the mouse in the game world

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get a reference to the Rigidbody2D component attached to the player
    }

    void Update()
    {
        mx = Input.GetAxis("Horizontal"); // Get the horizontal input from the player
        my = Input.GetAxis("Vertical"); // Get the vertical input from the player

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Get the position of the mouse in the game world

        // Calculate the angle between the player's position and the mouse position and rotate the player accordingly
        float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void FixedUpdate()
    {
        // Move the player based on the input from the player and the speed of the player
        rb.velocity = new Vector2(mx, my).normalized * speed;
    }
}
