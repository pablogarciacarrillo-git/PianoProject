using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class panelEstrellas : MonoBehaviour
{
    public Sprite CeroEstrellas, UnaEstrella, DosEstrellas, TresEstrellas;
    Image imageComponent;
    public TMP_Text textComponent;

    public float cancion;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        imageComponent = GetComponent<Image>();
        
        float punt = PlayerPrefs.GetFloat("puntCancion" + cancion, 0);

        Debug.Log("Puntuacion: " + punt);
        if (punt < controladorJuego.objetivo)
        {
            imageComponent.sprite = CeroEstrellas;
            Debug.Log("Cero Estrellas");
        } else if (punt < (controladorJuego.objetivo + 1)/2)
        {
            imageComponent.sprite = UnaEstrella;
            Debug.Log("Una Estrella");
        }else if (punt < 1)
        {
            imageComponent.sprite = DosEstrellas;
            Debug.Log("Dos Estrellas");
        } else if (punt == 1)
        {
            imageComponent.sprite = TresEstrellas;
            Debug.Log("Tres Estrellas");
        } else
        {
            Debug.Log("Aviso: puntuación inválida en canción " + cancion);
        }

        if (textComponent != null)
        {
            int porcentaje = (int)(punt*100);
            textComponent.SetText(porcentaje + "%");
        }
    }
}
