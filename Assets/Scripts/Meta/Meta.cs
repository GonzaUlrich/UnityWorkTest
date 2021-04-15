using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meta : MonoBehaviour
{
    public GameObject coinSpawner;

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "RockTag"){
            coinSpawner.GetComponent<CoinSpawner>().SpanwCoin(1);
            col.GetComponent<Rock>().SetUltimoRebote();
            col.gameObject.SetActive(false);
        }
    }
}
