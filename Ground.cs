using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Trash collisionTrash = collision.gameObject.GetComponent<Trash>();
        if (collisionTrash != null)
        {
            
            GameStats.HEALTH--;
            Destroy(collisionTrash);

            
            

        }
    }
}
