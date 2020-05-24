using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using NaughtyAttributes;

public class Messenger : MonoBehaviour
{
    public List<Message> defaultMessages;
    public static Messenger _instance;
    public TextMeshProUGUI callToActionText;
    public Image messagePortrait;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        if (_instance == null)
            _instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        CloseMessnger();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Call to open Messenger in the top right corner
    /// </summary>
    public void OpenMessenger(Message message)
    {
        SetMessage(message);
        GetComponent<RectTransform>().DOAnchorPosX(0, .5f, false).SetEase(Ease.InOutElastic);
    }
    /// <summary>
    /// Call to close Messenger in the top right corner
    /// </summary>
    public void CloseMessnger()
    {
        GetComponent<RectTransform>().DOAnchorPosX(300, .5f, false);
    }

    
    private void SetMessage(Message message)
    {
        callToActionText.text = message.callToAction;
        messagePortrait.sprite = message.portraitImage;
    }

}
