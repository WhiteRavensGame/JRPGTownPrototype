//Copyright (c) 2015 by Michiel Frankfort, all rights reserved.      

using System;

namespace Frankfort.VBug.Internal {
    
    public class BaseDisposable {

        //--------------- == operator trick --------------------

        //http://msdn.microsoft.com/en-us/library/ms173147%28v=vs.80%29.aspx
        public static bool operator ==(BaseDisposable a, BaseDisposable b) {

            // the classic 'if(myInstance == null)' isDispoed trick
            if ((object)a != null && (object)b == null && a.isDisposed)
                return true;

            return ((object)a == (object)b);
        }

        public static bool operator !=(BaseDisposable a, BaseDisposable b) {
            return !(a == b);
        }
        //--------------- == operator trick --------------------
			
			
        public bool isDisposed { private set; get; }
        
        public virtual void Dispose() {
            this.isDisposed = true;
        }

        public override bool Equals(object obj) {
            return base.Equals(obj);
        }
         
        public override int GetHashCode() {
            return base.GetHashCode();
        }
    }
}
