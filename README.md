# Unity Utilities

A basic set of utility classes, extension methods and hotkeys for development in Unity.

## PlayerLoopUtility

The `PlayerLoopUtility` class makes it easy to insert and remove custom `PlayerLoopSystems`.

The `PlayerLoopUtility` class contains the 3 following public static methods:
```c#
// Tries to insert a PlayerLoopSystem into the provided player loop at the specified update phase and sub-system list index.
// Returns true if the system was successfully inserted, otherwise false.
TryInsertSystem<T>(ref PlayerLoopSystem loop, in PlayerLoopSystem systemToInsert, int index);
```

```c#
// Removes a PlayerLoopSystem from the provided player loop.
RemoveSystem<T>(ref PlayerLoopSystem loop, in PlayerLoopSystem systemToRemove);
```

```c#
// Prints out the provided player loop to the console.
PrintPlayerLoop(ref PlayerLoopSystem loop);
```

### Update Phases

The generic type `<T>` in the methods `TryInsertSystem<T>()` and `RemoveSystem<T>()` MUST be one of the following structs provided by the `UnityEngine.PlayerLoop` namespace:
- `TimeUpdate`
- `Initialization`
- `EarlyUpdate`
- `FixedUpdate`
- `PreUpdate`
- `Update`
- `PreLateUpdate`
- `PostLateUpdate`

Each of these structs represents different update phases that Unity uses in the player loop. The order they appear in the list above is also the order in which they are executed. Each phase also has a list of sub-systems associated with it. The input parameter `index` in the `TryInsertSystem<T>()` method refers to the index in the sub-system list, so it is important to examine the player loop closely to make sure you are inserting the system exactly where you want to.

For reference, this is what the default player loop looks like:

