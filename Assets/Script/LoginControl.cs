using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using UnityEngine.Networking;
using System.Runtime.InteropServices;

public class LoginControl : MonoBehaviour {

    public GameObject w_mainSection;
    public GameObject w_loginSection;
    public InputField i_login_email;
    public InputField i_login_password;

    public GameObject w_registerSection;
    public InputField i_register_name;
    public InputField i_register_email;
    public InputField i_register_password;
    public InputField i_register_password_confirm;
    public SceneManagerClassv2 o_scene_manager;

    public GameObject w_loggedInSection;
    public Text t_loggedInData;


    //JWT
    [DllImport("__Internal")]
    private static extern void InsertJWToken(string token);

    [DllImport("__Internal")]
    private static extern string GetUserName();

    [DllImport("__Internal")]
    private static extern string GetUserEmail();

	// Use this for initialization
	void Start () {
		/*
        #if UNITY_EDITOR
        Debug.Log("Unity Editor");
        w_mainSection.SetActive(true);
        #else
        */
            w_mainSection.SetActive(true);
            Debug.Log(GetUserName());
            
        /*
        #endif
        */
    
    
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void toggleLogin (bool isLogin){
        if(isLogin){
            w_registerSection.SetActive(false);
            w_loginSection.SetActive(true);
        }else{
             w_registerSection.SetActive(true);
            w_loginSection.SetActive(false);
        }
    }
    public void register(){
        string userName= i_register_name.text;
        string email= i_register_email.text;
        string password= i_register_password.text;
        string confirmPassword= i_register_password_confirm.text;

        bool hasAt = email.IndexOf('@') > 0;

        if(!hasAt){
            Debug.Log("Email is not valid");
        }else if(!confirmPassword.Equals(password)){
            Debug.Log("Password does not match");
        }else{
            StartCoroutine(register(userName,email,password));
        }

        
    }
    public void login(){
        string email= i_login_email.text;
        string password= i_login_password.text;

        StartCoroutine(login(email,password));
        

        
    }
    IEnumerator login(string email, string password){
        //API URL
        string loginURL= "http://localhost:7000/api/v1/auth/login";

        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        formData.Add(new MultipartFormDataSection("email",email));
        formData.Add(new MultipartFormDataSection("password",password));
        UnityWebRequest loginRequest = UnityWebRequest.Post(loginURL,formData);
        
        yield return loginRequest.SendWebRequest();

        Debug.Log("login success");

        JSONNode result= JSON.Parse(loginRequest.downloadHandler.text);
        Debug.Log(result["token"]);
        InsertJWToken(result["token"]);

        
    }
    IEnumerator register(string name,string email, string password){
        //API URL
        string registerURL= "http://localhost:7000/api/v1/auth/register";

        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        formData.Add(new MultipartFormDataSection("name",name));
        formData.Add(new MultipartFormDataSection("email",email));
        formData.Add(new MultipartFormDataSection("password",password));
        formData.Add(new MultipartFormDataSection("role","user"));
        UnityWebRequest registerRequest = UnityWebRequest.Post(registerURL,formData);
        
        yield return registerRequest.SendWebRequest();

        Debug.Log("register success");

        JSONNode result= JSON.Parse(registerRequest.downloadHandler.text);
        string token= result["token"];
        InsertJWToken(token);

        
    }





}
