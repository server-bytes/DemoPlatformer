using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Animator panelGameOverAnim;
    private int status = 0;

    private void Start()
    {
    }

    public void GameOver()
    {
        if (status == 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().enabled = false;

            panelGameOverAnim.SetTrigger("Open");
            status = 1;
        }
    }

    public void PlayAgain()
    {
        panelGameOverAnim.SetTrigger("Close");
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
