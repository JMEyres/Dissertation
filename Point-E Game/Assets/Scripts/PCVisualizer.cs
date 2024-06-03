using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class PCVisualizer : MonoBehaviour
{
    private string path = "./Assets/PCFiles/Turret1.txt";
    private ParticleSystem.Particle[] cloud;
    private List<Vector3> coords;
    private bool pointsUpdated = false;

    // Start is called before the first frame update
    void Start()
    {
        coords = CreateCoordsList(path);
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

    public void SetPoints(List<Vector3> coords)
    {
        cloud = new ParticleSystem.Particle [coords.Count];
        for (int i = 0; i < coords.Count; i++)
        {
            cloud[i].position = coords[i];
            cloud[i].startSize = 0.01f;
        }

        pointsUpdated = true;
    }

    List<Vector3> CreateCoordsList(string path)
    {
        List<Vector3> coordsList = new List<Vector3>();
        String[] itemStrings = File.ReadAllLines(path);
        for (int i = 0; i < itemStrings.Length; i++)
        {
            String tempString;
            tempString = itemStrings[i].Replace("[","");
            tempString = tempString.Replace("]","");
            itemStrings[i] = tempString;
        }

        for (int i = 0; i < itemStrings.Length; i++)
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
