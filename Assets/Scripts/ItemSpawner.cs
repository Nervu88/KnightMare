using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{


   private void OnDrawGizmos2D()
   {
       if  (collectableSpawnPoints.Length == 0)
           return;
 
       foreach (Transform Loc in collectableSpawnPoints)
       {
           if (Loc != null)
           {
               Gizmos.color = Color.red;
               Gizmos.DrawSphere(Loc.position, 1f);
           }
       }
   }

    public static GameObject[] gameItems;
    public int numToSpawn;
    public static int numSpawned = 0;
    public Transform[] collectableSpawnPoints = new Transform[5];
    private int index;

    void Start()
    {
        gameItems = Resources.LoadAll<GameObject>("SpawnItems");
    }

    void SpawnRandomObject()
    {

        // Get SpawnPoint
        Transform spawnPoint = GetCollectableSpawnPoint();
        int whichItem = Random.Range(0, numToSpawn);

        GameObject sItem = Instantiate(gameItems[whichItem]) as GameObject;

        numSpawned++;

        sItem.transform.position = spawnPoint.position;
        Destroy(spawnPoint.gameObject);
        index++;
        
    }

    void Update()
    {
        if (numToSpawn > numSpawned)
        {
            
            //where your instantiated object spawns from
            SpawnRandomObject();
        }
    }

    public Transform GetCollectableSpawnPoint()
    {
        //randomly selects a point out of the array

        //returns the selected point
        return collectableSpawnPoints[index];
    }
}
