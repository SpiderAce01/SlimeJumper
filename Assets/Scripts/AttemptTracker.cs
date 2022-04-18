using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AttemptTracker : MonoBehaviour
{
    public static AttemptTracker instance;

    public int attempts;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(transform.parent.gameObject);
        }

        DontDestroyOnLoad(transform.parent.gameObject);
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Main Menu")
        {
            GetComponent<TMPro.TMP_Text>().text = "";
        }
        else
        {
            GetComponent<TMPro.TMP_Text>().text = "Attempt " + attempts;
        }
    }
}
