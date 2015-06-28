//Copyright (c) 2015 by Michiel Frankfort, all rights reserved.      

using System;
namespace Frankfort.VBug.Internal
{


    //--------------- Workload Execution --------------------
    
    public enum WorkloadExecutorType
    {
        fixedUpdate,
        update,
        lateUpdate,
        thread
    } 
    //--------------- Workload Execution --------------------
			

    
	//--------------- Data Processing --------------------
    
    public enum ProcessHandlingType
    {
        none = 0,
        saveToDisk = 1,
        streamToEditor = 2,
        streamToServer = 4
    }
	//--------------- Data Processing --------------------
			




    //--------------- GAME OBJECT REFLECTION --------------------

    
    public enum TypeClassification
    {
        unknown,
        primitive,
        collection,
        unityObj,
        obj,
    }

    public enum UnityObjectType
    {
        unityObject,
        texture,
        material
    }

    //--------------- GAME OBJECT REFLECTION --------------------
			
}
