using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{

    [SerializeField] Trash[] prefabsTrash;
    [SerializeField] private BoxCollider2D boxCollider2D;

    private float delay;
    [SerializeField] private float maxDelay;
    [SerializeField] private float minDelay;
    
    private float speedFall;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float minSpeed;

    private int counter;
    private bool isStartSpawn;

    public int Counter
    {
        set
        { 
            counter = value;
            delay = Mathf.Lerp(maxDelay, minDelay, Mathf.Min(counter / 100f,1f));
            speedFall = Mathf.Lerp(minSpeed, maxSpeed, Mathf.Min(counter / 100f, 1f));
            
        }
        get
        {
            return counter;
        }
    }

    public void StartSpawn()
    {
        isStartSpawn = true;
        Counter = 0;
        SpawnTrash();
        
    }


    public void StopSpawn()
    {
        isStartSpawn = false;
        CancelInvoke(nameof(SpawnTrash));
        ClearTrash();
        
    }

    public void SpawnTrash()
    {
        Counter++;
        Vector2 spawnPoint = new Vector2(Random.Range(-boxCollider2D.size.x/2, boxCollider2D.size.x/2), transform.position.y);
        int indexTrash = Random.Range(0, prefabsTrash.Length);
        Trash trash = Instantiate(prefabsTrash[indexTrash], spawnPoint, Quaternion.identity,transform);
        trash.SetSpeedFall(speedFall);
       

        if (isStartSpawn)
        {
            Invoke(nameof(SpawnTrash), delay);
        }
    }


   public void ClearTrash()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);   
        }
        
    }

}
