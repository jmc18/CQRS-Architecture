using Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entitties;

public class Customer : AuditableEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime DOB { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }

    [NotMapped]
    private int _Age { get; set;  }

    public int Age
    {
        get
        {
            if(this._Age <= 0)
                _Age = new DateTime(DateTime.UtcNow.Subtract(DOB).Ticks).Year - 1;
            return this._Age;
        }
    }
}

