using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonResponderUpdated : MonoBehaviour {
    public GameObject[] GameObjects;
    public int CurrentModel = 0;
    private GameObjectsContainer[] MeshToSwapContainer;
    private MakeSueTalk[] TalkContainer;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
    public void ChangeMatButtonClicked()
    {
        GameObjects[CurrentModel].GetComponentInChildren<ChangeMaterialTexture>().ChangeShaderButtonClicked();
    }
    public void ChangeBlendButtonClicked()
    {
        GameObjects[CurrentModel].GetComponent<ChangeBlendShapeOfSelectedObject>().ChangeBlend();
    }
    public void SwapGeometry(string WhatObject)
    {
        print("Geometry to swap= " + WhatObject);
        MeshToSwapContainer = GameObjects[CurrentModel].GetComponents<GameObjectsContainer>();
        for (int i = 0; i < MeshToSwapContainer.Length; i++)
        {
            if (MeshToSwapContainer[i].ContainerName == WhatObject)
            {
                print("I found the" + WhatObject + " container");
                GameObjectsContainer CurrentContainer = MeshToSwapContainer[i];

                int Counter = CurrentContainer.ObjectSelected;
                print("Changing the Object");
                if (Counter < CurrentContainer.GameObjects.Length && Counter == 0)
                {
                    CurrentContainer.GameObjects[Counter].SetActive(true);
                    CurrentContainer.ObjectSelected++;
                }
                else if (Counter < CurrentContainer.GameObjects.Length)
                {
                    CurrentContainer.GameObjects[Counter - 1].SetActive(false);
                    CurrentContainer.GameObjects[Counter].SetActive(true);
                    CurrentContainer.ObjectSelected++;

                }
                else
                {
                    CurrentContainer.GameObjects[Counter - 1].SetActive(false);
                    CurrentContainer.ObjectSelected = 0;
                }
            }
        }
    }
    public void GetObject()
    {

    }
    public void ChangeAnimsButtonClicked()
    {

    }
    public void PlayInstrumentClicked()
    {

    }
    public void Talk()
    {
        TalkContainer = GameObjects[CurrentModel].GetComponents<MakeSueTalk>();
        for (int i = 0; i < TalkContainer.Length; i++)
        {
            TalkContainer[i].talk();
        }
    }
}
