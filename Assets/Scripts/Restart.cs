using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour {
    public int sceneNum;
    public void ReloadLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneNum);

    }
}
