using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    public static Vector3 lastPlayerLocation;
    public static Quaternion lastPlayerRotation;
    public static Vector3 lastCamLocation;

    public static bool dialogueActive;

    public static int battleWinState;
    // 0 = No battle yet
    // 1 = Player Win
    // 2 = Enemy Win
}
