using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FpsCounter : MonoBehaviour {

    private int avFpsCount = 60;
    private List<float> avFps = new List<float>();

    private void OnGUI() {
        float fps = (1f / Time.deltaTime);
        
        string info = "Cur fps: " + fps;
        info += "\nAv fps:" + GetAvFPS(fps);

        GUI.Box(new Rect(5,5, 125, 40), info);

    }

    private float GetAvFPS(float currentFps) {
        avFps.Add(currentFps);
        if (avFps.Count > avFpsCount)
            avFps.RemoveAt(0);

        float result = 0f;
        foreach (float av in avFps)
            result += av;

        return result / (float)avFps.Count;
    }
}
