using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
public class ColorControl : MonoBehaviour
{

    [YarnCommand("whatever")]
    public void testPrint()
    {
        Debug.Log("This function get used");
    }
}
