using UnityEngine;
using System;

public class Rock : MonoBehaviour
{
    public float verticalVelocity=0; 
    public float horizontalVelocity=0; 
    public float gravity=0;
    public float timeInFloor=1;
    private GameObject floorCol;
    private GameObject metaCol;
    private bool ultimoRebote=false;
    private float timer=0;
    private float anima=0;
    private float _verticalVelocity,_horizontalVelocity;
    private Vector3 start;
    public AnimationCurve curve;
    
    
    void Start(){
       floorCol = GameObject.Find("FloorCollider");
        metaCol = GameObject.Find("MetaCollider");
    }

    void Update(){

        
        
        if(!ultimoRebote){
            _horizontalVelocity = (_horizontalVelocity>0) ?  _horizontalVelocity-=gravity/500 : _horizontalVelocity=0;
            _verticalVelocity-=gravity/100;

            if(transform.position.y<floorCol.transform.position.y){
                _verticalVelocity=0;
                _horizontalVelocity=0;
                timer+=Time.deltaTime;
                gameObject.GetComponentInChildren<RockSprite>().SetRotationVelocity(0);
                if(timer>timeInFloor){
                    timer=0;
                    gameObject.SetActive(false);
            }
        }

        transform.Translate(Time.deltaTime*_horizontalVelocity,0,0,Space.World);
        transform.Translate(0,Time.deltaTime*_verticalVelocity,0,Space.World);
        }
        else{
            anima+=Time.deltaTime;
            Vector3 pos = Vector3.Lerp(start, metaCol.transform.position, anima);
            pos.y += curve.Evaluate(anima);
            transform.position = pos;
            
        }

    }

    public void SetVelocity(float _velocity){ verticalVelocity=_velocity;}

    public void SetGravity(float _gravity){ gravity=_gravity;}

    public void SetUltimoRebote(){ultimoRebote=false;}

    public void SetReboteVertical(float _reboteVertical){
        if(transform.position.x > metaCol.transform.position.x){
            ultimoRebote=true;
            start = transform.position;
        }

        _verticalVelocity=verticalVelocity;
        _verticalVelocity*=_reboteVertical;
    }
    public void SetReboteHorizontal(float _reboteHorizontal){
        if(transform.position.x > metaCol.transform.position.x){
            ultimoRebote=true;
            start = transform.position;
        }
        _horizontalVelocity=horizontalVelocity;
        _horizontalVelocity*=_reboteHorizontal;
    }

    public void SetAngle(float velocity, float angle){

        verticalVelocity=velocity;
        horizontalVelocity=velocity;
        if(angle>45){
            angle = ((angle-90)*-1)/45;
            horizontalVelocity *= angle;
        }
        else if(angle<45){
            angle = angle/45;
            verticalVelocity*=angle;
        }
        _verticalVelocity=verticalVelocity;
        _horizontalVelocity=horizontalVelocity;

    }

    public static Vector3 Parabola(Vector3 start, Vector3 end, float height, float t)
    {
        Func<float, float> f = x => -4 * height * x * x + 4 * height * x;

       var mid = Vector3.Lerp(start, end, t);

       return new Vector3(mid.x, f(t) + Mathf.Lerp(start.y, end.y, t), mid.z);
   }
}


//Funcion de parabola 
/*void Update()
    {
       
    }*/

