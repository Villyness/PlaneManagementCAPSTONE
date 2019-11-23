using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOutline : MonoBehaviour
{
    public bool burgerFlashing = false;
    public bool drinkFlashing = false;
    public bool mopFlashing = false;
    [SerializeField]private float delay = 0.05f;
    public GameObject largerBurger;
    public GameObject largerDrink;
    public GameObject largerMop;

    // Start is called before the first frame update
    void Start()
    {
        if (largerBurger != null)
        {
            //largerBurger.SetActive(false);
            StartCoroutine(BurgerFlashOutline());
        }
        if (largerDrink != null)
        {
            //largerDrink.SetActive(false);
            StartCoroutine(DrinkFlashOutline());
        }
        if (largerMop != null)
        {
            //largerMop.SetActive(false);
            StartCoroutine(MopFlashOutline());
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator BurgerFlashOutline()
    {
        // Burger Flashing
        while (burgerFlashing)
        {
            largerBurger.SetActive(!largerBurger.activeSelf);
            yield return new WaitForSecondsRealtime(delay);
        }
    }
    private IEnumerator DrinkFlashOutline()
    {
        // Burger Flashing
        while (drinkFlashing)
        {
            largerDrink.SetActive(!largerDrink.activeSelf);
            yield return new WaitForSecondsRealtime(delay);
        }
    }

    private IEnumerator MopFlashOutline()
    {
        // Burger Flashing
        while (mopFlashing)
        {
            largerMop.SetActive(!largerMop.activeSelf);
            yield return new WaitForSecondsRealtime(delay);
        }
    }

}