```c#
Unity Player Loop
UnityEngine.PlayerLoop.TimeUpdate
  UnityEngine.PlayerLoop.TimeUpdate+WaitForLastPresentationAndUpdateTime
UnityEngine.PlayerLoop.Initialization
  UnityEngine.PlayerLoop.Initialization+ProfilerStartFrame
  UnityEngine.PlayerLoop.Initialization+UpdateCameraMotionVectors
  UnityEngine.PlayerLoop.Initialization+DirectorSampleTime
  UnityEngine.PlayerLoop.Initialization+AsyncUploadTimeSlicedUpdate
  UnityEngine.PlayerLoop.Initialization+SynchronizeInputs
  UnityEngine.PlayerLoop.Initialization+SynchronizeState
  UnityEngine.PlayerLoop.Initialization+XREarlyUpdate
UnityEngine.PlayerLoop.EarlyUpdate
  UnityEngine.PlayerLoop.EarlyUpdate+PollPlayerConnection
  UnityEngine.PlayerLoop.EarlyUpdate+GpuTimestamp
  UnityEngine.PlayerLoop.EarlyUpdate+AnalyticsCoreStatsUpdate
  UnityEngine.PlayerLoop.EarlyUpdate+UnityWebRequestUpdate
  UnityEngine.PlayerLoop.EarlyUpdate+ExecuteMainThreadJobs
  UnityEngine.PlayerLoop.EarlyUpdate+ProcessMouseInWindow
  UnityEngine.PlayerLoop.EarlyUpdate+ClearIntermediateRenderers
  UnityEngine.PlayerLoop.EarlyUpdate+ClearLines
  UnityEngine.PlayerLoop.EarlyUpdate+PresentBeforeUpdate
  UnityEngine.PlayerLoop.EarlyUpdate+ResetFrameStatsAfterPresent
  UnityEngine.PlayerLoop.EarlyUpdate+UpdateAsyncInstantiate
  UnityEngine.PlayerLoop.EarlyUpdate+UpdateAsyncReadbackManager
  UnityEngine.PlayerLoop.EarlyUpdate+UpdateStreamingManager
  UnityEngine.PlayerLoop.EarlyUpdate+UpdateTextureStreamingManager
  UnityEngine.PlayerLoop.EarlyUpdate+UpdatePreloading
  UnityEngine.PlayerLoop.EarlyUpdate+UpdateContentLoading
  UnityEngine.PlayerLoop.EarlyUpdate+RendererNotifyInvisible
  UnityEngine.PlayerLoop.EarlyUpdate+PlayerCleanupCachedData
  UnityEngine.PlayerLoop.EarlyUpdate+UpdateMainGameViewRect
  UnityEngine.PlayerLoop.EarlyUpdate+UpdateCanvasRectTransform
  UnityEngine.PlayerLoop.EarlyUpdate+XRUpdate
  UnityEngine.PlayerLoop.EarlyUpdate+UpdateInputManager
  UnityEngine.PlayerLoop.EarlyUpdate+ProcessRemoteInput
  UnityEngine.PlayerLoop.EarlyUpdate+ScriptRunDelayedStartupFrame
  UnityEngine.PlayerLoop.EarlyUpdate+UpdateKinect
  UnityEngine.PlayerLoop.EarlyUpdate+DeliverIosPlatformEvents
  UnityEngine.PlayerLoop.EarlyUpdate+ARCoreUpdate
  UnityEngine.PlayerLoop.EarlyUpdate+DispatchEventQueueEvents
  UnityEngine.PlayerLoop.EarlyUpdate+Physics2DEarlyUpdate
  UnityEngine.PlayerLoop.EarlyUpdate+PhysicsResetInterpolatedTransformPosition
  UnityEngine.PlayerLoop.EarlyUpdate+SpriteAtlasManagerUpdate
  UnityEngine.PlayerLoop.EarlyUpdate+PerformanceAnalyticsUpdate
UnityEngine.PlayerLoop.FixedUpdate
  UnityEngine.PlayerLoop.FixedUpdate+ClearLines
  UnityEngine.PlayerLoop.FixedUpdate+NewInputFixedUpdate
  UnityEngine.PlayerLoop.FixedUpdate+DirectorFixedSampleTime
  UnityEngine.PlayerLoop.FixedUpdate+AudioFixedUpdate
  UnityEngine.PlayerLoop.FixedUpdate+ScriptRunBehaviourFixedUpdate
  UnityEngine.PlayerLoop.FixedUpdate+DirectorFixedUpdate
  UnityEngine.PlayerLoop.FixedUpdate+LegacyFixedAnimationUpdate
  UnityEngine.PlayerLoop.FixedUpdate+XRFixedUpdate
  UnityEngine.PlayerLoop.FixedUpdate+PhysicsFixedUpdate
  UnityEngine.PlayerLoop.FixedUpdate+Physics2DFixedUpdate
  UnityEngine.PlayerLoop.FixedUpdate+PhysicsClothFixedUpdate
  UnityEngine.PlayerLoop.FixedUpdate+DirectorFixedUpdatePostPhysics
  UnityEngine.PlayerLoop.FixedUpdate+ScriptRunDelayedFixedFrameRate
UnityEngine.PlayerLoop.PreUpdate
  UnityEngine.PlayerLoop.PreUpdate+PhysicsUpdate
  UnityEngine.PlayerLoop.PreUpdate+Physics2DUpdate
  UnityEngine.PlayerLoop.PreUpdate+PhysicsClothUpdate
  UnityEngine.PlayerLoop.PreUpdate+CheckTexFieldInput
  UnityEngine.PlayerLoop.PreUpdate+IMGUISendQueuedEvents
  UnityEngine.PlayerLoop.PreUpdate+NewInputUpdate
  UnityEngine.PlayerLoop.PreUpdate+SendMouseEvents
  UnityEngine.PlayerLoop.PreUpdate+AIUpdate
  UnityEngine.PlayerLoop.PreUpdate+WindUpdate
  UnityEngine.PlayerLoop.PreUpdate+UpdateVideo
UnityEngine.PlayerLoop.Update
  UnityEngine.PlayerLoop.Update+ScriptRunBehaviourUpdate
  UnityEngine.PlayerLoop.Update+ScriptRunDelayedDynamicFrameRate
  UnityEngine.PlayerLoop.Update+ScriptRunDelayedTasks
  UnityEngine.PlayerLoop.Update+DirectorUpdate
UnityEngine.PlayerLoop.PreLateUpdate
  UnityEngine.PlayerLoop.PreLateUpdate+AIUpdatePostScript
  UnityEngine.PlayerLoop.PreLateUpdate+DirectorUpdateAnimationBegin
  UnityEngine.PlayerLoop.PreLateUpdate+LegacyAnimationUpdate
  UnityEngine.PlayerLoop.PreLateUpdate+DirectorUpdateAnimationEnd
  UnityEngine.PlayerLoop.PreLateUpdate+DirectorDeferredEvaluate
  UnityEngine.PlayerLoop.PreLateUpdate+UIElementsUpdatePanels
  UnityEngine.PlayerLoop.PreLateUpdate+EndGraphicsJobsAfterScriptUpdate
  UnityEngine.PlayerLoop.PreLateUpdate+ConstraintManagerUpdate
  UnityEngine.PlayerLoop.PreLateUpdate+ParticleSystemBeginUpdateAll
  UnityEngine.PlayerLoop.PreLateUpdate+Physics2DLateUpdate
  UnityEngine.PlayerLoop.PreLateUpdate+PhysicsLateUpdate
  UnityEngine.PlayerLoop.PreLateUpdate+ScriptRunBehaviourLateUpdate
UnityEngine.PlayerLoop.PostLateUpdate
  UnityEngine.PlayerLoop.PostLateUpdate+PlayerSendFrameStarted
  UnityEngine.PlayerLoop.PostLateUpdate+DirectorLateUpdate
  UnityEngine.PlayerLoop.PostLateUpdate+ScriptRunDelayedDynamicFrameRate
  UnityEngine.PlayerLoop.PostLateUpdate+PhysicsSkinnedClothBeginUpdate
  UnityEngine.PlayerLoop.PostLateUpdate+UpdateRectTransform
  UnityEngine.PlayerLoop.PostLateUpdate+PlayerUpdateCanvases
  UnityEngine.PlayerLoop.PostLateUpdate+UpdateAudio
  UnityEngine.PlayerLoop.PostLateUpdate+VFXUpdate
  UnityEngine.PlayerLoop.PostLateUpdate+ParticleSystemEndUpdateAll
  UnityEngine.PlayerLoop.PostLateUpdate+EndGraphicsJobsAfterScriptLateUpdate
  UnityEngine.PlayerLoop.PostLateUpdate+UpdateCustomRenderTextures
  UnityEngine.PlayerLoop.PostLateUpdate+XRPostLateUpdate
  UnityEngine.PlayerLoop.PostLateUpdate+UpdateAllRenderers
  UnityEngine.PlayerLoop.PostLateUpdate+UpdateLightProbeProxyVolumes
  UnityEngine.PlayerLoop.PostLateUpdate+EnlightenRuntimeUpdate
  UnityEngine.PlayerLoop.PostLateUpdate+UpdateAllSkinnedMeshes
  UnityEngine.PlayerLoop.PostLateUpdate+ProcessWebSendMessages
  UnityEngine.PlayerLoop.PostLateUpdate+SortingGroupsUpdate
  UnityEngine.PlayerLoop.PostLateUpdate+UpdateVideoTextures
  UnityEngine.PlayerLoop.PostLateUpdate+UpdateVideo
  UnityEngine.PlayerLoop.PostLateUpdate+DirectorRenderImage
  UnityEngine.PlayerLoop.PostLateUpdate+PlayerEmitCanvasGeometry
  UnityEngine.PlayerLoop.PostLateUpdate+PlayerRenderUIEBatchModeOffscreen
  UnityEngine.PlayerLoop.PostLateUpdate+PhysicsSkinnedClothFinishUpdate
  UnityEngine.PlayerLoop.PostLateUpdate+FinishFrameRendering
  UnityEngine.PlayerLoop.PostLateUpdate+BatchModeUpdate
  UnityEngine.PlayerLoop.PostLateUpdate+PlayerSendFrameComplete
  UnityEngine.PlayerLoop.PostLateUpdate+UpdateCaptureScreenshot
  UnityEngine.PlayerLoop.PostLateUpdate+PresentAfterDraw
  UnityEngine.PlayerLoop.PostLateUpdate+ClearImmediateRenderers
  UnityEngine.PlayerLoop.PostLateUpdate+PlayerSendFramePostPresent
  UnityEngine.PlayerLoop.PostLateUpdate+UpdateResolution
  UnityEngine.PlayerLoop.PostLateUpdate+InputEndFrame
  UnityEngine.PlayerLoop.PostLateUpdate+TriggerEndOfFrameCallbacks
  UnityEngine.PlayerLoop.PostLateUpdate+GUIClearEvents
  UnityEngine.PlayerLoop.PostLateUpdate+ShaderHandleErrors
  UnityEngine.PlayerLoop.PostLateUpdate+ResetInputAxis
  UnityEngine.PlayerLoop.PostLateUpdate+ThreadedLoadingDebug
  UnityEngine.PlayerLoop.PostLateUpdate+ProfilerSynchronizeStats
  UnityEngine.PlayerLoop.PostLateUpdate+MemoryFrameMaintenance
  UnityEngine.PlayerLoop.PostLateUpdate+ExecuteGameCenterCallbacks
  UnityEngine.PlayerLoop.PostLateUpdate+XRPreEndFrame
  UnityEngine.PlayerLoop.PostLateUpdate+ProfilerEndFrame
  UnityEngine.PlayerLoop.PostLateUpdate+GraphicsWarmupPreloadedShaders
  UnityEngine.PlayerLoop.PostLateUpdate+ObjectDispatcherPostLateUpdate
```

