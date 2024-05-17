using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallMenu : MonoBehaviour
{

    [System.Serializable]
    public class MenuLogin
    {
        public Text login, password;
    }
    [System.Serializable]
    public class MenuRegistration
    {
        public Text login, password1, password2;
    }

    public MenuLogin loginWindow;
    public MenuRegistration registrationWindow;
    
    [SerializeField] private WebManager webManager;

    public void Login()
    {
        webManager.Login(loginWindow.login.text, loginWindow.password.text);
    }
     public void Register()
    {
        webManager.Registration(registrationWindow.login.text, registrationWindow.password1.text, registrationWindow.password2.text);

    }
}
