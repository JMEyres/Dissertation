using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RadialMenu : MonoBehaviour
{
    [Header("Mask")]
    [SerializeField] private GameObject radialMask;
    [SerializeField] private float maskRadius;
    
    [Header("Background")]
    [SerializeField] private GameObject radialBackground;
    [SerializeField] private GameObject radialLine;
    [SerializeField] private float backgroundRadius;

    [Header("Segments")] 
    [SerializeField] private GameObject segment;

    [Header("Text")] 
    [SerializeField] private GameObject textPrefab;
    
    [Header("Required")]
    [SerializeField] private List<string> buildables;
    [SerializeField] private Color normalColor;
    [SerializeField] private Color highlightedColor;

    private GameObject radialMaskRef;
    private GameObject radialBGRef;
    private GameObject segmentRef;

    private RectTransform maskRect;
    private RectTransform BGRect;

    private List<GameObject> radialLines = new List<GameObject>();

    private Vector2 mousePos;
    
    private int numOfSegments;
    private Image segmentImage;
    private int selectedSegment;
    
    void Awake()
    {
        radialMaskRef = Instantiate(radialMask, transform);
        radialBGRef = Instantiate(radialBackground, transform);
        segmentRef = Instantiate(segment, radialBGRef.transform);

        maskRect = radialMaskRef.GetComponent<RectTransform>();
        BGRect = radialBGRef.GetComponent<RectTransform>();
        segmentImage = segmentRef.GetComponent<Image>();

        numOfSegments = buildables.Count;
        
        maskRect.sizeDelta = new Vector2(maskRadius * 2, maskRadius * 2);
        BGRect.sizeDelta = new Vector2(backgroundRadius * 2, backgroundRadius * 2);
        segmentRef.GetComponent<RectTransform>().sizeDelta = new Vector2(backgroundRadius * 2, backgroundRadius * 2);
        segmentImage.fillAmount = 1.0f/numOfSegments;


        if(numOfSegments != 1)
        {
            for (int i = 0; i < numOfSegments; i++)
            {
                var temp = Instantiate(radialLine, radialBGRef.transform);
                var tempGraphic = temp.transform.GetChild(0);
                var tempRect = tempGraphic.GetComponent<RectTransform>();
                
                tempRect.sizeDelta = new Vector2(5, backgroundRadius);
                tempRect.localPosition = new Vector3(0, -(backgroundRadius / 2), 0);
                
                radialLines.Add(temp);

                var tempText = Instantiate(textPrefab, transform);
                tempText.GetComponent<TextMeshProUGUI>().text = buildables[i];
                tempText.transform.localEulerAngles = new Vector3(0, 0, 120);
                tempText.transform.Translate(new Vector3(0, backgroundRadius*0.75f, 0),Space.Self); 
                tempText.transform.localEulerAngles = new Vector3(0, 0, 0);
            }
        }
    }

    void Update()
    {
        mousePos.x = Input.mousePosition.x - (Screen.width / 2);
        mousePos.y = Input.mousePosition.y - (Screen.height / 2);
        
        mousePos.Normalize();

        if (mousePos != Vector2.zero)
        {
            float angle = Mathf.Atan2(mousePos.y, -mousePos.x) / Mathf.PI;
            angle *= 180;
            angle += 90;
            if (angle < 0)
            {
                angle += 360;
            }

            if(numOfSegments > 1)
            {
                for (int i = 0; i < numOfSegments; i++)
                {
                    float angleSize = 360.0f / numOfSegments;
                    radialLines[i].GetComponent<RectTransform>().localEulerAngles =
                        new Vector3(0, 180, (i + 1) * angleSize);
                    if (angle > i * angleSize && angle < (i + 1) * angleSize)
                    {
                        segmentRef.transform.localEulerAngles = new Vector3(0, 180, (i + 1) * angleSize);
                        selectedSegment = i;
                    }
                }
            }
            else
            {
                selectedSegment = 0;
            }

            if (Input.GetMouseButtonDown(0))
            {
                Grid.SelectBuilding(buildables[selectedSegment]);
                gameObject.SetActive(false);
            }
        }
    }
}   
