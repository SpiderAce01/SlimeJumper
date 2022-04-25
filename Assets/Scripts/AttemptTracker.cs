using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AttemptTracker : MonoBehaviour
{
    public static AttemptTracker instance;
    public TMPro.TMP_Text attemptClone;

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
            attemptClone.text = "Attempt " + attempts;
        }
    }
}
