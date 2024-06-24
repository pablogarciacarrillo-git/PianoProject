using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nota : MonoBehaviour
{
    public float linea, init, vel, margen;
    public float reducAlpha = 0.005f;
    //public float y;
    public controladorJuego c;
    string nombre;

    public bool borrando;
    Color imagen;


    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector3(transform.position.x, init, transform.position.z);
        borrando = false;
        //imagen = GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - (vel * Time.deltaTime), transform.position.z);
        if (borrando)
        {
            float newA = GetComponent<Image>().color.a - reducAlpha;
            if (newA <= 0)
            {
                Destroy(gameObject);
            } else
            {
                GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, newA);
                //imagen = new Color(imagen.r, imagen.g, imagen.b, newA);
            }
        } else if (GetComponent<RectTransform>().anchoredPosition.y < (linea - margen))
        {
            c.quitarNota(nombre);
            borrando = true;
        }
    }

    /*
    void setX(int newX)
    {
        transform.position = transform.position + new Vector3(newX, 0, 0);
    }
    */

    public void setNombre(string n)
    {
        nombre = n;
    }

    public bool borrar()
    {
        borrando = true;
        return (GetComponent<RectTransform>().anchoredPosition.y < (linea + margen));
    }

}
