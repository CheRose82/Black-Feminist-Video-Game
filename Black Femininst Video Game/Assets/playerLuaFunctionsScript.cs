using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class playerLuaFunctionsScript : MonoBehaviour
{
    [Tooltip("Typically leave unticked so temporary Dialogue Managers don't unregister your functions.")]
    public bool unregisterOnDisable = false;

    void OnEnable()
    {
        // Make the functions available to Lua: (Replace these lines with your own.)
        Lua.RegisterFunction("DebugLog", this, SymbolExtensions.GetMethodInfo(() => DebugLog(string.Empty)));
        Lua.RegisterFunction("AddOne", this, SymbolExtensions.GetMethodInfo(() => AddOne((double)0)));
        Lua.RegisterFunction("SoundCloudStart", this, typeof(playerLuaFunctionsScript).GetMethod("SoundCloudStart"));
        Lua.RegisterFunction("TurnToBones", this, typeof(playerLuaFunctionsScript).GetMethod("TurnToBones"));
        Lua.RegisterFunction("SoundSpawnStart", this, typeof(playerLuaFunctionsScript).GetMethod("SoundSpawnStart"));
        Lua.RegisterFunction("SoundSpawnStop", this, typeof(playerLuaFunctionsScript).GetMethod("SoundSpawnStop"));
        Lua.RegisterFunction("BeesSwarm", this, typeof(playerLuaFunctionsScript).GetMethod("BeesSwarm"));
        Lua.RegisterFunction("UnicornNoTail", this, typeof(playerLuaFunctionsScript).GetMethod("UnicornNoTail"));
        Lua.RegisterFunction("AudreyKnowledge", this, typeof(playerLuaFunctionsScript).GetMethod("AudreyKnowledge"));
        Lua.RegisterFunction("RideUnicorn", this, typeof(playerLuaFunctionsScript).GetMethod("RideUnicorn"));
        Lua.RegisterFunction("DontRideUnicorn", this, typeof(playerLuaFunctionsScript).GetMethod("DontRideUnicorn"));
        Lua.RegisterFunction("DestroyUnicornDB", this, typeof(playerLuaFunctionsScript).GetMethod("DestroyUnicornDB"));
        Lua.RegisterFunction("FollowHorse", this, typeof(playerLuaFunctionsScript).GetMethod("FollowHorse"));
        Lua.RegisterFunction("UnicornEndingRun", this, typeof(playerLuaFunctionsScript).GetMethod("UnicornEndingRun"));
        Lua.RegisterFunction("ToolBox", this, typeof(playerLuaFunctionsScript).GetMethod("ToolBox"));
        Lua.RegisterFunction("ShowUmbrella", this, typeof(playerLuaFunctionsScript).GetMethod("ShowUmbrella"));
        Lua.RegisterFunction("ShowTelescope", this, typeof(playerLuaFunctionsScript).GetMethod("ShowTelescope"));
        Lua.RegisterFunction("ShowKey", this, typeof(playerLuaFunctionsScript).GetMethod("ShowKey"));
        Lua.RegisterFunction("MargLeaves", this, typeof(playerLuaFunctionsScript).GetMethod("MargLeaves"));
        Lua.RegisterFunction("MirrorsRise", this, typeof(playerLuaFunctionsScript).GetMethod("MirrorsRise"));
        Lua.RegisterFunction("MirrorsClosing", this, typeof(playerLuaFunctionsScript).GetMethod("MirrorsClosing"));
        Lua.RegisterFunction("MirrorsEverywhere", this, typeof(playerLuaFunctionsScript).GetMethod("MirrorsEverywhere"));
        Lua.RegisterFunction("StartDancing", this, typeof(playerLuaFunctionsScript).GetMethod("StartDancing"));
        Lua.RegisterFunction("SabineUmbrella", this, typeof(playerLuaFunctionsScript).GetMethod("SabineUmbrella"));
        Lua.RegisterFunction("SabineBreakFree", this, typeof(playerLuaFunctionsScript).GetMethod("SabineBreakFree"));
        Lua.RegisterFunction("MargGiveHammer", this, typeof(playerLuaFunctionsScript).GetMethod("MargGiveHammer"));
        Lua.RegisterFunction("BreakCeiling", this, typeof(playerLuaFunctionsScript).GetMethod("BreakCeiling"));
        Lua.RegisterFunction("DoorVanish", this, typeof(playerLuaFunctionsScript).GetMethod("DoorVanish"));
        Lua.RegisterFunction("DoorVanish", this, typeof(playerLuaFunctionsScript).GetMethod("DoorVanish"));
        Lua.RegisterFunction("HereKey", this, typeof(playerLuaFunctionsScript).GetMethod("HereKey"));

        //Lua.RegisterFunction("MirrorsFlying", this, typeof(playerLuaFunctionsScript).GetMethod("MirrorsFlying"));
    }

    void OnDisable()
    {
        if (unregisterOnDisable)
        {
            // Remove the functions from Lua: (Replace these lines with your own.)
            Lua.UnregisterFunction("DebugLog");
            Lua.UnregisterFunction("AddOne");
            Lua.UnregisterFunction("BlowItUp");
        }
    }

    public void DebugLog(string message)
    {
        Debug.Log(message);
    }

    public double AddOne(double value)
    { // Note: Lua always passes numbers as doubles.
        return value + 1;
    }

    public GameObject soundCloudControl;
    public GameObject soundSpawnControl;
    public GameObject bees;
    public GameObject unicorn;
    public GameObject mirrors;
    public GameObject AudreyLForrest;
    public GameObject unicornDialogueBox;
    public GameObject unicornDialogueBox2;
    public GameObject toolbox1;
    public GameObject aUmbrella;
    public GameObject aTelescope;
    public GameObject aKey;
    public GameObject MargLevel2;
    public GameObject mirrorController;
    public GameObject player;
    public GameObject sabine;
    public GameObject MargHammer;
    public GameObject hammer;
    public GameObject bigDoor;



    private void Start()
    {
        //player = GameObject.Find("Player");
        //Debug.Break();
        
    }

    public void SoundCloudStart()
    {
        soundCloudControl.GetComponent<soundCloudController>().StartSondCloud();
    }

    public void TurnToBones()
    {
        Invoke("Bones", 10);
    }

    public void SoundSpawnStart()
    {
        soundSpawnControl.GetComponent<soundSpawnerController>().SpawnSound();
    }

    public void SoundSpawnStop()
    {
        soundSpawnControl.GetComponent<soundSpawnerController>().StopSpawnSound();
    }

    public void BeesSwarm()
    {
        bees.GetComponent<beeScript>().BeeSwarm();
    }

    public void UnicornNoTail()
    {
        unicorn.GetComponent<BlackUnicornScript>().NoTail();
    }
    public void MirrorsFlying()
    {
        //mirrors.GetComponent<MirrorsFlyingScript>().MirrorsFlying();
    }

    public void SomethingStupid()
    {
        unicorn.GetComponent<BlackUnicornScript>().NoTail();
    }

    public void AudreyKnowledge()
    {
        Instantiate(AudreyLForrest, transform.position + new Vector3(0, 15, 0), Quaternion.identity);
    }

    public void RideUnicorn()
    {
        GetComponent<playerScript>().RideUnicornAttempt = true;
    }

    public void DontRideUnicorn()
    {
        GetComponent<playerScript>().RideUnicornAttempt = false;
    }

    public void DestroyUnicornDB()
    {
        Destroy(unicornDialogueBox);
        unicornDialogueBox2.active = true;
    }

    public void FollowHorse()
    {
        unicorn.GetComponent<BlackUnicornScript>().AIBehavior = 6;
    }

    public void UnicornEndingRun()
    {
        unicorn.GetComponent<BlackUnicornScript>().EndingRunOff();
    }

    public void ToolBox()
    {
        toolbox1.GetComponent<ToolBoxScript>().ActivateToolBox();
    }

    public void ShowUmbrella()
    {
        aUmbrella.GetComponent<umbTeleKeyScript>().ActivateItem();
    }
    public void ShowTelescope()
    {
        aTelescope.GetComponent<umbScript>().ActivateItem2();
    }
    public void ShowKey()
    {
        aKey.GetComponent<kyScript>().ActivateItem3();
    }

    public void MargLeaves()
    {
        MargLevel2.GetComponent<MargLevel2>().DestroyMargL2();
    }

    public void MirrorsRise()
    {
        mirrorController.GetComponent<MirrorControllerScript>().RaiseMirrors();
    }

    public void MirrorsClosing()
    {
        mirrorController.GetComponent<MirrorControllerScript>().CloseMirrors();
    }

    public void MirrorsEverywhere()
    {
        mirrorController.GetComponent<MirrorControllerScript>().UnBlackoutMirrors();
    }

    public void StartDancing()
    {
        GetComponent<playerScript>().Dance();
        Debug.Log("the Lua script should have sent it to the player script");
    }

    public void SabineUmbrella()
    {
        sabine.GetComponent<SabineLevel2>().HereUmbrella();
    }

    public void SabineBreakFree()
    {
        player.GetComponent<playerScript>().BreakFreeMirror();
    }

    public void MargGiveHammer()
    {
        MargHammer.GetComponent<MargLevel2Ending>().Hammer();
    }

    public void BreakCeiling()
    {
        hammer = GameObject.Find("hammer(Clone)");
        hammer.GetComponent<hammerScript>().BreakCeiling();
    }

    public void DoorVanish()
    {
        bigDoor.GetComponent<bossDoorScript>().DoorVanish();
    }

    public void HereKey() 
    {
        sabine.GetComponent<SabineLevel4>().ThrowKey();
        Debug.Log("The key should be thrown");
    }
}
