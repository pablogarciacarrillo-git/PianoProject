using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class controladorJuego : MonoBehaviour
{
    public int cancion;
    public float puntAcierto, puntActual;
    public float separacion, bps;
    
    public static float objetivo = 0.6f;

    float puntMax;

    IDictionary<string, (float, Queue<GameObject>)> notas = new Dictionary<string, (float, Queue<GameObject>)>(){
        {"DO", (0f, new Queue<GameObject>())},
        {"DO#", (0.5f, new Queue<GameObject>())},
        {"RE", (1f, new Queue<GameObject>())},
        {"MIb", (1.5f, new Queue<GameObject>())},
        {"MI", (2f, new Queue<GameObject>())},
        {"FA", (3f, new Queue<GameObject>())},
        {"FA#", (3.5f, new Queue<GameObject>())},
        {"SOL", (4f, new Queue<GameObject>())},
        {"LAb", (4.5f, new Queue<GameObject>())},
        {"LA", (5f, new Queue<GameObject>())},
        {"SIb", (5.5f, new Queue<GameObject>())},
        {"SI", (6f, new Queue<GameObject>())},
        {"DO2", (7f, new Queue<GameObject>())}
    };

    IDictionary<string, string> teclas = new Dictionary<string, string>(){
        {"a", "DO"},
        {"w", "DO#"},
        {"s", "RE"},
        {"e", "MIb"},
        {"d", "MI"},
        {"f", "FA"},
        {"t", "FA#"},
        {"g", "SOL"},
        {"y", "LAb"},
        {"h", "LA"},
        {"u", "SIb"},
        {"j", "SI"},
        {"k", "DO2"}
    };

    IDictionary<string, (icono, icono)> iconos = new Dictionary<string, (icono, icono)>();

    public GameObject do1, iBien, iMal, panelFinal, msgVictoria, msgFallo;
    public TMP_Text aciertos, fallos;
    public Transform panelNotas;

    // Start is called before the first frame update
    void Start()
    {
        foreach (string nota in notas.Keys)
        {
            GameObject i1 = Instantiate(iBien, panelNotas);
            GameObject i2 = Instantiate(iMal, panelNotas);

            i1.transform.position = i1.transform.position + new Vector3((notas[nota].Item1 * separacion), 0, 0);
            i2.transform.position = i2.transform.position + new Vector3((notas[nota].Item1 * separacion), 0, 0);

            iconos.Add(nota, (i1.GetComponent<icono>(), i2.GetComponent<icono>()));
        }
        
        puntMax = 0;
        puntActual = 0;

        //cancionEjemplo();

        if (cancion == 1)
        {
            sinfoniaNuevoMundo();
        } else if (cancion == 2)
        {
            himnoAlegria();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown("escape"))
        {
            cambiarEscena(0);
        }
        */
        foreach (string tecla in teclas.Keys)
        {
            if (Input.GetKeyDown(tecla))
            {
                tocar(teclas[tecla]);
            }
        }
    }

    void tocar(string n)
    {
        GameObject nt = quitarNota(n);
        if (nt == null)
        {
            return;
        }
        nota objNota = nt.GetComponent<nota>();
        if (objNota.borrar())
        {
            puntActual += puntAcierto;
            iconos[n].Item1.mostrar();
        } else
        {
            iconos[n].Item2.mostrar();
        }
    }

    public GameObject quitarNota(string n)
    {
        if (notas[n].Item2.Count <= 0)
        {
            return null;
        } else
        {
            return notas[n].Item2.Dequeue();
        }
    
    }

    void crearNota(string n)
    {
        puntMax += puntAcierto;
        GameObject o = Instantiate(do1, panelNotas);
        notas[n].Item2.Enqueue(o);
        o.transform.position = o.transform.position + new Vector3((notas[n].Item1 * separacion), 0, 0);
        o.GetComponent<nota>().setNombre(n);
        o.SetActive(true);
    }

    void terminar()
    {
        if (puntActual >= (puntMax * objetivo))
        {
            msgVictoria.SetActive(true);
        } else
        {
            msgFallo.SetActive(true);
        }

        aciertos.text = "Aciertos: " + puntActual;
        fallos.text = "Fallos: " + (puntMax - puntActual);

        PlayerPrefs.SetFloat("puntCancion" + cancion, puntActual/puntMax);

        panelFinal.SetActive(true);
    }

    public void cambiarEscena(int i){
        Time.timeScale = 1f;
        StartCoroutine(pasar(i));
    }

    IEnumerator pasar(int i){
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(i);
    }

    void crearDo()
    {
        crearNota("DO");
    }

    void crearDoS()
    {
        crearNota("DO#");
    }

    void crearRe()
    {
        crearNota("RE");
    }

    void crearMiB()
    {
        crearNota("MIb");
    }

    void crearMi()
    {
        crearNota("MI");
    }

    void crearFa()
    {
        crearNota("FA");
    }

    void crearFaS()
    {
        crearNota("FA#");
    }

    void crearSol()
    {
        crearNota("SOL");
    }

    void crearLaB()
    {
        crearNota("LAb");
    }

    void crearLa()
    {
        crearNota("LA");
    }

    void crearSiB()
    {
        crearNota("SIb");
    }

    void crearSi()
    {
        crearNota("SI");
    }

    void crearDo2()
    {
        crearNota("DO2");
    }

    void cancionEjemplo()
    {
        Invoke("crearMi", 1f + 0f / bps);

        Invoke("crearSol", 1f + 0.75f / bps);

        Invoke("crearSol", 1f + 1f / bps);

        Invoke("crearMi", 1f + 2f / bps);

        Invoke("crearRe", 1f + 2.75f / bps);

        Invoke("crearDo", 1f + 3f / bps);

        Invoke("crearRe", 1f + 4f / bps);

        Invoke("crearMi", 1f + 4.75f / bps);

        Invoke("crearSol", 1f + 5f / bps);

        Invoke("crearMi", 1f + 5.75f / bps);

        Invoke("crearRe", 1f + 6f / bps);

        Invoke("crearMi", 1f + 8f / bps);

        Invoke("crearSol", 1f + 8.75f / bps);

        Invoke("terminar", 1f + 17f / bps);
    }

    void sinfoniaNuevoMundo()
    {
        Invoke("crearMi", 1f + 0f / bps);

        Invoke("crearSol", 1f + 0.75f / bps);

        Invoke("crearSol", 1f + 1f / bps);

        Invoke("crearMi", 1f + 2f / bps);

        Invoke("crearRe", 1f + 2.75f / bps);

        Invoke("crearDo", 1f + 3f / bps);

        Invoke("crearRe", 1f + 4f / bps);

        Invoke("crearMi", 1f + 4.75f / bps);

        Invoke("crearSol", 1f + 5f / bps);

        Invoke("crearMi", 1f + 5.75f / bps);

        Invoke("crearRe", 1f + 6f / bps);

        Invoke("crearMi", 1f + 8f / bps);

        Invoke("crearSol", 1f + 8.75f / bps);

        Invoke("crearSol", 1f + 9f / bps);

        Invoke("crearMi", 1f + 10f / bps);

        Invoke("crearRe", 1f + 10.75f / bps);

        Invoke("crearDo", 1f + 11f / bps);

        Invoke("crearRe", 1f + 12f / bps);

        Invoke("crearMi", 1f + 12.5f / bps);

        Invoke("crearRe", 1f + 13f / bps);

        Invoke("crearDo", 1f + 13.75f / bps);

        Invoke("crearDo", 1f + 14f / bps);

        Invoke("crearLa", 1f + 16f / bps);

        Invoke("crearDo2", 1f + 16.75f / bps);

        Invoke("crearDo2", 1f + 17f / bps);

        Invoke("crearSi", 1f + 18f / bps);

        Invoke("crearSol", 1f + 18.5f / bps);

        Invoke("crearLa", 1f + 19f / bps);

        Invoke("crearLa", 1f + 20f / bps);

        Invoke("crearDo2", 1f + 20.5f / bps);

        Invoke("crearSi", 1f + 21f / bps);

        Invoke("crearSol", 1f + 21.5f / bps);

        Invoke("crearLa", 1f + 22f / bps);

        Invoke("crearLa", 1f + 24f / bps);

        Invoke("crearDo2", 1f + 24.75f / bps);

        Invoke("crearDo2", 1f + 25f / bps);

        Invoke("crearSi", 1f + 26f / bps);

        Invoke("crearSol", 1f + 26.5f / bps);

        Invoke("crearLa", 1f + 27f / bps);

        Invoke("crearLa", 1f + 28f / bps);

        Invoke("crearDo2", 1f + 28.5f / bps);

        Invoke("crearSi", 1f + 29f / bps);

        Invoke("crearSol", 1f + 29.5f / bps);

        Invoke("crearLa", 1f + 30f / bps);

        Invoke("crearMi", 1f + 32f / bps);

        Invoke("crearSol", 1f + 32.75f / bps);

        Invoke("crearSol", 1f + 33f / bps);

        Invoke("crearMi", 1f + 34f / bps);

        Invoke("crearRe", 1f + 34.75f / bps);

        Invoke("crearDo", 1f + 35f / bps);

        Invoke("crearRe", 1f + 36f / bps);

        Invoke("crearMi", 1f + 36.75f / bps);

        Invoke("crearSol", 1f + 37f / bps);

        Invoke("crearMi", 1f + 37.75f / bps);

        Invoke("crearRe", 1f + 38f / bps);

        Invoke("crearSol", 1f + 39f / bps);

        Invoke("crearMi", 1f + 40f / bps);

        Invoke("crearSol", 1f + 40.75f / bps);

        Invoke("crearSol", 1f + 41f / bps);

        Invoke("crearMi", 1f + 42f / bps);

        Invoke("crearRe", 1f + 42.75f / bps);

        Invoke("crearDo", 1f + 43f / bps);

        Invoke("crearRe", 1f + 44f / bps);

        Invoke("crearMi", 1f + 44.5f / bps);

        Invoke("crearRe", 1f + 45f / bps);

        Invoke("crearDo", 1f + 45.75f / bps);

        Invoke("crearDo", 1f + 46f / bps);

        Invoke("terminar", 1f + 56f / bps);
    }

    void himnoAlegria()
    {
        Invoke("crearMi", 1f + 0f / bps);

        Invoke("crearMi", 1f + 1f / bps);

        Invoke("crearFa", 1f + 2f / bps);

        Invoke("crearSol", 1f + 3f / bps);

        Invoke("crearSol", 1f + 4f / bps);

        Invoke("crearFa", 1f + 5f / bps);

        Invoke("crearMi", 1f + 6f / bps);

        Invoke("crearRe", 1f + 7f / bps);

        Invoke("crearDo", 1f + 8f / bps);

        Invoke("crearDo", 1f + 9f / bps);

        Invoke("crearRe", 1f + 10f / bps);

        Invoke("crearMi", 1f + 11f / bps);

        Invoke("crearMi", 1f + 12f / bps);

        Invoke("crearRe", 1f + 14f / bps);

        Invoke("crearMi", 1f + 16f / bps);

        Invoke("crearMi", 1f + 17f / bps);

        Invoke("crearFa", 1f + 18f / bps);

        Invoke("crearSol", 1f + 19f / bps);

        Invoke("crearSol", 1f + 20f / bps);

        Invoke("crearFa", 1f + 21f / bps);

        Invoke("crearMi", 1f + 22f / bps);

        Invoke("crearRe", 1f + 23f / bps);

        Invoke("crearDo", 1f + 24f / bps);

        Invoke("crearDo", 1f + 25f / bps);

        Invoke("crearRe", 1f + 26f / bps);

        Invoke("crearMi", 1f + 27f / bps);

        Invoke("crearRe", 1f + 28f / bps);

        Invoke("crearDo", 1f + 30f / bps);

        Invoke("crearRe", 1f + 32f / bps);

        Invoke("crearRe", 1f + 33f / bps);
        
        Invoke("crearMi", 1f + 34f / bps);
        
        Invoke("crearDo", 1f + 35f / bps);
        
        Invoke("crearRe", 1f + 36f / bps);
        
        Invoke("crearMi", 1f + 37f / bps);
        
        Invoke("crearFa", 1f + 37.5f / bps);
        
        Invoke("crearMi", 1f + 38f / bps);

        Invoke("crearDo", 1f + 39f / bps);

        Invoke("crearRe", 1f + 40f / bps);
        
        Invoke("crearMi", 1f + 41f / bps);
        
        Invoke("crearFa", 1f + 41.5f / bps);
        
        Invoke("crearMi", 1f + 42f / bps);

        Invoke("crearRe", 1f + 43f / bps);

        Invoke("crearDo", 1f + 44f / bps);

        Invoke("crearRe", 1f + 45f / bps);

        Invoke("crearSol", 1f + 46f / bps); //REVISAR

        Invoke("crearMi", 1f + 48f / bps);

        Invoke("crearMi", 1f + 49f / bps);

        Invoke("crearFa", 1f + 50f / bps);

        Invoke("crearSol", 1f + 51f / bps);

        Invoke("crearSol", 1f + 52f / bps);

        Invoke("crearFa", 1f + 53f / bps);

        Invoke("crearMi", 1f + 54f / bps);

        Invoke("crearRe", 1f + 55f / bps);

        Invoke("crearDo", 1f + 56f / bps);

        Invoke("crearDo", 1f + 57f / bps);

        Invoke("crearRe", 1f + 58f / bps);

        Invoke("crearMi", 1f + 59f / bps);

        Invoke("crearRe", 1f + 60f / bps);

        Invoke("crearDo", 1f + 62f / bps);


        Invoke("terminar", 1f + 76f / bps);
    }

}
