using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    //para o maximo de spawner que poder ser feito
    public  int        maxDuende;
    //para a altura maxima que o objeto aparece
    public  float      maxAltura;
    //para a altura minima que o objeto aparece
    public  float      minAltura;
    //para determinar de quanto em quanto tempo ira spawner
    public  float      rateSpawn;
    //Para contar o tempo se é ou não para spawner
    private float      currentRateSpawn;
    //para apresentar de forma aleatoria o objeto
    private float      posicaoAleatoria;
    //para setar o objeto que vai spawnar
    public  GameObject prefab;
    //para guardar os objetos e ir spawnando na tela
    public  List<GameObject> duende;

    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i < maxDuende; i++)
        {
            GameObject tempDuende = Instantiate(prefab) as GameObject;
            duende.Add(tempDuende);
            tempDuende.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentRateSpawn += Time.deltaTime;
        if (currentRateSpawn > rateSpawn) 
        {
            Spawn();
            currentRateSpawn = 0;
        }
    }

    private void Spawn()
    {
 
        //comentado pois pode aparecer em lugares na frente do personagem não mpodendo desviar como exemplo entre a parte de cima e baixo, no meio
        //float posicaoAleatoria = Random.Range (minAltura, maxAltura);
        int aleatorio = Random.Range (0, 9);

        if (aleatorio < 5)
        {
            posicaoAleatoria  = minAltura;
        }
        else
        {
            posicaoAleatoria  = maxAltura;
        }

        GameObject tempDuende = null;
        
        for (int i = 0; i < maxDuende; i++)
        {
            if (duende[i].activeSelf == false)
            {
                tempDuende    = duende[i];
                break;
            }
        }
        
        if (tempDuende != null)
        {
            tempDuende.transform.position = new Vector3(transform.position.x, posicaoAleatoria, transform.position.z);
            tempDuende.SetActive(true);
        }
    }
}
