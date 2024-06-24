using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controlMenu : MonoBehaviour
{
    public GameObject panelMain, panelAyuda, panelCanciones, panelAjustes;

    // Start is called before the first frame update
    void Start()
    {
        panelMain.SetActive(true);
        panelAyuda.SetActive(false);
        panelCanciones.SetActive(false);
        panelAjustes.SetActive(false);
    }

    public void ayuda(){
        panelAyuda.SetActive(true);
        panelMain.SetActive(false);
    }

    public void cambiarEscena(int i){
        StartCoroutine(pasar(i));
    }

    public void salir(){
        Application.Quit();
    }

    public void cerrarAyuda(){
        panelAyuda.SetActive(false);
        panelMain.SetActive(true);
    }

    public void canciones(){
        panelCanciones.SetActive(true);
        panelMain.SetActive(false);
    }

    public void cerrarCanciones(){
        panelCanciones.SetActive(false);
        panelMain.SetActive(true);
    }

    public void ajustes(){
        panelAjustes.SetActive(true);
        panelMain.SetActive(false);
    }

    public void cerrarAjustes(){
        panelAjustes.SetActive(false);
        panelMain.SetActive(true);
    }
    
    private IEnumerator pasar(int i){
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(i);
    }
}
