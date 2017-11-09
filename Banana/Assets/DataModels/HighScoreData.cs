using Azure.AppServices;
using System;

[Serializable]
public class HighScoreData : DataModel {
    public string player;
    public float score;
}
