using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PageManager : MonoBehaviour
{
    [Header("Pages")]
    public GameObject pagePrincipale;
    public GameObject pagePersonnage;

    [Header("Contenu personnage")]
    public TextMeshProUGUI nomText;
    public TextMeshProUGUI descriptionText;
    public Image photoImage;

    [Header("Personnages")]
    public string[] noms;
    public string[] descriptions;
    public Sprite[] photos;

    public void OuvrirPersonnage(int index)
    {
        pagePrincipale.SetActive(false);
        pagePersonnage.SetActive(true);

        nomText.text = noms[index];
        descriptionText.text = descriptions[index];
        if (photos[index] != null)
            photoImage.sprite = photos[index];
    }

    public void Retour()
    {
        pagePersonnage.SetActive(false);
        pagePrincipale.SetActive(true);
    }
}