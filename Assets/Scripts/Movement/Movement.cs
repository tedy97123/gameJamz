using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // Speed of the player's movement
    public Rigidbody2D rb; // Reference to the Rigidbody2D component attached to the player
    private float mx; // The player's horizontal input
    private float my; // The player's vertical input

    public Animator animator;

    void Update()
    {
        mx = Input.GetAxis("Horizontal"); // Get the horizontal input from the player
        my = Input.GetAxis("Vertical"); // Get the vertical input from the player

        animator.SetFloat("Horizontal", mx);

        // Move the player based on the input from the player and the speed of the player
        rb.velocity = new Vector2(mx, my) * speed;
    }
}
