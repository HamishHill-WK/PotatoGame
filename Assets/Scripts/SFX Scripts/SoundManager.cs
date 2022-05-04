using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{

    public static AudioClip ButtonSnd, PlantSnd, ShovelSnd, WateringSnd, SparkleOneSnd, SparkleTwoSnd;
    static AudioSource audioScr;
        
    // Start is called before the first frame update
    void Start()
    {
        ButtonSnd = Resources.Load<AudioClip>("ButtonTap");
        PlantSnd = Resources.Load<AudioClip>("Plant");
        ShovelSnd = Resources.Load<AudioClip>("Shovel");
        WateringSnd = Resources.Load<AudioClip>("Watering");
        SparkleOneSnd = Resources.Load<AudioClip>("Sparkle");
        SparkleTwoSnd = Resources.Load<AudioClip>("Sparkle2");

        audioScr = GetComponent<AudioSource>();
    }


    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "ButtonTap":
                audioScr.PlayOneShot(ButtonSnd);
                break;
            case "Plant":
                audioScr.PlayOneShot(PlantSnd);
                break;
            case "Shovel":
                audioScr.PlayOneShot(ShovelSnd);
                break;
            case "Watering":
                audioScr.PlayOneShot(WateringSnd);
                break;
            case "Sparkle":
                audioScr.PlayOneShot(SparkleOneSnd);
                break;
            case "Sparkle2":
                audioScr.PlayOneShot(SparkleTwoSnd);
                break;
        }
    }
}
