using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject painelMenuPrincipal;
    [SerializeField] private GameObject painelOptions;
  public void Jogar() 
    {
        SceneManager.LoadScene("GAME");
    }
    public void AbrirOptions()
    {
        painelMenuPrincipal.SetActive(false);
        painelOptions.SetActive(true);
    }
    public void FecharOptions()
    {
        painelOptions.SetActive(false);
        painelMenuPrincipal.SetActive(true);
    }
    public void Sair()
    {
        Debug.Log("Saindo do Jogo");
        Application.Quit();
    }
}
