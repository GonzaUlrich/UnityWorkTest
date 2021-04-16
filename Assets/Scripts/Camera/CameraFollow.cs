using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform hero;
    public Vector3 minValue, maxValue;
    public GameObject leftBounce,rightBounce;
    private Vector3 maxRight,maxLeft;
    [Range(0,10f)][SerializeField]public float smooth;

    void Start() {
        //Se resta la mitad del ancho de la camara a la pocicion de los bounces para tener el tope de posicion de camara 
        Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0));
        float widthSide = stageDimensions.x - transform.position.x; 
        maxRight = new Vector3(rightBounce.transform.position.x - widthSide,transform.position.y,transform.position.z);
        maxLeft = new Vector3(leftBounce.transform.position.x + widthSide,transform.position.y,transform.position.z);
    }

    void LateUpdate(){
        
        Vector3 boundPos = new Vector3(
            Mathf.Clamp(hero.position.x,maxLeft.x,maxRight.x),
            Mathf.Clamp(hero.position.y,minValue.y,maxValue.y),
            Mathf.Clamp(hero.position.z,minValue.z,maxValue.z));
            Vector3 smoothPos = Vector3.Lerp(transform.position, boundPos,smooth*Time.deltaTime);
            transform.position =  smoothPos;
    }

}
