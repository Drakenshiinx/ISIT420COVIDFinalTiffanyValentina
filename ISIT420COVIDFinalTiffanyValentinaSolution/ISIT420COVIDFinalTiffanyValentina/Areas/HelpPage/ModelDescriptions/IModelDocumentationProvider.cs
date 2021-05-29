using System;
using System.Reflection;

namespace ISIT420COVIDFinalTiffanyValentina.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}