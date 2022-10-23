using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformGenerotor : MonoBehaviour
{

    public GameObject firstPlateform, plateformParent;
    public float maxY = 1.5f,minXScreen=-2.21f,maxXScreen=2.21f,minOffsetBetweenPlateforms=2;

    public int NumberOfPlats = 100;
    void Start()
    {
        generate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void generate()
    {
        Vector2 size = firstPlateform.GetComponent<SpriteRenderer>().size;
        Vector2 rightEndPoint;
        GameObject clone = firstPlateform;
        float offsetX = 0;
        
        for (int i = 0; i <=100; i++)
        {
            if(i%2!=0)
            {
                offsetX = Random.Range(minXScreen, clone.transform.position.x -size.x- minOffsetBetweenPlateforms);
                rightEndPoint = new Vector2((clone.transform.position.x + offsetX) % minXScreen, clone.transform.position.y + maxY);              
            }
            else
            {
                offsetX = Random.Range(clone.transform.position.x +size.x+ minOffsetBetweenPlateforms, maxXScreen);
                rightEndPoint = new Vector2((clone.transform.position.x + offsetX) % maxXScreen, clone.transform.position.y + maxY);
            }
           
            clone = Instantiate(clone);
            clone.transform.position = rightEndPoint;
            //clone.transform.parent = plateformParent.transform;
        }
  
    }

}
