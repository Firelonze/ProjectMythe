using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodEffects : MonoBehaviour
{
    [SerializeField] private Sprite[] images;
    private Image image;

    private int randomizer;

    private float decrease = 0.01f;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Start()
    {
        BloodEffect();
    }

    public void BloodEffect()
    {
        randomizer = Random.Range(0, 2);
        image.sprite = images[randomizer];
        StartCoroutine(Fade());
    }

    private IEnumerator Fade()
    {
        Color temp = image.color;
        temp.a = 0.85f;
        while (image.color.a > 0)
        {
            yield return new WaitForSeconds(0.0001f);
            temp.a -= 0.015f;
            image.color = temp;

            yield return null;
        }
    }
}
