using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectable : MonoBehaviour
{
    bool hit = false; // if true, then do something

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player")) // only if Player tag, then
        {
            hit = true;
        }
    }
    void Update()
    {
        if (hit == true)
        {
            Destroy(gameObject);
        }
    }
}
