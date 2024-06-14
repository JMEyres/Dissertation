using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;

public class PCVisualizer : MonoBehaviour
{
    
    [SerializeField]private TextAsset pointCloud;
    private ParticleSystem.Particle[] cloud;
    private List<Vector3> coords;
    private bool pointsUpdated = false;
    
    void Awake()
    {
        coords = CreateCoordsList();
        
        SetPoints(coords);
    }

    // Update is called once per frame
    void Update()
    {
        if (pointsUpdated)
        {
            GetComponent<ParticleSystem>().SetParticles(cloud, cloud.Length);
            pointsUpdated = false;
        }
    }

    public void SetPoints(List<Vector3> _coords)
    {
        cloud = new ParticleSystem.Particle [_coords.Count];
        for (int i = 0; i < _coords.Count; i++)
        {
            cloud[i].position = _coords[i];
            cloud[i].startSize = 0.01f;
        }

        pointsUpdated = true;
    }

    List<Vector3> CreateCoordsList()
    {
        List<Vector3> coordsList = new List<Vector3>();

        string fs = pointCloud.text;
        string[] itemStrings = Regex.Split(fs, "\n");
        for (int i = 0; i < itemStrings.Length-1; i++) 
        {
            string tempString;
            tempString = itemStrings[i].Replace("[","");
            tempString = tempString.Replace("]","");
            itemStrings[i] = tempString;
        }

        for (int i = 0; i < itemStrings.Length-1; i++)
        {
            string[] temp = itemStrings[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
            float x = float.Parse(temp[0]);
            float y = float.Parse(temp[1]);
            float z = float.Parse(temp[2]);

            Vector3 tempVec = new Vector3(x, y, z);
            coordsList.Add(tempVec);
        }

        return coordsList;
    }
}
