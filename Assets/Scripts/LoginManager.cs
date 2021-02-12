using ServerBytes.Plugins.Authentication.Abstractions;
using ServerBytes.Plugins.Authentication.Client;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{
    public InputField username;
    public InputField password;
    public static IAuthenticationService AuthenticationService;

    public async void Login()
    {
        var result = await AuthenticationService.AuthenticateWithUsernamePasswordAsync(
            new AuthenticateWithUsernamePasswordLoginRequest
            {
                Username = username.text,
                Password = password.text,
                DisplayName = username.text,
                Operation = AuthenticateOperation.LoginOrRegister
            });

        if (result.IsSuccessful)
        {
            Debug.Log($"User id: {result.Data.User.Id}");
        }
        else
        {
            Debug.Log($"Failed to login: {result.Message}");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
