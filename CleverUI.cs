using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CleverUI : MonoBehaviour
{
    [SerializeField] private Sprite[] spritesClever;
    [SerializeField] private ParticleSystem pickUpEffect;



    [SerializeField] private Image bg;
    [SerializeField] private Image fill;


    public void UpdateCleverUI(int indexSprite)
    {
        bg.sprite = spritesClever[indexSprite];
        fill.sprite = spritesClever[indexSprite];
    }


    public void UpdateCleverFill(float _fill)
    {
        fill.fillAmount = _fill;
        pickUpEffect.Play();
    }

    


}
