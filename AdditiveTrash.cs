using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdditiveTash : MonoBehaviour
{
    private float speedRotate;
    [SerializeField] private float rangeRotate;
    [SerializeField] private bool isMirror = true;

    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Color[] colors;

    void Start()
    {
        speedRotate = Random.Range(-rangeRotate, rangeRotate);
        float v = Random.Range(0.9f, 1.1f);

      
        Vector3 _localScale = transform.localScale;
        _localScale *= v;
        if (isMirror)
        {
            float sign = Random.Range(0, 2) == 1 ? 1 : -1;
            _localScale.x *= sign;
        }
        transform.localScale = _localScale;



        sprite.color = colors[Random.Range(0, colors.Length)];
    }

  
    void Update()
    {
        if (!GameStats.instance.IsPlay) return;
        transform.Rotate(Vector3.forward * speedRotate * Time.deltaTime);
    }
}
