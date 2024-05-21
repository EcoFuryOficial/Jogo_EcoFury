using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    [SerializeField] private GameObject painelContinue;
    public void Continuar1()
    {
        SceneManager.LoadScene("Desmatamento");
    }
    public void Continuar2()
    {
        SceneManager.LoadScene("Fase1");
    }
}
