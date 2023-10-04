using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using Yarn.Unity;
public class VariableControl : MonoBehaviour
{
    private DialogueRunner runner;
    private static int days;
    private static float mood;

    private static Dictionary<string, bool> options;
    private const int taskMax = 3;
    private static int taskDone = 0;
    //public AudioSource[] audioSources;
    //private const 
    public void Awake()
    {
        options = new Dictionary<string, bool>();
        options.Add( "work", false );
        options.Add( "cook", false );
        options.Add("selfCare", false);
        options.Add("laundry", false);
        options.Add("dishWash", false);
        options.Add("callParents", false);
        options.Add("cleanOutFridge", false);
        options.Add("jobHunt", false);
        options.Add("keepWork", false);
        options.Add("bedroom", false);
        options.Add("dinnerFamily", false);
        Debug.Log("Scripts start");

        runner = GameObject.FindObjectOfType<DialogueRunner>();
        runner.AddFunction<int>("getDayNum", GetDayNum);
        runner.AddCommandHandler<int>("setDayNum", SetDayNum);
        runner.AddFunction<float>("getMood", GetMood);
        // Use: <<setMood 0.1>> ->the float could be negative
        runner.AddCommandHandler<float>("setMood", SetMood);
        runner.AddFunction<string, bool>("getValue", GetValue);
        runner.AddCommandHandler<string, bool>("setValue", SetValue);
        runner.AddCommandHandler<bool>("reset", Reset);
        runner.AddFunction<int>("getTasksDone", GetTasksDone);
        runner.AddCommandHandler<int>("addTasks", AddTasks);
        // Background Loading -> Example: <<setBackground family>>
        runner.AddCommandHandler<string>("setBackground", SwitchBackground);
        // Sound Effect -> Example: <<sfxPlay "Click>>
        runner.AddCommandHandler<string>("sfxPlay", SFXPlay);
    }
    public void Start()
    {
        Sprite abs = Resources.Load<Sprite>("abstract");
        Sprite family = Resources.Load<Sprite>("family_base");
        Sprite house = Resources.Load<Sprite>("house_base");
        Sprite moving = Resources.Load<Sprite>("movingforwards_base");
        Sprite office = Resources.Load<Sprite>("office_base");
        Sprite school = Resources.Load<Sprite>("school_base");
        //audioSources = Resources.LoadAll<AudioSource>("Lying Flat SFX");
        SwitchBackground("abstract");
    }

    private static int GetTasksDone() { return taskDone; }
    private static void AddTasks(int value) { taskDone+=value; }
    private static int GetDayNum(){ return days; }
    private static void SetDayNum(int value) { days+=value; }
    private static float GetMood() { return mood; }
    private static void SetMood(float value){ mood += value; }
    private static bool GetValue(string key) { return options[key]; }
    private static void SetValue(string key, bool value) { options[key] = value; }
    private static void Reset(bool value)
    {
        List<string> list = options.Keys.ToList();
        for(int i = 0; i < list.Count; i++)
        {
            options[list[i]] = value;
        }
        taskDone = 0;
    }
    // To Do: create a sprite called "Background"
    private void SwitchBackground(string name)
    {
        Debug.Log(name);
        Sprite sprite = Resources.Load<Sprite>(name);
        Debug.Log(sprite);
        GameObject.Find("Background").GetComponent<Image>().sprite = sprite;
        Debug.Log(sprite);
    }
    private void SFXPlay(string name)
    {
        AudioSource source = GetComponent<AudioSource>();
        AudioClip clip = Resources.Load<AudioClip>(name);
        GetComponent<AudioSource>().clip = clip;
        source.Play();
    }
}
