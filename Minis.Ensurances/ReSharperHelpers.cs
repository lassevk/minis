using System;
using System.Diagnostics;

using JetBrains.Annotations;

// ReSharper disable InconsistentNaming

namespace Minis.Ensurances
{
    public static class ReSharperHelpers
    {
        [Conditional("DEBUG")]
        [ContractAnnotation("expression:false=>halt")]
        public static void assume(bool expression)
        {
        }
    }
}
