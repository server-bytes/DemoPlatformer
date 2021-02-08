using ServerBytes.Plugins.Authentication.Abstractions;
using ServerBytes.Plugins.Authentication.Client;
using UnityEngine;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{
    public InputField usernameText;
    public InputField passwordText;
    public Text textDisplayName;
    public static IAuthenticationService AuthService;

    public async void Login()
    {
        Debug.Log($"test: {usernameText.text} | {passwordText.text}");
        Debug.Log($"Dsiaplyname: {textDisplayName.text}");

        var result = await AuthService.AuthenticateWithUsernamePasswordAsync(
                     new AuthenticateWithUsernamePasswordLoginRequest
                     {
                         Operation = AuthenticateOperation.LoginOrRegister,
                         Username = usernameText.text,
                         Password = passwordText.text,
                         DisplayName = usernameText.text
                     });
    }
}
