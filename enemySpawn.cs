using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class enemySpawn : MonoBehaviour
{
    public int numEnemies = 10; 
    public GameObject prefab; // choose prefab in Unity
    int originalChildren; // amount of original children
    Transform enemies; // parent object

    Random rand = new Random(); // randomise enemy location 

    void Start()
    {
        enemies = GameObject.Find("Enemies").transform; // find parent object

        for (int i = 0; i < numEnemies; i++)
        {
            makeAChild(); // run makeAChild until theres numEnemies amount of enemies
        }

        originalChildren = transform.childCount; // count amount of children
    }

    void Update()
    {
        int currentChildren = transform.childCount; // count enemies

        if (currentChildren < originalChildren) 
        {
            makeAChild();
        }
    }

    void makeAChild()
    {
        float childX = rand.Next(50); // spawn range of 50
        float childZ = rand.Next(50);

        GameObject newChild = Instantiate(prefab, new Vector3(childX, 5f, childZ), // cloning prefab of enemy
        Quaternion.identity) as GameObject;

        newChild.transform.parent = enemies; 
    }
}
