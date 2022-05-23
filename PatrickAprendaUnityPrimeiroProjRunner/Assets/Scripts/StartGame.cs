using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //para quando clicado ir para a cena descrita
        if (Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene("TelaPlay");
        }
    }
}
