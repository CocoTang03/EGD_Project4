using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
public class ColorControl : MonoBehaviour
{
    private DialogueRunner runner;
    private static int days;
    private static float mood;
    //private const 

    public void Start()
    {
        runner = GameObject.FindObjectOfType<DialogueRunner>();
        runner.AddFunction<int>("get_day_num", GetDayNum);
    }

    private static int GetDayNum()
    {
        return days;
    }

    [YarnCommand("whatever")]
    public void testPrint()
    {
        Debug.Log("This function get used");
    }
}
