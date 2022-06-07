/***================== Indice do codigo para entendimento ====================***/
/*** 1.0   - Movimentacao                                                     ***/
/*****                                                                        ***/
/*** 2.0   - Limite de movimentacao                                           ***/
/*****                                                                        ***/
/*** 3.0   - Pontuacao                                                        ***/
/*****                                                                        ***/
/*** 4.0   - Fim de jogo                                                      ***/
/*****                                                                        ***/
/**================== Fim Indice do codigo para entendimento =================***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    //1.0   - Para declaração do personagem
    public GameObject player;
    //1.0   - Para a velocidade da movimentação
    public float velocidadeY;
    //1.0   - Para a velocidade da movimentação
    public float velocidadeX;
    //2.0   - Para a altura maxima que o personagem pode ir
    public float maxAltura;
    //2.0   - Para a altura minima que o personagem pode ir
    public float minAltura;
    //3.0   - Para contagem de objetos que passou
    public int   pontuacao;
    //3.0   - Para apresentação na tela de quantos objetos passou
    public TextMesh   pontos;
    //3.0   - Para apresentação na tela de quantos objetos passou
    public TextMesh   recorde;

    void Update(){
        //1.0   - Para usar o que precionado movimentação para cima e para baixo
        float movimentacaoY = Input.GetAxis("Vertical") * velocidadeY;
        //1.0   - Para usar o que precionado movimentação esquerda e direita
        float movimentacaoX = Input.GetAxis("Horizontal") * velocidadeX;
        //1.0   - Para realizar a movimentação
        player.transform.Translate(movimentacaoX, movimentacaoY, 0);

        //2.0   - para definir o maximo e minimo da altura que pode ir
        if (player.transform.position.y > maxAltura){
            player.transform.position = new Vector2(player.transform.position.x, maxAltura); 
        }else if (player.transform.position.y < minAltura){
            player.transform.position = new Vector2(player.transform.position.x, minAltura);
        }

        //3.0   - Para apresentacao na tela da pontuacao atual e para a maior pontuacao feita no jogo
        pontos.text  = pontuacao.ToString();
        recorde.text = PlayerPrefs.GetInt("recorde").ToString();
    }

    private void OnTriggerEnter2D(Collider2D colisao){
        //3.0   - Para gravar o recorde de pontuação  
        if (pontuacao > PlayerPrefs.GetInt("recorde")){
            PlayerPrefs.SetInt("recorde", pontuacao);
        }

        //4.0   - Para quando colidir ir para a cena descrita
        SceneManager.LoadScene("gameOver");
    }

    //3.0   - para acrescimo de pontos 
    public void AddScore(){
        pontuacao++;
    }
}
