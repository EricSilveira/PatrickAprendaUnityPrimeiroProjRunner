/***================== Indice do codigo para entendimento ====================***/
/*** 1.0   - Movimentacao cenario                                             ***/
/*****                                                                        ***/
/**================== Fim Indice do codigo para entendimento =================***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOffset : MonoBehaviour
{
    //1.0   - Para a movimentação da textura aplicada
    private float    offset;
    //1.0   - Para a velocidade da movimentacao
    public float    speed;
    //1.0   - Para tudo que for cenario poder mover
    private Material currentMaterial;

    void Start(){
        //1.0   - Aqui a variavel ira receber o renderer padrao para iniciacao de componentes apresentados na Unity
        currentMaterial = GetComponent<Renderer>().material;        
    }

    void Update(){
        offset += 0.001f;
        //1.0   - _Maintex serve para dizer que eh a textura principal do objeto
        currentMaterial.SetTextureOffset("_MainTex", new Vector2(offset * speed, 0));
    }
}
