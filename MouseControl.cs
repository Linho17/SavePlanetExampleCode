using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    private bool isMove;
    [SerializeField] private TrashCan trashCan;
    [SerializeField] private TrashCansControl trashCansControl;

    private void Start()
    {
        isMove = false;
    }

    private void OnMouseDown()
    {
     
        
        isMove = true;
        if (trashCansControl.transform.childCount > 0)
        {
          
            for (int i = 0; i < trashCansControl.transform.childCount; i++)
            {
                
                if (trashCansControl.transform.GetChild(i).gameObject == trashCan.gameObject)
                {
                   
                    trashCansControl.SetCurrentCan(i);
                    break;
                }
            }
        }
        
       
        
    }

    private void OnMouseDrag()
    {
        if (!GameStats.instance.IsPlay) return;

        isMove = true;
        if (trashCansControl.transform.childCount > 0)
        {

            for (int i = 0; i < trashCansControl.transform.childCount; i++)
            {

                if (trashCansControl.transform.GetChild(i).gameObject == trashCan.gameObject)
                {

                    trashCansControl.SetCurrentCan(i);
                    break;
                }
            }
        }

        if (isMove)
        {
            float x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            trashCan.Move(x, true);
        }
        
        
        
    }

    private void OnMouseUp()
    {
        isMove = false;
    }
}
