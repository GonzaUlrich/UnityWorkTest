using UnityEngine;
using UnityEngine.UI;
 using UnityEngine.SceneManagement;

public class EndGamePopUp : MonoBehaviour
{ 
    
    void Awake() {
        Scene scene =  SceneManager.GetActiveScene();
        if(scene.name!="Menu")
            gameObject.SetActive(false);    
    }

    public void EasyModeButton(){
        SceneManager.LoadScene("EasyMode");
    }

    public void HardModeButton(){
        SceneManager.LoadScene("HardMode");
    }

    public void RestartButton(){
        Scene scene =  SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void MenuButton(){
        SceneManager.LoadScene("Menu");
    }

    public void ExitButton(){
         Application.Quit();
    }
}
