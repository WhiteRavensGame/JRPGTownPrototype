using System;
using UnityEngine;

/// <summary>
/// Add this to any camera you would like to be rendered during screencapture:
/// Please Note: 
///   - This ONLY applies to JIT-capture mode
///   - This ONLY applies when 'jitRenderCaptureAllCameras' is set to false!
/// </summary>
[RequireComponent(typeof(Camera))]
public class vBugJitCameraRecordable :  MonoBehaviour
{ }
