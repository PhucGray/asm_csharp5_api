using System.Collections.Generic;

namespace api.Models.MockData
{
    public class MockUserData
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel()
            {
                Id = 0,
                FullName = "Nguyen Van A",
                Email = "a@gmail.com",
                Password = "000000",
                Address = "",
                Phone = "",
                Gender = true,
                IsDeleted = false,
            }
        };
    }
}
