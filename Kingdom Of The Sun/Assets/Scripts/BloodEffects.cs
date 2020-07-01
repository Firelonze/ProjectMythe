using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodEffects : MonoBehaviour
{
    [SerializeField] private Sprite[] images;
    private Image image;

    private int randomizer;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void BloodEffect()
    {
        Debug.Log("German empire");
        randomizer = Random.Range(0, 3);
        image.sprite = images[randomizer];
        Debug.Log(image.sprite.name);
        StartCoroutine(Fade());
    }

    private IEnumerator Fade()
    {
        Color temp = image.color;
        temp.a = 0.85f;
        image.color = temp;
        while (image.color.a > 0)
        {
            yield return new WaitForSeconds(0.0001f);
            temp.a -= 0.015f;
            image.color = temp;

            yield return null;
        }
    }
}
