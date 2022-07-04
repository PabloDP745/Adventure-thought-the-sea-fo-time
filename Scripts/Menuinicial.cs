using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menuinicial : MonoBehaviour
{
   public void jugar(){
    SceneManager.LoadScene("Level1");
   }
   public void Salir(){
    Application.Quit();
   }
}
