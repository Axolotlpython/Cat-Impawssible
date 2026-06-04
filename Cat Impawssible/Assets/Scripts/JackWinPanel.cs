using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class JackWinPanel : MonoBehaviour
{
    public GameObject winPanel;
    [SerializeField] private Animator animator;

    void Update()
    {
        if (winPanel == true)
        {
            animator.SetBool("Jack Sit", true);
        }
    }

}
    