### Printing The Player Loop

You can print out the player loop to the console at any time by either:
1. Using the menu bar at the top of the screen:
    - Tools->Player Loop Utility->Print Default Player Loop
    - Tools->Player Loop Utility->Print Current Player Loop
2. Using the ```PrintPlayerLoop()``` method in your own code:

    ```c#
    using UnityEngine.LowLevel;
    using UnityUtilities;

    public class MyClass
    {
        // Prints the default player loop.
        void PrintDefaultPlayerLoop()
        {
            var defaultPlayerLoop = PlayerLoop.GetDefaultPlayerLoop();
            PlayerLoopUtility.PrintPlayerLoop(defaultPlayerLoop);
        }

        // Prints the current player loop.
        void PrintCurrentPlayerLoop()
        {
            var currentPlayerLoop = PlayerLoop.GetCurrentPlayerLoop();
            PlayerLoopUtility.PrintPlayerLoop(currentPlayerLoop);
        }
    }
    ```

### Example Usage

#### MyCustomPlayerLoop

- First create the logic for the custom `PlayerLoopSystem` you wish to insert into the player loop. The following class is a bare bones example of what a custom system might look like:

    ```c#
    // This is an example of some system that we want to insert into the player loop.
    public static class MyCustomPlayerLoop
    {
        // This is the method that will be supplied as the updateDelegate when creating the PlayerLoopSystem.
        public static void Update()
        {
            // Update logic goes here...
        }
    }
    ```

