using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class micInput : MonoBehaviour
{
    public static int voiceDataLength = 128;
    public float volume;

    private AudioClip sample;
    private string deviceName;

    private const int freq = 44100;
    private const int lengthOfSample = 999;

    public static bool isBreathingIntoMic;
    public bool isBreathing;

    private void Start()
    {
        deviceName = Microphone.devices[0];
        sample = Microphone.Start(deviceName, true, lengthOfSample, freq);
    }

    private void Update()
    {
   
        isBreathing = isBreathingIntoMic;
        volume = GetMaxVol();
        if (volume > 0.1)
            isBreathingIntoMic = true;
        else
            isBreathingIntoMic = false;
    }

    private float GetMaxVol()
    {
        float max = 0f;
        float[] volData = new float[voiceDataLength];
        int offset;
        offset = Microphone.GetPosition(deviceName) - voiceDataLength + 1;

        if (offset < 0)
        {
            return 0f;
        }

        sample.GetData(volData, offset);

        for (int i = 0; i < voiceDataLength; i++)
        {
            float tempVol = volData[i];
            if (tempVol > max)
            {
                max = tempVol;
            }
        }

        return max;
    }
}

//tutorial was from https://www.jianshu.com/p/2e4bd1b90c88
