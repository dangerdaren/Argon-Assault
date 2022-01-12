using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ammo : MonoBehaviour
{
    float startingAmmo;
    float ammoRemaining;
    TMP_Text ammoText;

    // Start is called before the first frame update
    void Start()
    {
        ammoText = GetComponent<TMP_Text>();
        ammoText.text = ($"Ammo \n {startingAmmo}");
    }

    public void AdjustAmmo(float ammoAdjustment)
    {
        ammoRemaining = Mathf.RoundToInt(ammoAdjustment);

        ammoText.text = ($"Ammo \n {ammoRemaining.ToString()}");

    }

    public void SetStartingAmmo(float newAmmo)
    {
        startingAmmo = newAmmo;
    }
   
}