#### MyCustomPlayerLoopBootstrapper

- The creation and registration of the custom system should be handled in a separate static class using an initialization method that is decorated with the `RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)` attribute:

    ```c#
    using UnityEngine;

    // Class responsible for creating and inserting our custom system into the player loop.
    public static class MyCustomPlayerLoopBootstrapper
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        static void Initialize()
        {

        }
    }
    ```

- In order to insert the custom system into the player loop, we first need to retrieve the current player loop. This is done by using the `GetCurrentPlayerLoop()` method provided by the `UnityEngine.LowLevel` namespace:

    ```c#
    using UnityEngine;
    using UnityEngine.LowLevel;

    // Class responsible for creating and inserting our custom system into the player loop.
    public static class MyCustomPlayerLoopBootstrapper
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        static void Initialize()
        {
            // Get the current player loop.
            var currentPlayerLoop = PlayerLoop.GetCurrentPlayerLoop();
        }
    }
    ```

- We now need to create and store reference to the custom `PlayerLoopSystem` that will be inserted:

    ```c#
    using UnityEngine;
    using UnityEngine.LowLevel;

    // Class responsible for creating and inserting our custom system into the player loop.
    public static class MyCustomPlayerLoopBootstrapper
    {
        static PlayerLoopSystem s_myCustomSystem;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        static void Initialize()
        {
            // Get the current player loop.
            var currentPlayerLoop = PlayerLoop.GetCurrentPlayerLoop();

            // Create the PlayerLoopSystem...
            s_myCustomSystem = new PlayerLoopSystem
            {
                type = typeof(MyCustomPlayerLoop),
                updateDelegate = MyCustomPlayerLoop.Update,
                subSystemList = null
            }
        }
    }
    ```

