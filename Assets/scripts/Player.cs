using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Player : MonoBehaviour
{
    float x, z;

    //スピード
    float speed = 0.1f;

    //カメラの変数
    public GameObject cam;
    Quaternion cameraRot, characterRot;

    //ウェポンの変数
    public GameObject asaruto, handgun;

    //ウェポンの種類
    public int weponindex = 0;

    //カメラの変数
    public GameObject maincamera, subcamera;

    //マウス感度
    float xsensityvity = 3f, ysensityvity = 3f;

    //カーソル
    bool cursorLock = true;

    //弾のプレファブ
    public GameObject bulletprefabs;

    /////////アサルトライフル弾薬の発射ポイント///////////////////
    public Transform bulletpoint, zoompoint;
    /////////アサルトライフルのプライベート型の発射ポイント///////////
    private Transform Pbulletpoint, Pzoompoint;

    //角度制限
   　float minX = -90f, maxX = 90f;

   　//弾薬数
　　　public int amunation = 50, maxamunation = 50, amoclip = 10, maxamoclip = 10;

     //プレイヤーHP
  　 int playerHP = 100, maxPlayerHP = 100;

    //プレイヤーHPスライダー
    public Slider hpslider;

    //プレイヤーUI表示
    public Text ammotext;

    //音
    AudioSource AudioSource;

    //弾薬音
    public AudioClip shotse, aiming, maxamo;

    //弾薬補充
    public int ammobox;


    private void Start()
    {
        cameraRot = cam.transform.localRotation;
        characterRot = transform.localRotation;

        //プレイヤーHP
        hpslider.value = playerHP;

        //弾薬表示
        ammotext.text = amoclip + "/" + amunation;
        //音
        AudioSource = GetComponent<AudioSource>();

        Pzoompoint = bulletpoint;
        Pbulletpoint = zoompoint;



    }

    private void Update()
    {
        float xRot = Input.GetAxis("Mouse X") * xsensityvity;
        float yRot = Input.GetAxis("Mouse Y") * ysensityvity;

        cameraRot = clamprotation(cameraRot);
        cameraRot *= Quaternion.Euler(-yRot, 0, 0);
        characterRot *= Quaternion.Euler(0, xRot, 0);

        cam.transform.localRotation = cameraRot;
        transform.localRotation = characterRot;

        updatecursolock();

        shot();

        bukichange();

       
    }

    // プレイヤーの移動
    private void FixedUpdate()
    {
        x = 0;
        z = 0;

        x = Input.GetAxisRaw("Horizontal");

        z = Input.GetAxisRaw("Vertical");

        transform.position += cam.transform.forward * z + cam.transform.right * x;
    }

    //カーソルの表示。非表示
    public void updatecursolock()
    {
        if (Input.GetMouseButton(1))
        {
            cursorLock = false;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            cursorLock = true;
        }

        if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        else if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    //プレイヤーの射撃
    public void shot()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (amoclip > 0)
            {
                Instantiate(bulletprefabs, Pzoompoint.transform.position, transform.rotation);
                amoclip--;
                ammotext.text = amoclip + "/" + amunation;
                AudioSource.PlayOneShot(shotse);
                subcamera.SetActive(true);
                
            }

            else 
            {
                Instantiate(bulletprefabs,Pbulletpoint.transform.position, transform.rotation);
                amoclip--;
                ammotext.text = amoclip + "/" + amunation;
                AudioSource.PlayOneShot(shotse);
                subcamera.SetActive(true);

            }

        }

        //リロード
        if (Input.GetMouseButton(1))
        {
            int amontNeed = maxamoclip - amoclip;
            int amoavailable = amontNeed < amunation ? amontNeed : amunation;

            if (amontNeed !=0 && amunation!=0)
            {
                amunation -= amoavailable;
                amoclip += amoavailable;
                ammotext.text = amoclip + "/" + amunation;
                AudioSource.PlayOneShot(aiming);
            }
        }

        //射撃ズーム
        if(Input.GetKey(KeyCode.B))
        {
            subcamera.SetActive(true);
            maincamera.GetComponent<Camera>().enabled = false;

        }
        else if (subcamera.activeSelf)
        {
            subcamera.SetActive(false);
            maincamera.GetComponent<Camera>().enabled = true;
        }

    }

    public Quaternion clamprotation(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w /= 1f;

        float angleX = Mathf.Atan(q.x) * Mathf.Rad2Deg * 2f;

        angleX = Mathf.Clamp(angleX,minX,maxX);

        q.x = Mathf.Tan(angleX * Mathf.Deg2Rad * 0.5f);

        return q;
    }


    //武器の切り替え
    public void bukichange()
    {
        //ウェポンアサルトライフル
        if (weponindex　==　0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                handgun.SetActive(true);
                asaruto.SetActive(false);
                weponindex = 1;

                Pzoompoint = bulletpoint;
                Pbulletpoint = zoompoint;


            }
        }

        //ウェポンハンドガン
        else if (weponindex　==　1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                handgun.SetActive(false);
                asaruto.SetActive(true);
                weponindex = 0;

            }

        }

        
    }

    //弾薬補充
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="ammobox")
        {
            if (maxamunation > amunation)
            {
                amunation += ammobox;
                if (maxamunation < amunation)
                {
                    amunation = maxamunation;
                }
                
            }
            ammotext.text = amoclip + "/" + amunation;
            AudioSource.PlayOneShot(maxamo);
            
        }
    }

}
