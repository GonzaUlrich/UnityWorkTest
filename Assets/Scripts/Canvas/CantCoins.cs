using UnityEngine;
using UnityEngine.UI;

public class CantCoins : MonoBehaviour
{
    public Text coinText;
    private int coinCount;

    public void AddCoinOnCanvas(int num){
        coinCount+=num;
        coinText.text = coinCount.ToString();
    } 
}
