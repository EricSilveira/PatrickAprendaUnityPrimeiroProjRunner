/***================== Indice do codigo para entendimento ====================***/
/*** 1.0   - Inimigo                                                          ***/
/*****                                                                        ***/
/*** 2.0   - Ajuste de spawner                                                ***/
/*****                                                                        ***/
/*** 3.0   - Pontuacao                                                        ***/
/*****                                                                        ***/
/**================== Fim Indice do codigo para entendimento =================***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuendeBehaviour : MonoBehaviour
{
    //2.0   - Para poder ajustar o spaw de apresentação 
    private SpawnObject   spawn;
    //3.0   - Para ter parametro do player saber se passou
    private PlayerControl player;
    //1.0   - Para declaração do objeto na plataforma
    public  GameObject    duende;
    //1.0   - Velocidade que o duende vai movimentar
    public  float         velocidade;
    //3.0   - Para verificação se passou pelo objeto declarado
    private bool          passou;

    void Start(){
        //3.0   - Para localizar a posição do player usando a classe PlayerControl
        player = FindObjectOfType(typeof(PlayerControl)) as PlayerControl;
        //2.0   - Para realizar a utilizacao do spawner da classe SpawnerObject
        spawn = FindObjectOfType(typeof(SpawnObject)) as SpawnObject;
    }

    private void OnEnable(){
        passou = false;
    }

    void Update(){
        //2.0   - Colocar uma dificuldade conforme aumento da pontuação
        if (player.pontuacao >= 30){
            velocidade      = -20;
            spawn.rateSpawn = 0.2f;
        } else if (player.pontuacao >= 20){
            velocidade      = -15;
            spawn.rateSpawn = 0.4f;
        } else if (player.pontuacao >= 10){
            velocidade      = -12;
            spawn.rateSpawn = 0.6f;
        }

        transform.position += new Vector3(velocidade, 0, 0) * Time.deltaTime;

        if (transform.position.x < player.transform.position.x && !passou){
            player.AddScore();
            passou = true;
            GetComponent<AudioSource>().Play();
        }

        //1.0   - Para desativar o objeto em determinada posição para que possa ser reutilizado
        if (transform.position.x < -8.99f){
            duende.SetActive(false);
        }
    }
}
