﻿using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Assemblies
{
	public interface AddingApi_I<TContainer> : AddingApiMask_I
		where TContainer : RuntimicContainer_I<TContainer>
	{

	}
}
