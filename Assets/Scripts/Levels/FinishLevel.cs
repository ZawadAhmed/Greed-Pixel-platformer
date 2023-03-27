using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    private void Play(){
        Debug.Log(SceneManager.GetActiveScene().buildIndex +1);  //SceneManager.LoadScene("Opening");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
   }

}
