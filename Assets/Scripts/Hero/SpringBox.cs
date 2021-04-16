using UnityEngine;

public class SpringBox : MonoBehaviour
{
    [Range(0,2f)][SerializeField]public float reboteVertical;
    [Range(0,2f)][SerializeField]public float reboteHorizontal;

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "RockTag"){
            col.GetComponent<Rock>().SetReboteVertical(reboteVertical);
            col.GetComponent<Rock>().SetReboteHorizontal(reboteHorizontal);
        }
    }
}
