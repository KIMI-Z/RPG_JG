using UnityEngine;
using System.Collections;
using System.IO;
using System;
using SimpleFramework;
using System.Collections.Generic;


public class ResourceManager{
    private static string FightEffectRoot = "Fight/Effects/";
    private Dictionary<string, UnityEngine.Object> resDict = new Dictionary<string, UnityEngine.Object>();
    private static ResourceManager instance;
    public static ResourceManager Instance{
        get{
            if (instance == null) instance = new ResourceManager();
            return instance;
        }
    }
    private ResourceManager() {}


    public GameObject LoadFightEffect(string effectName)
    {
        string path = FightEffectRoot + effectName;
        return LoadPrefab(path) as GameObject;
    }

    public UnityEngine.Object LoadPrefab(string path)
    {
        if (resDict.ContainsKey(path)) return resDict[path];
        UnityEngine.Object o = Resources.Load(path);
        if (o != null)
        {
            resDict.Add(path, o);
        }
        return o;
    }


    public UnityEngine.Object LoadMesPrefab()
    {
        string path = "UI/Prefabs/ShowMes";
        return LoadPrefab(path);
    }
    public void Init()
    {
       
    }









//        private AssetBundle shared;

//        /// <summary>
//        /// ��ʼ��
//        /// </summary>
//        public void initialize(Action func) {
//            if (AppConst.ExampleMode) {
//                byte[] stream;
//                string uri = string.Empty;
//                //------------------------------------Shared--------------------------------------
//                uri = Util.DataPath + "shared.assetbundle";
//                Debug.LogWarning("LoadFile::>> " + uri);

//                stream = File.ReadAllBytes(uri);
//                shared = AssetBundle.CreateFromMemoryImmediate(stream);
//#if UNITY_5
//        shared.LoadAsset("Dialog", typeof(GameObject));
//#else
//                shared.Load("Dialog", typeof(GameObject));
//#endif
//            }
//            if (func != null) func();    //��Դ��ʼ����ɣ��ص���Ϸ��������ִ�к������� 
//        }

//        /// <summary>
//        /// �����ز�
//        /// </summary>
//        public AssetBundle LoadBundle(string name) {
//            byte[] stream = null;
//            AssetBundle bundle = null;
//            string uri = Util.DataPath + name.ToLower() + ".assetbundle";
//            stream = File.ReadAllBytes(uri);
//            bundle = AssetBundle.CreateFromMemoryImmediate(stream); //�������ݵ��زİ�
//            return bundle;
//        }

//        /// <summary>
//        /// ������Դ
//        /// </summary>
//        void OnDestroy() {
//            if (shared != null) shared.Unload(true);
//            Debug.Log("~ResourceManager was destroy!");
//        }


}
