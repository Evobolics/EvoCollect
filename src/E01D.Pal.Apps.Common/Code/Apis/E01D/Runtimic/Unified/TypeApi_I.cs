﻿using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Unified
{
	public interface TypeApi_I<TContainer> : TypeApiMask_I
		where TContainer : RuntimicContainer_I<TContainer>
	{
	}
}
