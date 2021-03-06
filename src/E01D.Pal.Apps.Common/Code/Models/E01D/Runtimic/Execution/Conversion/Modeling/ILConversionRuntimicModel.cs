﻿using Root.Code.Enums.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Modeling;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural;
using Root.Code.Models.E01D.Runtimic.Unified;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Modeling
{
    public class ILConversionRuntimicModel: BoundRuntimicModelMask_I
	{
		

		/// <summary>
		/// Gets or sets the conversion associated with this runtimic model.
		/// </summary>
		public ILConversion Conversion { get; set; }

		/// <summary>
		/// Gets or sets the semantic model assoicated with this runtimic model.
		/// </summary>
		public ILConversionModel Semantic { get; set; } = new ILConversionModel();

		/// <summary>
		/// Gets or sets the structural model assoicated with this runtimic model.
		/// </summary>

		public StructuralModel Structural { get; set; } = new StructuralModel();

		/// <summary>
		/// Gets the semantic model assoicated with this runtimic model.
		/// </summary>
		SemanticModelMask_I InfrastructureRuntimicModelMask_I.Semantic => Semantic;

		/// <summary>
		/// Gets the structural model assoicated with this runtimic model.
		/// </summary>
		StructuralModelMask_I StructuralRuntimicModelMask_I.Structural => Structural;

		public RuntimicKind RuntimicKind => RuntimicKind.Semantic;

		public object ObjectNetwork { get; set; }

		/// <summary>
		/// Gets or sets the unified runtimic model assoicated with this runtimic model.
		/// </summary>
		public UnifiedModelMask_I Unified { get; set; } //= new UnifiedModel();
	}
}
