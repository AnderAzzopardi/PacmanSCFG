using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool easy = false;
    public bool medium = false;
    public bool hard = false;

    public bool tutorial = false;
    public bool back = false;


    public void EasyBTN()
    {
        easy = true;
        SceneManager.LoadScene(1);
    }

       public void MediumBTN()
    {
        medium = true;
        SceneManager.LoadScene(1);
    }

   public void HardBTN()
    {
        hard = true;
        SceneManager.LoadScene(1);
    }

    public void TutorialBTN()
    {
       SceneManager.LoadScene(2);
    }

    public void BackBTN()
    {
       SceneManager.LoadScene(0);
    }


  
}
