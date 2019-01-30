using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CookieUI : MonoBehaviour
{
    [Space(10)]
    [Header("Referencias")]

    public Transform canvas;

    [SerializeField]
    public TextMeshProUGUI cookiesText, cpsText; 

    public GameObject upgradePanel, caixaInformativa, achievementPanel, notificacaoPanel, notificacaoPrefab;

    [Space(10)]
    [Header("Prefabs")]
    public GameObject cookiesPrefab;
    public GameObject cookiesTextPrefab;

    [Space(10)]
    [Header("Imagens")]
    public Sprite questionMark;

    public static CookieUI Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }
}
