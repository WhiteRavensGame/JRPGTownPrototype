//Copyright (c) 2015 by Michiel Frankfort, all rights reserved.      

using System;
namespace Frankfort.VBug.Internal
{
    public delegate void ResultReadyCallback<T>(int frameNumber, T result, int streamPriority);
}