/***================== Indice do codigo para entendimento ====================***/
/*** 1.0   - Invocacao de inimigo                                             ***/
/*****                                                                        ***/
/*** 2.0   - Limite de apresentacao na tela                                   ***/
/*****                                                                        ***/
/**================== Fim Indice do codigo para entendimento =================***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    //1.0   - Para o maximo de spawner que poder ser feito
    public  int        maxDuende;
    //2.0   - Para a altura maxima que o objeto aparece
    public  float      maxAltura;
    //2.0   - Para a altura minima que o objeto aparece
    public  float      minAltura;
    //1.0   - Para determinar de quanto em quanto tempo ira spawner
    public  float      rateSpawn;
    //1.0   - Para contar o tempo se é ou não para spawner
    private float      currentRateSpawn;
    //1.0   - para apresentar de forma aleatoria o objeto
    private float      posicaoAleatoria;
    //1.0   - para setar o objeto que vai spawnar
    public  GameObject      prefab;
    //1.0   - para guardar os objetos e ir spawnando na tela
    public List<GameObject> duende;

    void Start(){
        for (int i=0; i < maxDuende; i++){
            GameObject tempDuende = Instantiate(prefab) as GameObject;
            duende.Add(tempDuende);
            tempDuende.SetActive(false);
        }
    }

    void Update(){
        currentRateSpawn += Time.deltaTime;
        if (currentRateSpawn > rateSpawn){
            Spawn();
            currentRateSpawn = 0;
        }
    }

    private void Spawn(){
        //2.0   - comentado pois pode aparecer em lugares na frente do personagem não podendo desviar como exemplo entre a parte de cima e baixo, no meio
        //float posicaoAleatoria = Random.Range (minAltura, maxAltura);
        int aleatorio = Random.Range (0, 9);

        if (aleatorio < 5){
            posicaoAleatoria  = minAltura;
        } else{
            posicaoAleatoria  = maxAltura;
        }

        GameObject tempDuende = null;
        
        for (int i = 0; i < maxDuende; i++){
            if (duende[i].activeSelf == false){
                tempDuende    = duende[i];
                break;
            }
        }
        
        if (tempDuende != null){
            tempDuende.transform.position = new Vector3(transform.position.x, posicaoAleatoria, transform.position.z);
            tempDuende.SetActive(true);
        }
    }
}
