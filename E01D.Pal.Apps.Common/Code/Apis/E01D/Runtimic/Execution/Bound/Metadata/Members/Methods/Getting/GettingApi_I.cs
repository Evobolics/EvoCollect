﻿using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Methods.Getting
{
    public interface GettingApi_I<TContainer> : GettingApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
	    //new FromMethodReferenceApi_I<TContainer> FromMethodReference { get; set; }
	}
}
