﻿using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Types
{
	public interface NamingApi_I<TContainer> : NamingApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
		
	}
}
