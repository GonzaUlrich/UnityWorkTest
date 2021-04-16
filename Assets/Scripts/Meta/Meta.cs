using UnityEngine;

public class Meta : MonoBehaviour
{
    public GameObject coinSpawner;
    public int rockValueToSpawnCoin,rockValueAddCanvas;
    private GameObject rockCounter;

    void Start() {
        rockCounter = GameObject.Find("CantRocks");
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "RockTag"){
            coinSpawner.GetComponent<CoinSpawner>().SpanwCoin(rockValueToSpawnCoin);
            rockCounter.GetComponent<CantRock>().AddRockOnCanvas(rockValueAddCanvas);
            col.GetComponent<Rock>().SetUltimoRebote();
            col.gameObject.SetActive(false);
        }
    }
}
