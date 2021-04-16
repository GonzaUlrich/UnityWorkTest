using UnityEngine;
using UnityEngine.UI;

public class CantRock : MonoBehaviour
{
    public Text rockText;
    private int rockCount;

    public void AddRockOnCanvas(int num){
        rockCount+=num;
        rockText.text = rockCount.ToString();
    } 
}
