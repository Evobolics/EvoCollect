﻿using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Assemblies
{
	public interface EnsuringApi_I<TContainer> : EnsuringApiMask_I
		where TContainer : RuntimicContainer_I<TContainer>
	{
	
	}
}
