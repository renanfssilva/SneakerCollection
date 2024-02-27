using SneakerCollection.Domain.UserAggregate.ValueObjects;

namespace SneakerCollection.Domain.Tests.TestUtils.Constants
{
    public static partial class Constants
    {
        public static class User
        {
            public static readonly UserId Id = UserId.Create("e7947777-fb7f-4504-ad04-7c9f96273aa7").Value;
            public static readonly string FirstName = "John";
            public static readonly string LastName = "Doe";
            public static readonly string Email = "john.doe@email.com";
            public static readonly string Password = "password";
        }
    }
}
