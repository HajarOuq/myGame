using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject sky;
    Color32 color;
    float h = 200, s = 60, v = 100;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (character.instance.hp > 0 && canChangeColor)
            StartCoroutine(changeColor());       
    }

    bool canChangeColor = true;
    public IEnumerator changeColor()
    {
        canChangeColor = false;
        v = 100;
        while (v > 10)
        {
            v -= 0.01f;
            sky.GetComponent<SpriteRenderer>().color = Color.HSVToRGB(h / 360, s / 100, v / 100);
            yield return new WaitForSeconds(0.0001f);
        }

        yield return new WaitForSeconds(5);        
      
        while (v < 100)
        {
            v += 0.01f;
            sky.GetComponent<SpriteRenderer>().color = Color.HSVToRGB(h / 360, s / 100, v / 100);
            yield return new WaitForSeconds(0.0001f);
        }
        canChangeColor = true;
        yield return new WaitForSeconds(5);
    }
}
