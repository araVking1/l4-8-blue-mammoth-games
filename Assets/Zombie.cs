using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public Transform target; // The target for the zombie to follow

    public float speed = 2f; // The movement speed of the zombie

    private Animator animator; // Reference to the animator component

    private void Start()
    {
        animator = GetComponent<Animator>(); // Get the Animator component
    }

    private void Update()
    {
        // Check if a target is assigned
        if (target != null)
        {
            // Calculate the direction to the target
            Vector3 direction = target.position - transform.position;
            direction.y = 0f; // Ensure the zombie stays upright

            // Rotate the zombie to face the target
            transform.rotation = Quaternion.LookRotation(direction);

            // Move the zombie towards the target
            transform.position += direction.normalized * speed * Time.deltaTime;

            // Set the "Walk" animation parameter to true
            animator.SetBool("Walk", true);
        }
        else
        {
            // Set the "Walk" animation parameter to false if no target is assigned
            animator.SetBool("Walk", false);
        }
    }
}
