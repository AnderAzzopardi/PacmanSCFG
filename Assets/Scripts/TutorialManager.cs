using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
   private void Awake()
{
    if(!PlayerPrefs.HasKey("firstTime") || PlayerPrefs.GetInt("firstTime") != 1)
    {
        PlayerPrefs.SetInt("firstTime", 1);
        PlayerPrefs.Save();
    }
    else if(PlayerPrefs.GetInt("firstTime") == 1)
    {
         SceneManager.LoadScene (1);
    }
}

}
