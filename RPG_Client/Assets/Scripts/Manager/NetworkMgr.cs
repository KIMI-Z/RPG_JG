using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using LuaInterface;

namespace SimpleFramework.Manager {
    public class NetworkMgr : LuaComponent {

        private ClientSocket clientSocket;
        private bool isConnected = false;
        void Awake() {
            Init();
        }
        void Init() {
            clientSocket = new ClientSocket();
            clientSocket.Init(DefNetCallBack);
        }

        void OnGUI()
        {
            if (GUILayout.Button("Connect"))
            {
                clientSocket.ConnectServer("127.0.0.1", 12345, (IAsyncResult iar)=>
                {
                    Debug.Log("Connected to Server");
                });
            }
        }


        public void OnInit() {

        }

        public void Unload() {

        }

        /// <summary>
        /// ִ��Lua����
        /// </summary>
        public object[] CallMethod(string func, params object[] args) {
            return null;
        }

        ///------------------------------------------------------------------------------------
        public static void AddEvent(int _event, ByteBuffer data) {
    
        }

        /// <summary>
        /// ����Command�����ﲻ����ķ���˭��
        /// </summary>
        void Update() {
            
        }

        /// <summary>
        /// ������������
        /// </summary>
        public void SendConnect() {
            
        }

        /// <summary>
        /// ����SOCKET��Ϣ
        /// </summary>
        public void SendMessage(ByteBuffer buffer) {
          
        }

        /// <summary>
        /// ��������
        /// </summary>
        void OnDestroy() {
           
        }



        public void DefNetCallBack(IAsyncResult iar)
        {

        }
    }
}