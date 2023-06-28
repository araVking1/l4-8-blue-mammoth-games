using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Zombie : MonoBehaviour
{
    public Transform target; // The target for the zombie to follow

    private NavMeshAgent agent; // Reference to the NavMeshAgent component
    private Animator animator; // Reference to the animator component
    private Vector3 initialPosition; // Initial position of the zombie
    private int shotsTaken; // Number of shots taken by the zombie

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // Get the NavMeshAgent component
        animator = GetComponent<Animator>(); // Get the Animator component
        initialPosition = transform.position; // Store the initial position of the zombie
    }

    private void Update()
    {
        // Check if a target is assigned
        if (target != null)
        {
            // Set the destination for the NavMeshAgent
            agent.SetDestination(target.position);

        }
        else
        {
            // Set the "Walk" animation parameter to false if no target is assigned
            animator.SetBool("Walk", false);
        }
        if ((target.position - this.transform.position).magnitude <= 1.2)
        {
            target.position = new Vector3(14.097f, target.position.y, 10.275f);
            SceneManager.LoadScene("level");
        }
    }

    public void TakeShot()
    {
        shotsTaken++;

        // Check if the zombie has been shot five times
        if (shotsTaken >= 5)
        {
            StartCoroutine(RespawnZombie());
        }
    }

    private IEnumerator RespawnZombie()
    {
        // Disable the zombie temporarily
        agent.enabled = false;
        animator.enabled = false;

        // Wait for some time before respawning the zombie
        yield return new WaitForSeconds(5f);

        // Respawn the zombie at the initial position
        transform.position = initialPosition;

        // Reset the shots taken count
        shotsTaken = 0;

        // Enable the zombie back
        agent.enabled = true;
        animator.enabled = true;
    }
}
