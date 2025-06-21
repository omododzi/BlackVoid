using System.Collections.Generic;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
      public List<int> text;

      void Start()
      {
            for (int i = 0; i < text.Count; i++)
            {
                  Debug.Log(text[i]);
            }
      }
}
