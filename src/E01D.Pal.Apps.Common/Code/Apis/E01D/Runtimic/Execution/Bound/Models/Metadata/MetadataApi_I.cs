﻿using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Models.Metadata
{
	public interface MetadataApi_I<TContainer> : MetadataApiMask_I
		where TContainer : RuntimicContainer_I<TContainer>
	{
	}
}
