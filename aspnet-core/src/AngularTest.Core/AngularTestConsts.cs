using AngularTest.Debugging;

namespace AngularTest
{
    public class AngularTestConsts
    {
        public const string LocalizationSourceName = "AngularTest";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "26efeb4c19c2453ea495676bc6d12650";
    }
}
