/***================== Indice do codigo para entendimento ====================***/
/*** 1.0   - Iniciar jogo                                                     ***/
/*****                                                                        ***/
/**================== Fim Indice do codigo para entendimento =================***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    void Update(){
        //1.0   - Para quando clicado ir para a cena descrita atraves do loadscene neste caso vai para TelaPlay
        if (Input.GetButtonDown("Fire1")){
            SceneManager.LoadScene("TelaPlay");
        }
    }
}
