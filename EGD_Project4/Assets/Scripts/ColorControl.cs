using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
public class ColorControl : MonoBehaviour
{
    private DialogueRunner runner;
    private static int days;
    private static float mood;

    public AudioSource click;
    //private const 
    public void Awake()
    {
        runner = GameObject.FindObjectOfType<DialogueRunner>();
        runner.AddFunction<int>("day_num", GetDayNum);
        runner.AddCommandHandler<float>("change_mood", ChangeMood);
        runner.AddCommandHandler<string, string>("setting", PlaceCharacter);
    }
    public void Start()
    {
    }

    private static int GetDayNum()
    {
        return days;
    }
    private static void ChangeMood(float value)
    {
        mood += value;
    }
    private static void SwitchCharacter()
    {

    }

    private static void SwitchBackground()
    {

    }

    // Put character asset into the right spot on the screen.
    private void PlaceCharacter(string characterName, string markerName)
    {

    }

    private void ChoiceSelected()
    {
        click.Play();
    }
}
