using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] private int numOfSegments;
    
    private GameObject radialMaskRef;
    private GameObject radialBGRef;
    private GameObject segmentRef;

    private RectTransform maskRect;
    private RectTransform BGRect;

    private List<GameObject> radialLines = new List<GameObject>();

    private Vector2 mousePos;

    public List<string> buildables;
    public Color normalColor;
    public Color highlightedColor;

    public GameObject segment;
    private Image segmentImage;
    private int selectedSegment;
    
    // Start is called before the first frame update
    void Start()
    {
        radialMaskRef = Instantiate(radialMask, transform);
        radialBGRef = Instantiate(radialBackground, transform);
        segmentRef = Instantiate(segment, radialBGRef.transform);

        maskRect = radialMaskRef.GetComponent<RectTransform>();
        BGRect = radialBGRef.GetComponent<RectTransform>();
        segmentImage = segmentRef.GetComponent<Image>();

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
            }
        }
    }

    // Update is called once per frame
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
                //Debug.Log(buildables[selectedSegment]);
                gameObject.SetActive(false);
            }
        }
    }
}   
