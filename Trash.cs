using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    [SerializeField] private RubbishType type;
    //[SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float speedFall;
    [SerializeField] private int pointCollect;
    [SerializeField] private ParticleSystem GoodEffect;
    [SerializeField] private ParticleSystem BadEffect;

  



    private Color SetColorEffect(RubbishType _type)
    {
        switch (_type)
        {
            case RubbishType.Organic:
                return Color.black;
               
            case RubbishType.Paper:
                return  Color.blue;
                
            case RubbishType.Plastic:

                return Color.yellow;
                
            case RubbishType.Glass:
                return Color.green;
            default:
                return Color.clear;
                
        }
    }

    private void Update()
    {
        if (!GameStats.instance.IsPlay) return;
        transform.Translate(Vector2.down * speedFall * Time.deltaTime,Space.World);
    }

    public void SetSpeedFall(float _speed)
    {
        speedFall = _speed;
    }

    public RubbishType GetTypeRubbish()
    {
        return type;
    }

    public int GetPoints()
    {
        return pointCollect;
    }

    public void CreateGoodEffect(Transform parent)
    {
        GoodEffect.startColor = SetColorEffect(type);
        Destroy(Instantiate(GoodEffect, parent.position, Quaternion.identity,parent),1f);
    }
    
    public void CreateBadEffect(Transform parent)
    {
        GoodEffect.startColor = Color.gray;
        Destroy(Instantiate(BadEffect, parent.position, Quaternion.identity,parent),1f);
    }

    

}
