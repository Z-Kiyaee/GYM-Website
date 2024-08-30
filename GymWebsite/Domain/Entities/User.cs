using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        #region Properties

        public int Id { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDelete { get; set; }

        #endregion

        #region Navigation Properties

        #endregion

    }
}
