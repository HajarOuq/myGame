using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{

    public GameObject firstPlatform, platformParent, heal;
    public float maxY = 2f,minXScreen=-2.21f,maxXScreen=2.21f;
    public GameObject[] listFloor;
    public List<GameObject> generatedPlatforms=new List<GameObject>();
    public GameObject pink, orange;

    public int NumberOfPlats = 100;
    void Start()
    {
        generate();
    }
    
    void generate()
    {
        //Vector2 size = firstPlatform.GetComponent<SpriteRenderer>().size;
        Vector2 position;
        GameObject clone = firstPlatform;
        float positionX;

        for (int i = 0; i <= 100; i++)
        {                    
            if (clone.transform.position.x > 0)
            {
                positionX = Random.Range(minXScreen, -0.4f);
            }
            else
            {
                positionX = Random.Range(0.4f, maxXScreen);
            }

            position = new Vector2(positionX, clone.transform.position.y + maxY);
            if (i >= 10)
            {
                if (i < 30)
                    clone = Instantiate(listFloor[Random.Range(0, listFloor.Length-1)]);
                else
                    clone = Instantiate(listFloor[Random.Range(0, listFloor.Length)]);
            }
            else
                clone = Instantiate(clone);
            clone.transform.position = position;
            clone.transform.parent = platformParent.transform;
            generatedPlatforms.Add(clone);

            if (i%6==0)
            {

            }
        }

        pink.GetComponent<Transform>().position = new Vector3(generatedPlatforms[9].GetComponent<Transform>().position.x, generatedPlatforms[9].GetComponent<Transform>().position.y + pink.GetComponent<Transform>().localScale.y, generatedPlatforms[9].GetComponent<Transform>().position.z);
        orange.GetComponent<Transform>().position = new Vector3(generatedPlatforms[29].GetComponent<Transform>().position.x, generatedPlatforms[29].GetComponent<Transform>().position.y + orange.GetComponent<Transform>().localScale.y, generatedPlatforms[29].GetComponent<Transform>().position.z);
    }

}