- Use the `TryInsertSystem<T>()` method provided by the `UnityUtilities` namespace, to insert the system into the player loop. The generic type `<T>` of this method is the update phase you wish to hook into. These update phases are provided by the `UnityEngine.PlayerLoop` namespace (see [Update Phases](#update-phases) above).

    The `TryInsertSystem<T>()` method returns `true` if the system was successfully inserted into the player loop, and `false` if it wasn't. As such, it is a good idea to check if the system was successfully inserted and log a warning if it was unsuccessful. However, if the system was successfully inserted, you then need to set the player loop to the modified player loop that includes the new system:

    ```c#
    using UnityEngine;
    using UnityEngine.LowLevel;
    using UnityEngine.PlayerLoop;
    using UnityUtilities;

    // Class responsible for creating and inserting our custom system into the player loop.
    public static class MyCustomPlayerLoopBootstrapper
    {
        static PlayerLoopSystem s_myCustomSystem;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        static void Initialize()
        {
            // Get the current player loop.
            var currentPlayerLoop = PlayerLoop.GetCurrentPlayerLoop();

            // Create the PlayerLoopSystem...
            s_myCustomSystem = new PlayerLoopSystem
            {
                type = typeof(MyCustomPlayerLoop),
                updateDelegate = MyCustomPlayerLoop.Update,
                subSystemList = null
            }

            // ...and insert it into the currentPlayerLoop at the desired update phase and index,
            // checking to make sure that it was in fact successfully inserted.
            if (!PlayerLoopUtility.TryInsertSystem<EarlyUpdate>(ref currentPlayerLoop, in s_myCustomSystem, 0))
            {
                Debug.LogWarning("Unable to initialize and register MyCustomPlayerLoop into the EarlyUpdate loop.");
                return;
            }
            
            // Set the current player loop to the modified player loop that now contains our custom system.
            PlayerLoop.SetPlayerLoop(currentPlayerLoop);
        }
    }
    ```

- The final thing to consider is what happens when we are in the Unity editor. If domain reload is turned off in the Project Settings, a duplicate of the system will be created the next time you enter play mode. To avoid this, always make sure to remove the system when exiting play mode:

    ```c#
    using UnityEngine;
    using UnityEngine.LowLevel;
    using UnityEngine.PlayerLoop;
    using UnityUtilities;

    #if UNITY_EDITOR
    using UnityEditor;
    #endif

    // Class responsible for creating and inserting our custom system into the player loop.
    public static class MyCustomPlayerLoopBootstrapper
    {
        static PlayerLoopSystem s_myCustomSystem;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        static void Initialize()
        {
            // Get the current player loop.
            var currentPlayerLoop = PlayerLoop.GetCurrentPlayerLoop();

            // Create the PlayerLoopSystem...
            s_myCustomSystem = new PlayerLoopSystem
            {
                type = typeof(MyCustomPlayerLoop),
                updateDelegate = MyCustomPlayerLoop.Update,
                subSystemList = null
            }

            // ...and insert it into the currentPlayerLoop at the desired update phase and index,
            // checking to make sure that it was in fact successfully inserted.
            if (!PlayerLoopUtility.TryInsertSystem<EarlyUpdate>(ref currentPlayerLoop, in s_myCustomSystem, 0))
            {
                Debug.LogWarning("Unable to initialize and register MyCustomPlayerLoop into the EarlyUpdate loop.");
                return;
            }
            
            // Set the current player loop to the modified player loop that now contains our custom system.
            PlayerLoop.SetPlayerLoop(currentPlayerLoop);

            // MAKE SURE TO REMOVE THE SYSTEM WHEN EXITING PLAY MODE TO AVOID DUPLICATES!
    #if UNITY_EDITOR
            EditorApplication.playModeStateChanged -= EditorApplication_OnPlayModeStateChanged;
            EditorApplication.playModeStateChanged += EditorApplication_OnPlayModeStateChanged;

            static void EditorApplication_OnPlayModeStateChanged(PlayModeStateChange playModeStateChange)
            {
                if (playModeStateChange == PlayModeStateChange.ExitingPlayMode)
                {
                    var currentPlayerLoop = PlayerLoop.GetCurrentPlayerLoop();
                    PlayerLoopUtility.RemoveSystem<EarlyUpdate>(ref currentPlayerLoop, in s_customPlayerLoopSystem);
                    PlayerLoop.SetPlayerLoop(currentPlayerLoop);
                }
            }
    #endif
        }
    }
    ```

## Wait

The `Wait` class provides allocation free coroutine yield instructions.

Possible yield instructions include:
- `ForEndOfFrame`
- `ForFixedUpdate`
- `ForSeconds(float seconds)`
- `ForSecondsRealtime(float seconds)`
- `Until(Func<bool> predicate)`
- `While(Func<bool> predicate)`

### Example Usages

- #### ForEndOfFrame

    ```c#
    using System.Collections;
    using UnityEngine;
    using UnityUtilities;

    public class ForEndOfFrameExample : MonoBehaviour
    {
        IEnumerator MyCoroutine()
        {
            // Execute some logic here...

            // Wait until the frame is finished and ready to be rendered to the screen.
            yield return Wait.ForEndOfFrame;

            // Continue executing logic...
        }
    }
    ```

- #### ForFixedUpdate

    ```c#
    using System.Collections;
    using UnityEngine;
    using UnityUtilities;

    public class ForFixedUpdateExample : MonoBehaviour
    {
        IEnumerator MyCoroutine()
        {
            // Execute some logic here...

            // Wait until the next FixedUpdate call.
            yield return Wait.ForFixedUpdate;

            // Continue executing logic...
        }
    }
    ```

- #### ForSeconds(float seconds)

    ```c#
    using System.Collections;
    using UnityEngine;
    using UnityUtilities;

    public class ForSecondsExample : MonoBehaviour
    {
        IEnumerator MyCoroutine()
        {
            // Execute some logic here...

            // Wait for the duration passed into the method, using scaled time; In this case 1 sec.
            yield return Wait.ForSeconds(1f);

            // Continue executing logic...
        }
    }
    ```

- #### ForSecondsRealtime(float seconds)

    ```c#
    using System.Collections;
    using UnityEngine;
    using UnityUtilities;

    public class ForSecondsRealtimeExample : MonoBehaviour
    {
        IEnumerator MyCoroutine()
        {
            // Execute some logic here...

            // Wait for the duration passed into the method, using unscaled time; In this case 1 sec.
            yield return Wait.ForSecondsRealtime(1f);

            // Continue executing logic...
        }
    }
    ```

- #### Until(Func\<bool> predicate)

    ```c#
    using System.Collections;
    using UnityEngine;
    using UnityUtilities;

    public class UntilExample : MonoBehaviour
    {
        bool MyPredicate()
        {
            // Logic that returns true or false goes here...
        }

        IEnumerator MyCoroutine()
        {
            // Execute some logic here...

            // Wait until the provided predicate evaluates to true.
            yield return Wait.Until(MyPredicate);

            // Continue executing logic...
        }
    }
    ```

- #### While(Func\<bool> predicate)

    ```c#
    using System.Collections;
    using UnityEngine;
    using UnityUtilities;

    public class WhileExample : MonoBehaviour
    {
        bool MyPredicate()
        {
            // Logic that returns true or false goes here...
        }

        IEnumerator MyCoroutine()
        {
            // Execute some logic here...

            // Wait until the provided predicate evaluates to false.
            yield return Wait.While(MyPredicate);

            // Continue executing logic...
        }
    }
    ```

## Hotkeys

- ### Save Scene and Project:

    `Ctrl`+`Shift`+`Alt`+`S`
    
    Saves both the current scene and the project at the same time.

- ### Toggle Inspector Lock:

    `Ctrl`+`L`

    Locks/unlocks the inspector.

## How To Install

- ### Package Manager (recommended)

    1. Open the Package Manager from within Unity by going to `Window->Package Manager`
    2. Click the `+` icon in the top left corner of the Package Manager window and select `Add package from git URL...`
    3. Copy paste the following URL into the text box and click import:
        
        ```
        https://github.com/joshua-auer/Unity-Utilities.git
        ```

- ### Add To Manifest

    Locate your project's `manifest.json` file and add the following line:

    ```json
    "com.joshua-auer.unity-utilities": "https://github.com/joshua-auer/Unity-Utilities.git"
    ```