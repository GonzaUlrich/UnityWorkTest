using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSprite : MonoBehaviour
{
    public float rotationVelocity;

    void Update()
    {
        transform.Rotate(Vector3.forward * rotationVelocity * Time.deltaTime);
    }

    public void SetRotationVelocity(float _rotationVelocity){
        rotationVelocity=_rotationVelocity;
    }

    
}
