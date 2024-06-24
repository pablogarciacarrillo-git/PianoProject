using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class activacionTecla : MonoBehaviour
{
    private int paso;
    [SerializeField]
    float duracion_frames = 6;
    [SerializeField]
    float max_rotacion = 2;
    public string tecla;

    public Image indicador;

    public AudioSource sonido;

    private Quaternion rotacion_ini = new Quaternion(-0.707106829f,0,0,0.707106829f);

    // Start is called before the first frame update
    void Start()
    {
        transform.SetPositionAndRotation(transform.position, rotacion_ini);
        paso = 0;

        sonido.enabled = false;

        indicador.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(tecla))
        {
            sonido.enabled = false;
            sonido.enabled = true;
        }

        if (Input.GetKey(tecla))
        {
            indicador.color = Color.grey;
            if (paso < duracion_frames)
            {
                transform.Rotate(max_rotacion/duracion_frames, 0, 0);
                paso++;
            }
        } else 
        {
            indicador.color = Color.white;
            if (paso > 0)
            {
                transform.Rotate(-max_rotacion/duracion_frames, 0, 0);
                paso--;
            }
        }
    }
}
