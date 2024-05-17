using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
[System.Serializable]
public class UserData{
    public Player player;
    public Error error;
}
[System.Serializable]
public class Error{
    public string message;
    public bool isError;
}
[System.Serializable] // СЕРІАЛІЗАЦІЯ КЛАСІВ 
public class Player{
    public string nickname;

    public Player()
    {
    }

    public Player(string nickname){
        this.nickname = nickname;
    }
    
    public void SetNickname(string nickname){
        this.nickname = nickname;
    }
    public string GetNickname(){
        return nickname;
    }
}
public class WebManager : MonoBehaviour
{
    public UserData userData = new UserData();
    [SerializeField] private string targetURL;
    public static string GetUserData(UserData data){
        return JsonUtility.ToJson(data);
    }

    public static UserData SetUserData(string infoData){
        return JsonUtility.FromJson<UserData>(infoData); 
    } 
    private void Start() {
        userData.error = new Error(){message = "None", isError = true};
        userData.player = new Player("Name");

    }
     
    public void Login(string login, string password){
        StopAllCoroutines();
        Logging(login, password);
    }
    public void Registration(string login, string password1, string password2){
        StopAllCoroutines();
        Registering(login, password1, password2);
    }

    public void Logging(string login, string password){
        WWWForm form = new WWWForm();
        form.AddField("type", "logging");
        form.AddField("login", login);
        form.AddField("password", password);
        StartCoroutine(SendData(form, "logging"));
       
    }
    public void Registering(string login, string password1, string password2){
        WWWForm form = new WWWForm();
        form.AddField("type", "register");
        form.AddField("login", login);
        form.AddField("password1", password1);
        form.AddField("password2", password2);
        StartCoroutine(SendData(form, "register"));
       
    }
    IEnumerator SendData(WWWForm form, string typeForm){
         using(UnityWebRequest www = UnityWebRequest.Post(targetURL, form)){
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);    
            }else{

            userData = SetUserData(www.downloadHandler.text);
            Debug.Log(www.downloadHandler.text);

          

            }
        }
    }
}
