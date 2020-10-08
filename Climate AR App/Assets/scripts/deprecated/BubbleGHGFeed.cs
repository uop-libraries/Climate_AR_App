#define Graph_And_Chart_PRO
using ChartAndGraph;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//******************NOT IN USE****************************************
public class BubbleGHGFeed : MonoBehaviour
{
    string[] items = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K" };
    //get the data from the component
    public List<Vector3> section1;
    public List<Vector3> section2;
    public List<Vector3> section3;
    //public List<float> section2;
    void Start()
    {
        GraphChartBase graph = GetComponent<GraphChartBase>();
        if (graph != null)
        {
            //      graph.DataSource.StartBatch();
            graph.DataSource.ClearCategory("Section1");
            graph.DataSource.ClearCategory("Section2");
            graph.DataSource.ClearCategory("Section3");

            for (int i = 0; i < section1.Count; i++)
            {
                GraphData.AddPointToCategoryWithLabel(graph, "Section1", section1[i].x, section1[i].y, section1[i].z, items[i], i.ToString());
                //Debug.Log("Section1 at " + i + " is "  + section1[i].ToString());

            }

            for (int i = 0; i < section2.Count; i++)
            {
                GraphData.AddPointToCategoryWithLabel(graph, "Section2", section2[i].x, section2[i].y, section2[i].z, items[i], i.ToString());
                //Debug.Log("Section2 at " + i + " is " + section2[i].ToString());

            }

            for (int i = 0; i < section3.Count; i++)
            {
                GraphData.AddPointToCategoryWithLabel(graph, "Section3", section3[i].x, section3[i].y, section3[i].z, items[i], i.ToString());
                //Debug.Log("Section3 at " + i + " is " + section3[i].ToString());

            }
            // graph.DataSource.EndBatch();
        }
    }
}
