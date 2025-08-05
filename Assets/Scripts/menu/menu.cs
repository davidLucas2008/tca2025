using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMainUI : MonoBehaviour
{
    public void Sair()
    {
        Application.Quit();
    }
    
    public void chamaCena(string nome){
        SceneManager.LoadScene(nome);
    }
}
