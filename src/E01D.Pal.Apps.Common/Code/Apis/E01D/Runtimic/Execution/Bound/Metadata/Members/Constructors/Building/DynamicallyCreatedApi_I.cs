﻿using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Constructors.Building
{
	public interface DynamicallyCreatedApi_I<TContainer> : DynamicallyCreatedApiMask_I
		where TContainer : RuntimicContainer_I<TContainer>
	{
	}
}
