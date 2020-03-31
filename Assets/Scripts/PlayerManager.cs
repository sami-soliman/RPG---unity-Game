using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{

    #region

    public static PlayerManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;
    public int enimiesdiedscene2 = 0;
    public int enimiesdiedscene3 = 0;

    public void KillPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void KillEnemy()
    {
        
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (enimiesdiedscene2 == 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                enimiesdiedscene2++;
            }
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (enimiesdiedscene3 == 4)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                enimiesdiedscene3++;
            }
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
       

    }


}

