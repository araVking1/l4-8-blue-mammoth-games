using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckMonsterHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the bullet hits the zombie
        if (collision.gameObject.tag == "enemy")
        {
            // Call the TakeShot method on the zombie
            collision.gameObject.GetComponent<Zombie>().TakeShot();
            Destroy(this.gameObject);
        }
    }

}
