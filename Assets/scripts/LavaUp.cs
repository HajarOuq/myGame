using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaUp : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (character.instance.hp <= 0)
            return;
        
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.02f, transform.position.z);
    }
}
