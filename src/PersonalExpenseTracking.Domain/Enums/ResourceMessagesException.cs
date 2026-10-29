using System.Resources;
using System.Text;

namespace PersonalExpenseTracking.Domain.Enums
{
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "18.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ResourceMessagesException
    {
        private static global::System.Resources.ResourceManager resourceMan;

        private static global::System.Globalization.CultureInfo resourceCulture;

        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ResourceMessagesException()
        {
        }

        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MyRecipeBook.Exception.ResourceMessagesException", typeof(ResourceMessagesException).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Oops! This email is already in use..
        /// </summary>
        public static string VALIDATION_EMAIL_ALREADY_EXISTS
        {
            get
            {
                return ResourceManager.GetString("VALIDATION_EMAIL_ALREADY_EXISTS", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Oops! That email doesn’t look right..
        /// </summary>
        public static string VALIDATION_EMAIL_INVALID
        {
            get
            {
                return ResourceManager.GetString("VALIDATION_EMAIL_INVALID", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Oops! Email is required..
        /// </summary>
        public static string VALIDATION_EMAIL_REQUIRED
        {
            get
            {
                return ResourceManager.GetString("VALIDATION_EMAIL_REQUIRED", resourceCulture);
            }
        }

        public static string VALIDATION_LOGIN_INVALID
        {
            get
            {
                return ResourceManager.GetString("VALIDATION_LOGIN_INVALID", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Oops! Name is required..
        /// </summary>
        public static string VALIDATION_NAME_REQUIRED
        {
            get
            {
                return ResourceManager.GetString("VALIDATION_NAME_REQUIRED", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Oops! Password must be at least 6 characters long..
        /// </summary>
        public static string VALIDATION_PASSWORD_MIN_LENGTH
        {
            get
            {
                return ResourceManager.GetString("VALIDATION_PASSWORD_MIN_LENGTH", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Oops! Password is required..
        /// </summary>
        public static string VALIDATION_PASSWORD_REQUIRED
        {
            get
            {
                return ResourceManager.GetString("VALIDATION_PASSWORD_REQUIRED", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Oops! Your session has expired. Please sign in again..
        /// </summary>
        public static string EXPIRED_REFRESH_TOKEN
        {
            get
            {
                return ResourceManager.GetString("EXPIRED_REFRESH_TOKEN", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to The current password is incorrect..
        /// </summary>
        public static string VALIDATION_CURRENT_PASSWORD
        {
            get
            {
                return ResourceManager.GetString("VALIDATION_CURRENT_PASSWORD", resourceCulture);
            }
        }
    }
}
