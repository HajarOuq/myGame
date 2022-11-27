using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject sky;
    Color32 color;
    public float h=208, s=67, v=100;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        sky.GetComponent<SpriteRenderer>().color = Color.HSVToRGB(h / 360, s / 100, v / 100);

    }
}
