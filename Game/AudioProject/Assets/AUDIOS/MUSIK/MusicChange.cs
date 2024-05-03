using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicChange : MonoBehaviour
{
    public AudioMixerSnapshot HouseSnapshot;
    public AudioMixerSnapshot PathSnapshot;
    public AudioMixerSnapshot CombatSnapshot;
    public AudioMixerSnapshot PartySnapshot;
    public AudioMixerSnapshot BirdsSnapshot;



    public float slowTransitionTime = 2.0f;
    public float fastTransitionTime = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Tension":
                PathSnapshot.TransitionTo(slowTransitionTime);
                break;

            case "Indoor":
                HouseSnapshot.TransitionTo(fastTransitionTime);
                break;

            case "Fight":
                CombatSnapshot.TransitionTo(fastTransitionTime);
                break;

            case "Party":
                PartySnapshot.TransitionTo(fastTransitionTime);
                break;

            case "Birds":
                BirdsSnapshot.TransitionTo(fastTransitionTime);
                break;

            default:
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Tension":
                PathSnapshot.TransitionTo(slowTransitionTime);
                break;

            case "Indoor":
                HouseSnapshot.TransitionTo(slowTransitionTime);
                break;

            case "Fight":
                CombatSnapshot.TransitionTo(slowTransitionTime);
                break;

            case "Party":
                PartySnapshot.TransitionTo(slowTransitionTime);
                break;
            case "Birds":
                BirdsSnapshot.TransitionTo(slowTransitionTime);
                break;

            default:
                break;
        }
    }
}
