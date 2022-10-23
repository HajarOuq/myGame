using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformup : MonoBehaviour
{
    public float minX;
    public float maxX;
    public float distance;
    float platformX;

    private void Start()
    {
        
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "platforms")
        {
            if (col.transform.position.x < 0)
            {
                platformX = Random.Range(minX, 0);
            }
            else
            {
                platformX = Random.Range(0, maxX);
            }
            

            Vector3 spawnposition = new Vector3(platformX, col.transform.position.y + distance * 8, 0);

            col.gameObject.transform.position = spawnposition;
        }
    }
}
