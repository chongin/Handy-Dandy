using System;
namespace Handy_Dandy.Models
{
	public class WorkerModel
	{
		public WorkerModel()
		{
		}

        public string WorkerID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public float Score { get; set; }
        public int Ratings { get; set; }
        public int LaborCost { get; set; }
        public string ImageName { get; set; }

        public List<string> ServiceIDs { get; set; }
        public UserRole RoleID { get; set; }
    }
}

