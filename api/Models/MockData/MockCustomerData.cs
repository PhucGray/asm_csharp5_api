using System.Collections.Generic;

namespace api.Models.MockData
{
    public class MockCustomerData
    {
        public static List<UserModel> Customers = new List<UserModel>()
        {
            new UserModel()
            {
                Id = 0,
                FullName = "Tran thi B",
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
