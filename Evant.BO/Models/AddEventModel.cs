using System;

namespace Evant.BO.Models
{
    public class AddEventModel
    {
        public int PersonId { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public DateTime StartDate { get; set; }

        public string Description { get; set; }

        public int Category { get; set; }
    }
}