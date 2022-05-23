using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuendeBehaviour : MonoBehaviour
{
    //para poder ajustar o spaw de apresenta��o 
    private SpawnObject   spawn;
    //para ter parametro do player saber se passou
    private PlayerControl player;
    //para declara��o do objeto na plataforma
    public  GameObject    duende;
    //velocidade que o duende vai movimentar
    public  float         velocidade;
    //para verifica��o se passou pelo objeto declarado
    private bool          passou;

    // Start is called before the first frame update
    void Start()
    {
        //para localizar a posi��o do player
        player = FindObjectOfType(typeof(PlayerControl)) as PlayerControl;
        //para localizar a posi��o do player
        spawn = FindObjectOfType(typeof(SpawnObject)) as SpawnObject;
    }

    private void OnEnable()
    {
        passou = false;
    }

    // Update is called once per frame
    void Update()
    {
        //colocar uma dificuldade conforme aumento da pontua��o
        if (player.pontuacao >= 30)
        {
            velocidade      = -20;
            spawn.rateSpawn = 0.2f;
        }
        else if (player.pontuacao >= 20)
        {
            velocidade      = -15;
            spawn.rateSpawn = 0.4f;
        }
        else if (player.pontuacao >= 10)
        {
            velocidade      = -12;
            spawn.rateSpawn = 0.6f;
        }


        transform.position += new Vector3(velocidade, 0, 0) * Time.deltaTime;

        if (transform.position.x < player.transform.position.x && !passou)
        {
            player.AddScore();
            passou = true;
            GetComponent<AudioSource>().Play();
        }

        //para desativar o objeto em determinada posi��o para que possa ser reutilizado
        if (transform.position.x < -8.99f)
        {
            duende.SetActive(false);
        }
    }
}
