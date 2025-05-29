using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems; // Required for PointerEventData

public class LoadScene : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler// Implementing the interface
{
    public Animator anim; 
    public int scene = 1; 

    // Method to load the scene
    public void Scene()
    {
        SceneManager.LoadScene(scene);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (anim != null)
        {
            anim.SetBool("activ", true);
        }

    }

    public void OnPointerExit (PointerEventData eventData)
    {
        if (anim != null)
        {
            anim.SetBool("activ", false);
        }
    }
}
