using SimpleMvc.Framework.Attributes.Validation;

namespace ModPanel.App.Infrastructure.Validation.Users
{
    class EmailAttribute : PropertyValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var email = value as string;
            if (email == null)
            {
                return true;
            }

            return email.Contains(".") && email.Contains("@");
        }
    }
}
