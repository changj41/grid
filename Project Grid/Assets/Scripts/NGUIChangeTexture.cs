using UnityEngine;
using System.Collections;

public class NGUIChangeTexture : MonoBehaviour {
	
	private int TextureSize;
	public Texture[] MoveTexture = new Texture[5];
	public float MoveFrameTick = 0.3f;
	public bool Moving = false;
	private int MoveStepTick = 0, MoveMaxTick = 0;
	private UITexture UT;
	private Shader BaseShader;
	
	public float DestorySec = 0, MoveDoneTimeFre = 0;
	
	public GameObject OneMoveDoneCallObject;
	public string OneMoveDoneCallFunc;
	
	// Use this for initialization
	void Start () {
		TextureSize = MoveTexture.Length;
		
		MoveMaxTick = TextureSize;
		UT = GetComponent<UITexture>();
//		BaseShader = UT.shader;

	}
	
	
	public void StartFrameMove()
	{
		Moving = true;
	}
	
	private float DestoryFrame = 0;
	void CheckDestory()
	{
		DestoryFrame += Time.deltaTime;
		if ( DestoryFrame < DestorySec ) return;
		
		Destroy(this.gameObject);
	}
	
	private float MoveFrame;
	// Update is called once per frame
	void Update () {
		
		if ( Moving == false ) return;
		if ( DestorySec > 0 ) CheckDestory();

		
		MoveFrame += Time.deltaTime;
		if ( MoveFrame < MoveFrameTick ) {
			return;
		}
		MoveFrame = 0;
//		UT.mainTexture = MoveTexture[MoveStepTick];
//		UT.shader = BaseShader;
		MoveStepTick++;
		if ( MoveStepTick >= MoveMaxTick ) {
			
			if ( MoveOnce == true ) {
				Moving = false;
				MoveOnce = false;
				
				if ( OneMoveDoneCallObject != null && OneMoveDoneCallFunc != null ) {
					print ("do "+OneMoveDoneCallFunc);
					OneMoveDoneCallObject.SendMessage(OneMoveDoneCallFunc);
					
					if ( MoveOnceDestory == true ) Destroy(this.gameObject);
				}
			} else {
				if ( OneMoveDoneCallObject != null && OneMoveDoneCallFunc != null ) {
					print ("do "+OneMoveDoneCallFunc);
					OneMoveDoneCallObject.SendMessage(OneMoveDoneCallFunc);
					
					if ( MoveOnceDestory == true ) Destroy(this.gameObject);
				}
			}
			
			if ( MoveDoneTimeFre > 0 ) MoveFrame = MoveFrameTick - MoveDoneTimeFre;
			
			MoveStepTick = 0;
		}
	}
	
	public bool MoveOnce = false;
	public bool MoveOnceDestory = false;
	public void OneMove()
	{
		Moving = true;
		MoveOnce = true;
	}
	/*
	public void OnDisable()
	{
		print ("Destory:"+this.name);
		Resources.UnloadUnusedAssets();
		Destroy(renderer.material);
		Destroy(this.gameObject);
	}*/
}
