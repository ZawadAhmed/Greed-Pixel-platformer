using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   public void Play(){
        Debug.Log(SceneManager.GetActiveScene().buildIndex +1);  //SceneManager.LoadScene("Opening");
        SceneManager.LoadScene("Scene 2");
   }


}
