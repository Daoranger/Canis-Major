using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private LevelData level;

    public GameObject endGameScreen;

    [SerializeField] private bool thisIsTheEnd;
   


    private void Update()
    {
      
        if (!level.firstTimeOpen && thisIsTheEnd && endGameScreen.activeSelf == false)
        {
            endGameScreen.SetActive(true);
        }
    }

}
