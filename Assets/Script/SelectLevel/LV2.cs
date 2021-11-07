using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LV2 : MonoBehaviour
{
    public void changeScene()
    {
        SceneManager.LoadScene(3);
    }
}