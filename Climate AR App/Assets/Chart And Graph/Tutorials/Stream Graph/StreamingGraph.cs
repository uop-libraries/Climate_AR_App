#define Graph_And_Chart_PRO
using UnityEngine;
using System.Collections;
using ChartAndGraph;

public class StreamingGraph : MonoBehaviour
{
    public GraphChart Graph;
    public int TotalPoints = 5;
    float lastTime = 0f;
    float lastX = 0f;
    public GameObject rainfallInfo;
    public GameObject cityGround;
    void Start()
    {
        if (Graph == null) // the ChartGraph info is obtained via the inspector
            return;
        float x = 3f * TotalPoints;
        Graph.DataSource.StartBatch(); // calling StartBatch allows changing the graph data without redrawing the graph for every change
        Graph.DataSource.ClearCategory("Infiltration"); 
        Graph.DataSource.ClearCategory("Runoff"); // clear the "Player 2" category. this category is defined using the GraphChart inspector
        //Graph.DataSource.ClearCategory("Rainfall"); // clear the "Player 2" category. this category is defined using the GraphChart inspector

        for (int i = 0; i < TotalPoints; i++)  //add random points to the graph
        {
            Graph.DataSource.AddPointToCategory("Infiltration", System.DateTime.Now - System.TimeSpan.FromSeconds(x), cityGround.GetComponent<Infiltration>().GetInfiltration() ); // each time we call AddPointToCategory 
            Graph.DataSource.AddPointToCategory("Runoff", System.DateTime.Now  - System.TimeSpan.FromSeconds(x), cityGround.GetComponent<Infiltration>().GetRunoff() ); // each time we call AddPointToCategory 

           // Graph.DataSource.AddPointToCategory("Rainfall", System.DateTime.Now - System.TimeSpan.FromSeconds(x), rainfallInfo.GetComponent<UrbanEnvironment>().GetTotalRainFallAmount());

            x -= Random.value * 3f;
            lastX = x;
        }

        Graph.DataSource.EndBatch(); // finally we call EndBatch , this will cause the GraphChart to redraw itself
    }

    void Update()
    {
        float time = Time.time;
        if (lastTime + 1f < time)
        {
            lastTime = time;
            lastX += Random.value * 3f;
//            System.DateTime t = ChartDateUtility.ValueToDate(lastX);
            Graph.DataSource.AddPointToCategoryRealtime("Infiltration", System.DateTime.Now, cityGround.GetComponent<Infiltration>().GetInfiltration(), 1f); // each time we call AddPointToCategory 
            Graph.DataSource.AddPointToCategoryRealtime("Runoff", System.DateTime.Now, cityGround.GetComponent<Infiltration>().GetRunoff(), 1f); // each time we call AddPointToCategory
           // Graph.DataSource.AddPointToCategory("Rainfall", System.DateTime.Now, rainfallInfo.GetComponent<UrbanEnvironment>().GetTotalRainFallAmount(), 1f);
            //Graph.DataSource.AddPointToCategory("Rainfall", System.DateTime.Now, 100, 1f);

        }

    }
}
