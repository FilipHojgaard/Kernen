using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sfx_manager_script : MonoBehaviour
{
    public AudioSource genericButton_sfx;
    public AudioSource buy_shield_sfx;
    public AudioSource buy_speed_sfx;
    public AudioSource buy_level_sfx;
    public AudioSource buy_ability_sfx;

    public AudioSource ambient_music;


    public void play_generic_button_sfx() {
        genericButton_sfx.Play();
    }

    public void play_shield_buy_sfx() {
        buy_shield_sfx.Play();
    }

    public void play_speed_buy_sfx() {
        buy_speed_sfx.Play();
    }

    public void play_level_buy_sfx() {
        buy_level_sfx.Play();
    }

    public void play_ability_buy_sfx() {
        buy_ability_sfx.Play();
    }

    public void play_ambient_music() {
        ambient_music.Play();
    }

    public void stop_ambient_music() {
        ambient_music.Stop();
    }
}
