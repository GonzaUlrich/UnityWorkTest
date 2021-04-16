using System.Collections.Generic;
using UnityEngine;

public class Trower : MonoBehaviour{

    public float maxAngle,minAngle,spawnRockMax,spawnRockMin,velocityRock,gravityRock,rotationVelocityRock;
    public GameObject rock;
    public GameObject hand;
    public Animator animator;
    private List<GameObject> pooledObjects;
    private GameObject rockpool;
    private int amountToPool=3;
    private float timer,rand,angle;

    void Start(){
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++) {
            GameObject obj = (GameObject)Instantiate(rock);
            obj.SetActive(false); 
            pooledObjects.Add(obj);
        }
        rand=Random.Range(spawnRockMin,spawnRockMax);
        
    }

    void Update()
    {
        
        timer+=Time.deltaTime;
        if(timer>rand){
            animator.SetBool("throw", true);
            rand=Random.Range(spawnRockMin,spawnRockMax);
            angle=Random.Range(minAngle,maxAngle);
            

            
            timer=0;
        }
    }

    private void ThrowAnimation(){
        rockpool = GetPooledObject();
        Quaternion rotacion= Quaternion.Euler(0,0,0);
            if(rockpool!=null){
                rockpool.transform.position = hand.transform.position;
                SetStart(rockpool);
                rockpool.SetActive(true);
                
            }
            else{
                rockpool= Instantiate(rock, hand.transform.position, rotacion);
                SetStart(rockpool);
                pooledObjects.Add(rockpool);
                
            }
    }

    public GameObject GetPooledObject(){
        for (int i = 0; i < pooledObjects.Count; i++) {
            if (!pooledObjects[i].activeInHierarchy) {
                return pooledObjects[i];
            }
        }
        return null;
    }

    private void SetStart(GameObject obj){
        obj.GetComponent<Rock>().SetAngle(velocityRock,angle);
        obj.GetComponent<Rock>().SetGravity(gravityRock);
        obj.GetComponentInChildren<RockSprite>().SetRotationVelocity(rotationVelocityRock);
    }

    private void CancelAnimation(){
        
        animator.SetBool("throw", false);
    }
}
