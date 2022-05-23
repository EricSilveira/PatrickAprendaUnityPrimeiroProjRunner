using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    //para a altura maxima que o personagem pode ir
    public float maxAltura;
    //para a altura minima que o personagem pode ir
    public float minAltura;
    //para a velocidade da movimenta��o
    public float velocidadeY;
    //para a velocidade da movimenta��o
    public float velocidadeX;
    //para contagem de objetos que passou
    public int   pontuacao;

    //para apresenta��o na tela de quantos objetos passou
    public TextMesh   pontos;
    //para apresenta��o na tela de quantos objetos passou
    public TextMesh   recorde;
    //Para declara��o do personagem
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        //para usar o que precionado movimenta��o para cima e para baixo
        float movimentacaoY = Input.GetAxis("Vertical") * velocidadeY;
        //para usar o que precionado movimenta��o esquerda e direita
        float movimentacaoX = Input.GetAxis("Horizontal") * velocidadeX;
        //para realizar a movimenta��o
        player.transform.Translate(movimentacaoX, movimentacaoY, 0);
        //para definir o maximo e minimo da altura que pode ir
        if (player.transform.position.y > maxAltura)
        {
            player.transform.position = new Vector2(player.transform.position.x, maxAltura); 
        }else if (player.transform.position.y < minAltura)
        {
            player.transform.position = new Vector2(player.transform.position.x, minAltura);
        }

        pontos.text  = pontuacao.ToString();
        recorde.text = PlayerPrefs.GetInt("recorde").ToString();
    }

    private void OnTriggerEnter2D(Collider2D colisao)
    {
        //para gravar o recorde de pontua��o  
        if (pontuacao > PlayerPrefs.GetInt("recorde"))
        {
            PlayerPrefs.SetInt("recorde", pontuacao);
        }

        //para quando colidir ir para a cena descrita
        SceneManager.LoadScene("gameOver");
    }

    //para acrescimo de pontos 
    public void AddScore()
    {
        pontuacao++;
    }
}
