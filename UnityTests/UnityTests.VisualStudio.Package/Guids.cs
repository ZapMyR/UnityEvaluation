// Guids.cs
// MUST match guids.h
using System;

namespace Company.UnityTests_VisualStudio_Package
{
    static class GuidList
    {
        public const string guidUnityTests_VisualStudio_PackagePkgString = "68c65009-a37a-43ff-a9dd-33304194eacc";
        public const string guidUnityTests_VisualStudio_PackageCmdSetString = "fddc3a6b-db60-4f62-adfc-97cd2985672e";

        public static readonly Guid guidUnityTests_VisualStudio_PackageCmdSet = new Guid(guidUnityTests_VisualStudio_PackageCmdSetString);
    };
}