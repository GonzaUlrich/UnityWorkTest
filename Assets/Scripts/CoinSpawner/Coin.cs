using UnityEngine;

public class Coin : MonoBehaviour
{
    
    private float growSize=0;
    private float rotationVelocity=0;
    private float vanishTime=0;
    private float timer=0;
    private bool startCounter=false;
    private bool colected=false;
    private float anima=0;
    private Vector3 start;
    public AnimationCurve curve;
    private GameObject coinCounter;
    private GameObject coinCol;

    void Start()
    {
        coinCounter = GameObject.Find("CantCoins");
        coinCol = GameObject.Find("CoinCol");
        transform.localScale = new Vector3(0,0,0);
    }


    void Update()
    {
        if(transform.localScale.x < 1 && !startCounter){
            transform.localScale += new Vector3(growSize,growSize,0) * Time.deltaTime;
            if(transform.localScale.x >= 1)
                startCounter=true;
        }
        
        if(startCounter){
            timer+=Time.deltaTime;
            if(timer>vanishTime){
                transform.localScale -= new Vector3(growSize,growSize,0) * Time.deltaTime;
                if(transform.localScale.x < 0){
                    Destroy(this.gameObject);
                }
            }
        }
        if(colected){
            startCounter=false;
            anima+=Time.deltaTime;
            Vector3 pos = Vector3.Lerp(start , coinCol.transform.position, anima);
            pos.y += curve.Evaluate(anima);
            transform.position = pos;
        }

        transform.Rotate(Vector3.up * rotationVelocity * Time.deltaTime);
    }

    public void SetGrowSize(float _growSize){
        growSize=_growSize;
    }
    public void SetRotationVelocity(float _rotationVelocity){
        rotationVelocity=_rotationVelocity;
    }
    public void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.name == "Hero"){
            transform.position=new Vector3( transform.position.x ,transform.position.y+15f,0);
            colected=true;
            start=transform.position;
        }
        if(col.gameObject.name == "CoinCol"){
            coinCounter.GetComponent<CantCoins>().AddCoinOnCanvas(1);
            Destroy(this.gameObject);
        }

    }
    public void SetVanishTime(float _vanishTime){
        vanishTime=_vanishTime;
    }


}
