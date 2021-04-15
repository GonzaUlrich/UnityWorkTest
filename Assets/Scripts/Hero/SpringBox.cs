using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringBox : MonoBehaviour
{
    public float reboteVertical;
    public float reboteHorizontal;


    void Start(){
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "RockTag"){
            col.GetComponent<Rock>().SetReboteVertical(reboteVertical);
            col.GetComponent<Rock>().SetReboteHorizontal(reboteHorizontal);
        }
    }
}
