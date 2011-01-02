using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Collections.Specialized;

namespace Web.Infrastructure.Authentication {
    public class AspNetAuthenticationService: IAuthenticationService{
        

        public bool IsValidLogin(string userName, string password) {
            return System.Web.Security.Membership.ValidateUser(userName, password);
        }

        public bool IsValidLogin(Uri serviceUri) {
            throw new NotImplementedException();
        }


        public bool RegisterUser(string userName, string password, string confirmPassword, string email, string reminderQuestion, string reminderAnswer) {
            bool result = false;
            MembershipCreateStatus status;
            if (string.IsNullOrEmpty(reminderQuestion))
                reminderQuestion = Guid.NewGuid().ToString();
            if (string.IsNullOrEmpty(reminderAnswer))
                reminderAnswer = Guid.NewGuid().ToString();
            Membership.CreateUser(userName, password, email, reminderQuestion, reminderAnswer, true, out status);

            if (status == MembershipCreateStatus.Success) {
                result = true;

            } else {

                switch (status) {
                    case MembershipCreateStatus.DuplicateEmail:
                        throw new InvalidOperationException("This email is already in our system");
                    case MembershipCreateStatus.DuplicateProviderUserKey:
                        throw new InvalidOperationException("There's a problem saving your information");
                    case MembershipCreateStatus.DuplicateUserName:
                        throw new InvalidOperationException("Need to use another login - this one's taken");                     
                    case MembershipCreateStatus.InvalidAnswer:
                        throw new InvalidOperationException("The reminder answer is not valid");
                    case MembershipCreateStatus.InvalidEmail:
                        throw new InvalidOperationException("Invalid email address");
                    case MembershipCreateStatus.InvalidPassword:
                        throw new InvalidOperationException("Invalid password - please be sure to use some numbers and uppercase letters.");
                    case MembershipCreateStatus.InvalidProviderUserKey:
                        throw new InvalidOperationException("There's a problem saving your information");
                    case MembershipCreateStatus.InvalidQuestion:
                        throw new InvalidOperationException("The reminder question is not valid.");
                    case MembershipCreateStatus.InvalidUserName:
                        throw new InvalidOperationException("The username you've chosen is not valid.");
                    case MembershipCreateStatus.ProviderError:
                        throw new InvalidOperationException("There's a problem saving your information");                   
                    case MembershipCreateStatus.UserRejected:
                        throw new InvalidOperationException("Cannot register at this time");
                }
            }

            return result;
        }

    }
}
