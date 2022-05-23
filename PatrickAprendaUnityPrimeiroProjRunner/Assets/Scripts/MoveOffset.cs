using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOffset : MonoBehaviour
{
    //para a movimentação da textura aplicada
    private float    offset;
    //para a velocidade da movimenta��o
    public  float    speed;
    //para tudo que for cenario poder mover
    private Material currentMaterial;


    // Start is called before the first frame update
    void Start()
    {
        currentMaterial = GetComponent<Renderer>().material;        
    }

    // Update is called once per frame
    void Update()
    {
        offset += 0.001f;
        //_maintex serve para dizer que é a textura principal do objeto
        currentMaterial.SetTextureOffset("_MainTex", new Vector2(offset * speed, 0));
    }
}
