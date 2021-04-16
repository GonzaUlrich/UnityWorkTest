using UnityEngine;

public class HeroController : MonoBehaviour
{
    public GameObject smokeTrail;
    [Range(0,1f)][SerializeField]public float maxSpeed;
    [Range(0,1f)][SerializeField]private float acelerationRate=0;
    [Range(0,1f)][SerializeField]private float decelerationRate=0;
    public Animator animator;
    public float xMinDistance,xMaxDistance;
    private SpriteRenderer mySpriteRenderer;
    private float currentVelocity;
    private bool buttonLeft=false;
    private bool buttonRight=false;

    void Start(){
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update(){

        if(Input.GetKey("right") || buttonRight){
            mySpriteRenderer.flipX=false;
            smokeTrail.GetComponent<SmokeTrail>().PlayAnimation("right");
            animator.SetBool("quiet", false);
            if(transform.position.x<xMaxDistance){
                currentVelocity = currentVelocity +  acelerationRate * Time.deltaTime / 2;
            }
            else{
                currentVelocity=0;
            }
            if(currentVelocity > maxSpeed){
                currentVelocity=maxSpeed;
            }
        }
        else if(Input.GetKey("left") || buttonLeft){
            
            mySpriteRenderer.flipX=true;
            smokeTrail.GetComponent<SmokeTrail>().PlayAnimation("left");
            animator.SetBool("quiet", false);
            if(transform.position.x>xMinDistance){
                currentVelocity = currentVelocity -  acelerationRate * Time.deltaTime / 2;
            }
            else{
                currentVelocity=0;
            }
            if(currentVelocity < (maxSpeed*-1)){
                currentVelocity=maxSpeed*-1;
            }
        }
        else if(currentVelocity!=0){
            if(currentVelocity>0){
                currentVelocity = currentVelocity -  decelerationRate * Time.deltaTime;
                if(currentVelocity<0)
                    currentVelocity=0;
            }
            if(currentVelocity<0){
                currentVelocity = currentVelocity +  decelerationRate * Time.deltaTime;
                if(currentVelocity>0)
                    currentVelocity=0;
            }
        }
        if(Input.GetKeyUp("left"))
            smokeTrail.GetComponent<SmokeTrail>().PlayAnimation("stop");
        if(Input.GetKeyUp("right"))
            smokeTrail.GetComponent<SmokeTrail>().PlayAnimation("stop");
        if(currentVelocity==0)
            animator.SetBool("quiet", true);
    
            transform.Translate(currentVelocity,0,0);

    }

    public void GoLeftButtonDown(){
        buttonLeft = true;
    }
    public void GoLeftButtonUp(){
        buttonLeft = false;
    }
    public void GoRightButtonDown(){
        buttonRight = true;
    }
    public void GoRightButtonUp(){
        buttonRight = false;
    }

}

/*
 if(Input.GetKey("left") || Input.GetKey("A")){
            //if(useInercia){move = (speed>move) ? move=speed : move+=}
             
        }
        else if(Input.GetKey("right") || Input.GetKey("D")){
            
        }
        else if(true){
            
        }*/