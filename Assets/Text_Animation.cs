//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Globalization;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;

//public class Text_Animation : MonoBehaviour
//{
//    public Text textComponent;
//    // Start is called before the first frame update

//    // Update is called once per frame
//    void Update()
//    {
//        textComponent.ForceMeshUpdate();
//        var textInfo = textComponent.textInfo;

//        for(int i =0; i < TextInfo.characterCount; ++i)
//        {
//            var charInfo = TextInfo.characterInfo[i];

//            if(!charInfo.isVisible)
//            {
//                continue;
//            }

//            var verts = TextInfo.meshInfo[charInfo.materialReferenceIndex].vertices;

//            for(int j =0; j < 4; ++j)
//            {
//                var orig = verts[charInfo.vertexIndex + j];
//                verts[charInfo.vertexIndex + j] = orig + new Vector3(0, Mathf.Sin(Time.time * 2f + orig.x * 0.01f) * 10f, 0);
//            }
//        }

//        for (int i = 0; i < TextInfo.meshInfo.Length; ++i)
//        {
//            var meshInfo = TextInfo.meshInfo[i];
//            meshInfo.mesh.vertices = meshInfo.vertices;
//            textComponent.UpdateGeometry(meshInfo.mesh, i);
//        }
//    }
//}
