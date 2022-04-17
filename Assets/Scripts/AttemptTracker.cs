using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        GetComponent<TMPro.TMP_Text>().text = "Attempt " + attempts;
    }
}
