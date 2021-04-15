using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    
    private float growSize=0;
    private float rotationVelocity=0;
    private float vanishTime=0;
    private float timer=0;
    private bool start=false;

    void Start()
    {
        transform.localScale = new Vector3(0,0,0);
    }

    void Update()
    {
        if(transform.localScale.x < 1 && !start){
            transform.localScale += new Vector3(growSize,growSize,0) * Time.deltaTime;
            if(transform.localScale.x >= 1)
                start=true;
        }
        
        if(start){
            timer+=Time.deltaTime;
            if(timer>vanishTime){
                transform.localScale -= new Vector3(growSize,growSize,0) * Time.deltaTime;
                if(transform.localScale.x < 0){
                    Destroy(this.gameObject);
                }
            }
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
            
            Destroy(this.gameObject);
        }
    }
    public void SetVanishTime(float _vanishTime){
        vanishTime=_vanishTime;
    }

}
