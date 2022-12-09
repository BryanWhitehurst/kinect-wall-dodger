using UnityEngine;

public class main : MonoBehaviour
{
    // Handler for SkeletalTracking thread.
    public GameObject m_tracker;
    private SkeletalTrackingProvider m_skeletalTrackingProvider;
    public BackgroundData m_lastFrameData = new BackgroundData();

    void Start()
    {
        //tracker ids needed for when there are two trackers
        const int TRACKER_ID = 0;
        Debug.Log("in main start");
        
        //if a skeletal tracking provider doesn't exist, create a new one and set that in MainManager
        //if the tracker has already been created, simply set the current scene's skeletal tracking provider to the one set in MainManager
        if (MainManager.Instance.m_skeletalTrackingProvider == null)
        {
            Debug.Log("creating new skeletal tracking provider");
            m_skeletalTrackingProvider = new SkeletalTrackingProvider(TRACKER_ID);
            MainManager.Instance.m_skeletalTrackingProvider = m_skeletalTrackingProvider;

        }
        else {
            Debug.Log("sekeltal tracking provider already exists, using the old one");
            m_skeletalTrackingProvider = MainManager.Instance.m_skeletalTrackingProvider;
        }
    }

    void Update()
    {
        if (m_skeletalTrackingProvider.IsRunning)
        {
            if (m_skeletalTrackingProvider.GetCurrentFrameData(ref m_lastFrameData))
            {
                if (m_lastFrameData.NumOfBodies != 0)
                {
                    m_tracker.GetComponent<TrackerHandler>().updateTracker(m_lastFrameData);
                }
            }
        }
    }

    void OnApplicationQuit()
    {
        if (m_skeletalTrackingProvider != null)
        {
            m_skeletalTrackingProvider.Dispose();
        }
    }

    /*void OnDestroy()
    {
        Debug.Log("Destroying Sekeltal Tracking Provider");
        if (m_skeletalTrackingProvider != null)
        {
            m_skeletalTrackingProvider.Dispose();
        }
    }
    */
}
