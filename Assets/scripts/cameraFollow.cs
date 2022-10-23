using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform chartransform;
    Vector3 range;

    private void Awake()
    {
        range = transform.position - chartransform.position;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x,range.y + chartransform.position.y, range.z + chartransform.position.z);
    }
}
