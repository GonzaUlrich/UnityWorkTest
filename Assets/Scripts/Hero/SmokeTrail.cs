using UnityEngine;

public class SmokeTrail : MonoBehaviour
{
    private string direction;
    private SpriteRenderer mySpriteRenderer;
    public Animator animator;
    private Vector3 actualPos;
    [Range(0f,1f)][SerializeField] public float rightDistance; 
    [Range(-1f,0f)][SerializeField] public float leftDistance;

    void Start(){
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        mySpriteRenderer.enabled = false;
        actualPos = this.transform.localPosition;
    }

    public void PlayAnimation(string _direction){
        
        if(direction!=_direction){
            
            direction=_direction;
            if(direction=="right"){
                StartAnimation();
                mySpriteRenderer.flipX=false;
                transform.localPosition = new Vector3(leftDistance, actualPos.y, actualPos.z);
                animator.Play("SmokeTrail");
            }
            if(direction=="left"){
                StartAnimation();
                mySpriteRenderer.flipX=true;
                transform.localPosition = new Vector3(rightDistance, actualPos.y, actualPos.z);
                animator.Play("SmokeTrail");
            }
            
        }
    }

    private void StartAnimation(){
        actualPos = transform.localPosition;
        animator.enabled=true;
        mySpriteRenderer.enabled=true;
    }

    private void EndAnimation(){
        animator.Play("SmokeTrail",-1,0f);
        animator.enabled=false;
        mySpriteRenderer.enabled = false;
    }
}
