using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLv3Health : MonoBehaviour
{



    void Update()
    {
        if (gameObject.transform.position.y <= -7)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(5);
        }
    }
}
