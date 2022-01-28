using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class PlaceController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Color rightColor;
    [SerializeField] private Color wrongColor;
    [SerializeField] private Color initialColor;

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(tag))
        {
            spriteRenderer.color = rightColor;
            LevelController.Instance.IncrementGreen();
        }
        else
        {
            spriteRenderer.color = wrongColor;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        spriteRenderer.color = initialColor;
        if(other.CompareTag(tag))
            LevelController.Instance.DecrementGreen();
    }
}
