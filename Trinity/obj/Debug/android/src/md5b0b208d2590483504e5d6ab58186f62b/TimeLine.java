package md5b0b208d2590483504e5d6ab58186f62b;


public class TimeLine
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Trinity.Control.TimeLine, Trinity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", TimeLine.class, __md_methods);
	}


	public TimeLine () throws java.lang.Throwable
	{
		super ();
		if (getClass () == TimeLine.class)
			mono.android.TypeManager.Activate ("Trinity.Control.TimeLine, Trinity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
