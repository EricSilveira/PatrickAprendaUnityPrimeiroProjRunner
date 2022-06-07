/***================== Indice do codigo para entendimento ====================***/
/*** 1.0   - Reiniciar o jogo apartir do game over                            ***/
/*****                                                                        ***/
/**================== Fim Indice do codigo para entendimento =================***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverControl : MonoBehaviour
{
    void Update(){
        //1.0   - Para quando pressionar ir para a tela atraves do loadscene neste caso vai para TelaPlay
        if (Input.GetButtonDown("Fire1")){
            SceneManager.LoadScene("TelaPlay");
        }
    }
}
