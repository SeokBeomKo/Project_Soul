using UnityEngine;
using System.Collections.Generic;

public class WaitForSecondsPool
{
    public static WaitForEndOfFrame nextFrame = new WaitForEndOfFrame();

    private static Dictionary<float, WaitForSeconds> customWaitTimes = new Dictionary<float, WaitForSeconds>
    {
        { 0.1f, new WaitForSeconds(0.1f) },
        { 0.5f, new WaitForSeconds(0.5f) },
        { 1f, new WaitForSeconds(1) },
        { 2f, new WaitForSeconds(2) },
        { 3f, new WaitForSeconds(3) }
    };
    public static WaitForSeconds GetWaitForSeconds(float seconds)
    {
        if (customWaitTimes.TryGetValue(seconds, out WaitForSeconds waitForSeconds))
        {
            return waitForSeconds;
        }
        else
        {
            waitForSeconds = new WaitForSeconds(seconds);
            customWaitTimes.Add(seconds, waitForSeconds);
            return waitForSeconds;
        }
    }
}
