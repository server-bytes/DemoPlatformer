using ServerBytes.Client;
using ServerBytes.Client.Abstractions;
using ServerBytes.Plugins.Authentication.Client;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerBytesManager : MonoBehaviour
{
    public string appKey;
    public static IClient Client { get; private set; }
    public static AuthenticationServiceFactory AuthFactory { get; private set; }

    void Awake()
    {
        if (Client != null)
        {
            return;
        }

        var pluginHost = ClientFactory.GetPluginHost(appKey, "development");
        AuthFactory = new AuthenticationServiceFactory(pluginHost);

        Client = UnityClientFactory.GetClient(pluginHost);

        Client.OnConnected += Client_OnConnected;
        Client.OnFailedToConnect += Client_OnFailedToConnect;
        Client.OnDisconnected += Client_OnDisconnected;
        Client.Connect();
    }

    private void Client_OnDisconnected(string errorMessage)
    {
        Debug.Log("Disconnected: " + errorMessage);
    }

    private void Client_OnFailedToConnect(string errorMessage)
    {
        Debug.Log("OnFailedToConnect: " + errorMessage);
    }

    private void Client_OnConnected()
    {
        Debug.Log("Connected");
        LoginManager.AuthenticationService = AuthFactory.Create(Client);
    }
}