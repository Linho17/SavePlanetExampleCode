using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum RubbishType
{
    Organic,
    Paper,
    Plastic,
    Glass
    
}
public class TrashCan : MonoBehaviour
{
    [SerializeField] private RubbishType type;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float borderX;
    private float levelY;
    [SerializeField] private float speed;
    [SerializeField] private Light light;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClips;

    private bool isCurrent;
    public bool IsCurrent
    {
        set
        {
            isCurrent = value;
            if(isCurrent == true)
            {
                light.enabled = true;
                
            }
            else
            {
                light.enabled = false;
            }
        }
    }
    private void Awake()
    {
        light.enabled = false;
        SetLightColor(type);
        levelY = transform.position.y;
    }

    private void SetLightColor(RubbishType _type)
    {
        switch (_type)
        {
            case RubbishType.Organic:
                light.color = Color.white;
                break;
            case RubbishType.Paper:
                light.color = Color.blue;
                break;
            case RubbishType.Plastic:

                light.color = Color.yellow;
                break;
            case RubbishType.Glass:
                light.color = Color.green;
                break;
        }
    }

    public void Move(float xMove, bool isMouse = false)
    {
        float x;
        if (isMouse)
        {
            x = xMove;
        }
        else
        {
            transform.Translate(Vector2.right * xMove * speed * Time.deltaTime);
            x = transform.position.x;
        }
        
        x = Mathf.Clamp(x, -borderX, borderX);
        transform.position = new Vector2(x, levelY);
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        Trash collisionTrash = collision.gameObject.GetComponent<Trash>();
        if (collisionTrash != null)
        {
            if (collisionTrash.GetTypeRubbish()==type)
            {
                
                GameStats.POINTS += collisionTrash.GetPoints();
                collisionTrash.CreateGoodEffect(transform);
            }
            else
            {
                audioSource.PlayOneShot(audioClips[Random.Range(0,audioClips.Length)]);
                GameStats.HEALTH--;
                collisionTrash.CreateBadEffect(transform);
            }

            Destroy(collisionTrash.gameObject);
            //collision.transform.position = new Vector3(transform.position.x, collision.transform.position.y);

        }
    }

}
