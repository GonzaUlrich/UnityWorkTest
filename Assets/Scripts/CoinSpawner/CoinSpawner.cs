using UnityEngine;
using UnityEngine.UI;

public class CoinSpawner : MonoBehaviour
{
    public GameObject hero;
    public GameObject coin;
    [Range(0,1f)][SerializeField]private float growSize=0;
    [Range(0,1000f)][SerializeField]private float rotationVelocity=0;
    public float rangeNonSpawn, minMapSpawn, maxMapSpawn, yPos, vanishTime;
    public int cantRocksOnMetaToSpawn;
    private int rockOnMeta;
    

    public void SpanwCoin(int _rockOnMeta){
        rockOnMeta+=_rockOnMeta;
        if(rockOnMeta>=cantRocksOnMetaToSpawn){
            float rand = Random.Range(minMapSpawn,maxMapSpawn);
            while(rand>hero.transform.position.x - rangeNonSpawn && rand< hero.transform.position.x + rangeNonSpawn){
                rand = Random.Range(minMapSpawn,maxMapSpawn);
            }
            Vector3 coinPos= new Vector3(rand,yPos,0);
            GameObject obj= Instantiate(coin, coinPos, Quaternion.identity);
            obj.GetComponent<Coin>().SetGrowSize(growSize);
            obj.GetComponent<Coin>().SetRotationVelocity(rotationVelocity);
            obj.GetComponent<Coin>().SetVanishTime(vanishTime);
            
            rockOnMeta=0;
        }
    } 
}
