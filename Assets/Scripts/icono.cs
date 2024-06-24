using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class icono : MonoBehaviour
{
    public float reducAlpha = 0.005f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Image>().color.a > 0)
        {
            float newA = GetComponent<Image>().color.a - reducAlpha;
            if (newA > 0)
            {
                GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, newA);
            } else
            {
                GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 0);
            }
        }
        
    }

    public void mostrar()
    {
        GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 1);
    }
}
