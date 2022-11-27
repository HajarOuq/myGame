using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //public character chara;
    public static Ball instance;
    public int color=1;
    public GameObject pink, orange;
    public GameObject green, cam;
    //1 pink 
    //2 orange
    private void Awake()
    {
        instance = this;
    }

    public void job()
    {
        GameObject charac;
        if (color == 1)
        {
            charac = pink;
            charac.GetComponent<Transform>().position = new Vector3(green.transform.position.x, green.transform.position.y - 0.65f, green.transform.position.z);
        }
        else
        {
            charac = orange;
            charac.GetComponent<Transform>().position = new Vector3(green.transform.position.x, green.transform.position.y - 1.3f, green.transform.position.z);
        }
       
        charac.transform.parent = cam.transform;
        Destroy(this.gameObject);
    }
}
