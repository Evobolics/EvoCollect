﻿using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal
{
    public interface InformationApiMask_I
    {

        SemanticTypeInformation CreateTypeInformation(RuntimicSystemModel model, System.Type inputType);
        SemanticTypeInformation CreateTypeInformation(RuntimicSystemModel model, TypeReference typeReference);
    }
}
