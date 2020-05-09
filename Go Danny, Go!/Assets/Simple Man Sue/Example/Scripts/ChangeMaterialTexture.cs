using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialTexture : MonoBehaviour {

    public Material MaterialToChange;
    public Texture[] textures;
    private int CurrentTexture = 0;
    // Use this for initialization
    void Start () {

  


    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ChangeShaderButtonClicked()
    {
       

        if (CurrentTexture < textures.Length)
            CurrentTexture++;
        else
            CurrentTexture = 0;
        MaterialToChange.mainTexture = textures[CurrentTexture];
    }
}
