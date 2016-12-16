using Microsoft.AspNetCore.Authorization;
using System;
using System.IdentityModel.Claims;
using System.Threading.Tasks;

namespace UserClaims {


    public class AdultRequirement : IAuthorizationRequirement {
        protected int Age { get; set; }

        public AdultRequirement(int age) {
            this.Age = age;
        }

    }

    public class AdultHandler : AuthorizationHandler<AdultRequirement> {

        const string Issuer = "LOCAL AUTHORITY";
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AdultRequirement requirement) {
            if (!context.User.HasClaim(c => c.Type == ClaimTypes.DateOfBirth && c.Issuer == Issuer)) {
                context.Fail();
                return Task.FromResult(0);
            }

            var claimValue = context.User.FindFirst(c => c.Type == ClaimTypes.DateOfBirth && c.Issuer == Issuer).Value;
            var dateOfBirth = Convert.ToDateTime(claimValue);
            int age = CalculateAge(dateOfBirth);
            if (age >= 16)
                context.Succeed(requirement);
            else
                context.Fail();

            return Task.FromResult(0);
        }

        private int CalculateAge(DateTime dateOfBirth) {
            int age = 0;
            age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;

            return age;
        }
    }
}
