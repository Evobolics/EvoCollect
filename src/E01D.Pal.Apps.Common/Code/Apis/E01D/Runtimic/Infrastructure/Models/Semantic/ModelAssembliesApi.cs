﻿using Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Semantic
{
	public class ModelAssembliesApi<TContainer> : SemanticApiNode<TContainer>, ModelAssembliesApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		
	}
}
