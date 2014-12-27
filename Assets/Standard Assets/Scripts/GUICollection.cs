using UnityEngine;
using System;
using System.Collections.Generic;

public class GUICollection : MonoBehaviour {

    public static GUIStyle TextStyle;
    public static GUIStyle ButtonStyle;
    public static GUISkin KarlSkin;

    void Start()
    {
        GUICollection.ButtonStyle = new GUIStyle();
        GUICollection.ButtonStyle.font = Resources.Load<Font>("FORTE");
        GUICollection.ButtonStyle.normal.textColor = Color.white;
        GUICollection.ButtonStyle.onActive.textColor = Color.yellow;
        GUICollection.ButtonStyle.wordWrap = true;
        GUICollection.ButtonStyle.fontSize = 20;
        GUICollection.ButtonStyle.border = new RectOffset(2, 2, 2, 2);

        GUICollection.TextStyle = new GUIStyle();
        GUICollection.TextStyle.font = GUICollection.ButtonStyle.font;
        GUICollection.TextStyle.normal.textColor = Color.white;
        GUICollection.TextStyle.wordWrap = true;
        GUICollection.TextStyle.fontSize = 24;

        
        
    }


    public static void SpeakerBox(Texture speaker, string speakerKey, string speach)
    {
        float texturePadding = 5.0f;

        //draw the container box
        float width = Screen.width * (.5f);
        float height = Screen.height * (.2f);
        Rect speakerBox = new Rect((Screen.width / 2) - (width / 2) - 30, Screen.height - (height + texturePadding), width, height);
        GUI.Box(speakerBox, "");

        //draw the character's image
        float textureSize = height - texturePadding;
        Rect textureLocation = new Rect(speakerBox.xMin + texturePadding, speakerBox.yMin + (texturePadding/2), textureSize, textureSize);
        GUI.Label(textureLocation, speaker);

        //draw the character's text
        Rect speachLocation = new Rect(speakerBox.xMin + textureSize + (texturePadding*2),
            speakerBox.yMin + texturePadding,
            width - (textureSize + (texturePadding * 3)),
            height - (texturePadding * 2));
        GUI.Label(speachLocation, speach, GUICollection.TextStyle);
    }

    public static void ChoiceBox(string choiceDecision, List<Tuple<string, Action>> choices)
    {
        float padding = 5.0f;

        //draw the container box
        float width = Screen.width * (.5f);
        float height = Screen.height * (.5f);
        Rect containerBox = new Rect((Screen.width / 2) - (width / 2), (padding * 2), width, height);
        GUI.Box(containerBox, "");

        Rect choiceLocation = new Rect(containerBox.xMin + padding, containerBox.yMin + padding, width - (padding * 2), (height - (padding * 2)) / 2);
        GUI.Label(choiceLocation, choiceDecision, GUICollection.TextStyle);

        float currentYOffset = 60f;
        Rect currentChoiceLocation = new Rect(choiceLocation.xMin + padding + (choiceLocation.width / 2), choiceLocation.yMin + currentYOffset + padding, (width - (padding * 2)) / 2, height * .1f);

        foreach (Tuple<string, Action> choice in choices)
        {
            if(GUI.Button(currentChoiceLocation, choice.item1, GUICollection.ButtonStyle))
            {
                choice.item2();
            }
            currentChoiceLocation.Set(currentChoiceLocation.xMin, currentChoiceLocation.yMin + currentYOffset, currentChoiceLocation.width, currentChoiceLocation.height);
        }

    }

}

public class SpeakerGuiWrapper
{
    public float duration;
    private Texture speaker;
    private string speach;
    private string speakerKey;

    public SpeakerGuiWrapper(Texture speakerTexture, string speakerKey, string speach, float duration)
    {
        this.duration = duration;
        this.speaker = speakerTexture;
        this.speach = speach;
        this.speakerKey = speakerKey;
    }

    public void drawOnGUI()
    {
        GUICollection.SpeakerBox(this.speaker, this.speakerKey, this.speach);
    }
}

public class ChoiceBoxWrapper
{
    private string choice;
    private List<Tuple<string, Action>> choices;

    public ChoiceBoxWrapper(string choice, List<Tuple<string, Action>> choices)
    {
        this.choice = choice;
        this.choices = choices;
    }

    public void drawOnGUI()
    {
        GUICollection.ChoiceBox(this.choice, this.choices);
    }
}


