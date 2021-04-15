using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform hero;
    public Vector3 offset;
    public Vector3 minValue, maxValue;
    [Range(0,10f)][SerializeField]public float smooth;

    void LateUpdate(){
        Vector3 boundPos = new Vector3(
            Mathf.Clamp(hero.position.x,minValue.x,maxValue.x),
            Mathf.Clamp(hero.position.y,minValue.y,maxValue.y),
            Mathf.Clamp(hero.position.z,minValue.z,maxValue.z));
        Vector3 smoothPos = Vector3.Lerp(transform.position, boundPos,smooth*Time.deltaTime);
        transform.position =  smoothPos;
    }

}
