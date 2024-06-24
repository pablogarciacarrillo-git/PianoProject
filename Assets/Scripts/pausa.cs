using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class pausa : MonoBehaviour
{
    public GameObject panelPausa;

    public static bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        panelPausa.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        panelPausa.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()
    {
        panelPausa.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
}
