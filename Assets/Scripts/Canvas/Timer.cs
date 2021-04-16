using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public float time;
    public float warning;
    public Text timerText;
    public GameObject endGamePopUp, hero;
    [Range(0,1f)][SerializeField] public float growSize, growMax, growMin;
    private bool grow=false;

    void Update()
    {
        if(time>0)
            time -= Time.deltaTime;
        else{
            time=0;
            hero.GetComponent<HeroController>().enabled=false;
            hero.GetComponent<Animator>().enabled=false;
            endGamePopUp.SetActive(true);
        }
            
        
        DisplayTime(time);
    }

    void DisplayTime(float timeToDisplay){
        
        float seconds = Mathf.FloorToInt(timeToDisplay);
        if(seconds<warning && seconds!=0){
            timerText.color= Color.red;
            if(growMax>transform.localScale.x && grow){
                transform.localScale += new Vector3(growSize,growSize,0) * Time.deltaTime;
                if(growMax<transform.localScale.x)
                    grow=false;
            }
            if(growMin<transform.localScale.x && !grow){
                transform.localScale -= new Vector3(growSize,growSize,0) * Time.deltaTime;
                if(growMin>transform.localScale.x)
                    grow=true;
            }
        }
        timerText.text = string.Format("{0:00}", seconds);
    }
}
