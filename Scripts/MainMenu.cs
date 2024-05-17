using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
   [SerializeField] private WebManager webManager;
    public void PlayGame(){
        Debug.Log(webManager.userData.error.message);
        if(webManager.userData.error.message == "Error: noError"){
         SceneManager.LoadScene("MainScene");
        Debug.Log("GOOD LOGIN");
         }else{
            Debug.Log("ERROR LOGIN");
         }
        
    }
    public void GoToLogin(){
       if(webManager.userData.error.message == "Error: noError"){
         SceneManager.LoadScene("Login");
         }else{
            Debug.Log("Error register");
         }
    }
   
     public void GoToLogins(){
         SceneManager.LoadScene("Login"); 
    }
    public void GoToLoginNoCheck(){
       if(webManager.userData.error.message == "Error: noError"){
         SceneManager.LoadScene("Login");
         }else{
            Debug.Log("Error register");
         }
    }
    public void GoToMenu(){
        SceneManager.LoadScene("Menu");
    }
    public void GoToRegist(){
        SceneManager.LoadScene("Registration");
    }
    
    public void ExitGame(){
        Debug.Log("Quit Game");
        Application.Quit();
    }
    
   
}
