using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public static Ball instance;
    public int color = 1;
    public GameObject pink, orange;
    public GameObject pinkico, orangeico;
    public GameObject green, cam;
    public GameObject pauseMenu;

    //1 pink 
    //2 orange
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        pinkico.SetActive(false);
        orangeico.SetActive(false);
        pauseMenu.SetActive(false);
    }

    public void job()
    {
        GameObject chara;
        pauseMenu.SetActive(true);

        if (color == 1)
        {
            chara = pink;
            pinkico.SetActive(true);
            chara.GetComponent<Transform>().position = new Vector3(green.transform.position.x, green.transform.position.y - 0.65f, green.transform.position.z);
        }
        else
        {
            chara = orange;
            orangeico.SetActive(true);
            chara.GetComponent<Transform>().position = new Vector3(green.transform.position.x, green.transform.position.y - 1.3f, green.transform.position.z);
        }

        chara.transform.parent = cam.transform;
        Destroy(this.gameObject);
    }

    public void pause()
    {
        Time.timeScale = 0;
    }
}
