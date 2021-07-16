using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashCansControl : MonoBehaviour
{
    [SerializeField] private TrashCan[] trashCans;
    
    private int currentIndex = 0;

    private void Start()
    {
        GameOver();
    }
    private void Update()
    {
        
        if (!GameStats.instance.IsPlay) return;

        if (Input.GetKeyDown(KeyCode.DownArrow)|| Input.GetKeyDown(KeyCode.S)) DownCursor();
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) UpCursor();

        trashCans[currentIndex].Move(Input.GetAxis("Horizontal"));


    }

    public void SetCurrentCan(int indexCan)
    {
        trashCans[currentIndex].IsCurrent = false;
        currentIndex = indexCan;
        trashCans[currentIndex].IsCurrent = true;
    }

    public void UpCursor()
    {
        if (!GameStats.instance.IsPlay) return;
        trashCans[currentIndex].IsCurrent = false;
        currentIndex--;
        currentIndex = Mathf.Clamp(currentIndex, 0, trashCans.Length - 1);
        trashCans[currentIndex].IsCurrent = true;

        
    }

    public void DownCursor()
    {
        if (!GameStats.instance.IsPlay) return;
        trashCans[currentIndex].IsCurrent = false;
        currentIndex++;
        currentIndex = Mathf.Clamp(currentIndex, 0, trashCans.Length - 1);
        trashCans[currentIndex].IsCurrent = true;

      

    }


    public void LeftButton()
    {

        trashCans[currentIndex].Move(-1);
       
    }

    public void RightButton()
    {
        trashCans[currentIndex].Move(1);
      
    }

    public void Reset()
    {
        foreach (TrashCan t in trashCans)
        {

            t.gameObject.SetActive(true);
            t.transform.position = new Vector2(0, t.transform.position.y);
        
        }
        SetCurrentCan(0);

    }

    public void GameOver()
    {
        foreach (TrashCan t in trashCans)
        {

            t.gameObject.SetActive(false);


        }
    }


}
