﻿using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Types
{
	public interface ExtendingApi_I<TContainer> : ExtendingApiMask_I
		where TContainer : RuntimicContainer_I<TContainer>
	{
	}
}
