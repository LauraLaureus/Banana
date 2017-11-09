using Azure.AppServices;
using RESTClient;
using UnityEngine;
using System;
using System.Net;
using System.Collections.Generic;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
using System.Linq;

public class AppServices : MonoBehaviour
{
    /// <remarks>
    /// Enter your Azure App Service url
    /// </remarks>

    [Header("Azure App Service")]
    // Azure Mobile App connection strings
    [SerializeField]
    private string _appUrl = "PASTE_YOUR_APP_URL";

    [Header("User Authentication")]
    // Client-side login requires auth token from identity provider.
    // NB: Remember to update Azure App Service authentication provider with your app key and secret and SAVE changes!

    // Facebook - go to https://developers.facebook.com/tools/accesstoken/ to generate a "User Token".
    [Header("Facebook")]
    [SerializeField]
    private string _facebookUserToken = "";

    // Twitter auth - go to https://apps.twitter.com/ and select "Keys and Access Tokens" to generate a access "Access Token" and "Access Token Secret".
    [Header("Twitter")]
    [SerializeField]
    private string _twitterAccessToken = "";
    [SerializeField]
    private string _twitterTokenSecret = "";

    // App Service Rest Client
    private AppServiceClient _client;

    // App Service Table defined using a DataModel
    private AppServiceTable<HighScoreData> _table;

    // List of HighScoreScripts (leaderboard)
    private List<HighScoreData> _scores = new List<HighScoreData>();

      
    // Use this for initialization
    void Start()
    {
        // Create App Service client
        _client = new AppServiceClient(_appUrl);

        // Get App Service 'HighScoreScripts' table
        _table = _client.GetTable<HighScoreData>("Banana_HighScores");

    }

    

    public void Login()
    {
        if (!string.IsNullOrEmpty(_facebookUserToken))
        {
            StartCoroutine(_client.LoginWithFacebook(_facebookUserToken, OnLoginCompleted));
            return;
        }
        if (!string.IsNullOrEmpty(_twitterAccessToken) && !string.IsNullOrEmpty(_twitterTokenSecret))
        {
            StartCoroutine(_client.LoginWithTwitter(_twitterAccessToken, _twitterTokenSecret, OnLoginCompleted));
            return;
        }
        Debug.LogWarning("Login requires Facebook or Twitter access tokens");
    }

    private void OnLoginCompleted(IRestResponse<AuthenticatedUser> response)
    {
        Debug.Log("OnLoginCompleted: " + response.Content + " Url:" + response.Url);

        if (!response.IsError && response.StatusCode == HttpStatusCode.OK)
        {
            Debug.Log("Authorized UserId: " + _client.User.user.userId);
        }
        else
        {
            Debug.LogWarning("Authorization Error: " + response.StatusCode);
           
        }
    }

    public void InsertScore()
    {
        HighScoreData score = new HighScoreData { score =FindObjectOfType<ScoreCounter>().score, player = "test player"};
        
        StartCoroutine(_table.Insert<HighScoreData>(score, OnInsertCompleted));
    }

    private void OnInsertCompleted(IRestResponse<HighScoreData> response)
    {
        if (!response.IsError && response.StatusCode == HttpStatusCode.Created)
        {
            Debug.Log("OnInsertItemCompleted: " + response.Content + " status code:" + response.StatusCode + " data:" + response.Data);
            HighScoreData item = response.Data; // if successful the item will have an 'id' property value
        }
        else
        {
            Debug.LogWarning("Insert Error Status:" + response.StatusCode + " Url: " + response.Url);
        }
    }


    public void UpdateScore()
    {
        HighScoreData score = new HighScoreData { score = FindObjectOfType<ScoreCounter>().score, player = "test player" };
        StartCoroutine(_table.Update<HighScoreData>(score, OnUpdateScoreCompleted));
    }

    private void OnUpdateScoreCompleted(IRestResponse<HighScoreData> response)
    {
        if (!response.IsError)
        {
            Debug.Log("OnUpdateItemCompleted: " + response.Content);
        }
        else
        {
            Debug.LogWarning("Update Error Status:" + response.StatusCode + " " + response.ErrorMessage + " Url: " + response.Url);
        }
    }

    

    public void Read()
    {
        StartCoroutine(_table.Read<HighScoreData>(OnReadCompleted));
    }

    private void OnReadCompleted(IRestResponse<HighScoreData[]> response)
    {
        for (int i = 0; i < response.Data.Length; i++)
        {
            Debug.Log(response.Data[i].ToString());
        }
    }


    public void Delete()
    {
        HighScoreData score = new HighScoreData { score = FindObjectOfType<ScoreCounter>().score, player = "test player" };
        StartCoroutine(_table.Delete<HighScoreData>(score.id, OnDeleteCompleted));
    }

    private void OnDeleteCompleted(IRestResponse<HighScoreData> response)
    {
        if (!response.IsError)
        {
            Debug.Log("OnDeleteItemCompleted");
        }
        else
        {
            Debug.LogWarning("Delete Error Status:" + response.StatusCode + " " + response.ErrorMessage + " Url: " + response.Url);
        }
    }


    
}
