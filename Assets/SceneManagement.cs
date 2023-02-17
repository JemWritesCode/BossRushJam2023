using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void Start()
    {
        if (!SceneManager.GetSceneByName("Hud").IsValid())
        {
            SceneManager.LoadScene("Hud", new LoadSceneParameters(LoadSceneMode.Additive));
        }
    }
}
