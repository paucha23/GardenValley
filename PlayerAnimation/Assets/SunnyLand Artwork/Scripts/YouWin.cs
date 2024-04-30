using UnityEngine;

public class YouWin : MonoBehaviour
{
    public static YouWin instance; 
    public int gemAmount = 0;
    public int totalGemsNeeded = 20;
    public GameObject youWinPanel;

    private void Awake()
    {
        instance = this; 
    }

    public void GemCollect()
    {
        gemAmount++;
        if (gemAmount >= totalGemsNeeded)
        {
            Time.timeScale = 0;
            youWinPanel.SetActive(true);
        }
    }
}
