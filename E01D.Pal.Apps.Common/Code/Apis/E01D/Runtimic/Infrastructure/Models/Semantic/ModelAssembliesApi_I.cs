﻿using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Semantic
{
	public interface ModelAssembliesApi_I<TContainer> : ModelAssembliesApiMask_I
		where TContainer : RuntimicContainer_I<TContainer>
	{
	}
}
