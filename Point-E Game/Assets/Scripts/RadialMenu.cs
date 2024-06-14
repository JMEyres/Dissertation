using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RadialMenu : MonoBehaviour
{
    [Header("Parent Object")] 
    [SerializeField] private GameObject parent;

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
    [SerializeField] private List<BuildingPlaceable> buildables;
    [SerializeField] private Color normalColor;
    [SerializeField] private Color highlightedColor;

    private GameObject radialMaskRef;
    private GameObject radialBGRef;
    private GameObject segmentRef;

    private RectTransform maskRect;
    private RectTransform BGRect;

    private List<GameObject> radialLines = new List<GameObject>();
    private List<GameObject> textObjects = new List<GameObject>();

    private Vector2 mousePos;
    
    private int numOfSegments;
    private Image segmentImage;
    private int selectedSegment;

    private bool toggle = false;

    void Awake()
    {
        parent.SetActive(false);
        parent.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
        radialMaskRef = Instantiate(radialMask, parent.transform);
        radialBGRef = Instantiate(radialBackground, parent.transform);
        segmentRef = Instantiate(segment, radialBGRef.transform);

        maskRect = radialMaskRef.GetComponent<RectTransform>();
        BGRect = radialBGRef.GetComponent<RectTransform>();
        segmentImage = segmentRef.GetComponent<Image>();

        numOfSegments = buildables.Count;
        
        maskRect.sizeDelta = new Vector2(maskRadius * 2, maskRadius * 2); 
        BGRect.sizeDelta = new Vector2(backgroundRadius * 2, backgroundRadius * 2);

       segmentRef.GetComponent<RectTransform>().sizeDelta = new Vector2(backgroundRadius * 2, backgroundRadius * 2);
       segmentImage.fillAmount = 1.0f/numOfSegments;
        
        float angleSize = 360.0f / numOfSegments;

        if(buildables.Count == 0)
            Debug.LogError("You need to assign prefab strings in the inspector, make sure they are formatted exactly the same as the prefab name");
        
        for (int i = 0; i < buildables.Count; i++)
        {
            var tempText = Instantiate(textPrefab, parent.transform);
            tempText.GetComponent<TextMeshProUGUI>().text = buildables[i].gameObject.name;
            tempText.transform.localEulerAngles = new Vector3(0, 0, -(i + 0.5f) * angleSize + 180);
            tempText.transform.Translate(new Vector3(0, backgroundRadius*0.75f, 0),Space.Self); 
            tempText.transform.localEulerAngles = new Vector3(0, 0, 0);
        }

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

                radialLines[i].GetComponent<RectTransform>().localEulerAngles =
                    new Vector3(0, 180, (i + 1) * angleSize);
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
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                toggle = !toggle;
                parent.SetActive(toggle);
            }

            if (parent.activeSelf && Input.GetMouseButtonDown(0))
            {
                toggle = false;
                Grid.SelectBuilding(buildables[selectedSegment].gameObject.name);
                parent.SetActive(false);
            }
        }
    }
}   
