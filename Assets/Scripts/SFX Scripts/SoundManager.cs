using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{

    public static AudioClip ButtonSnd, PlantSnd, ShovelSnd, WateringSnd, SparkleOneSnd, SparkleTwoSnd,
        PeelSnd, BoilSnd, AddSnd, SliceSnd, StirSnd;
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
        PeelSnd = Resources.Load<AudioClip>("Peel");
        BoilSnd = Resources.Load<AudioClip>("Boil");
        AddSnd = Resources.Load<AudioClip>("Add");
        SliceSnd = Resources.Load<AudioClip>("Slice");
        StirSnd = Resources.Load<AudioClip>("Stir");

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
            case "Peel":
                audioScr.PlayOneShot(PeelSnd);
                break;
            case "Boil":
                audioScr.PlayOneShot(BoilSnd);
                break;
            case "Add":
                audioScr.PlayOneShot(AddSnd);
                break;
            case "Slice":
                audioScr.PlayOneShot(SliceSnd);
                break;
            case "Stir":
                audioScr.PlayOneShot(StirSnd);
                break;

        }
    }
}
