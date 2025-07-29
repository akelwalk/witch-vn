using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Restart : MonoBehaviour
{
    // public void callRestartCoroutine()
    // {
    //     StartCoroutine(restartBuffer());
    // }
    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // private IEnumerator restartBuffer()
    // {
    //     restartLevel();
    //     yield return new WaitForSeconds(0.1f);
    // }
}
