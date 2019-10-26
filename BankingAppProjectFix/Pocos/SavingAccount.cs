using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pocos
{
   
    public class SavingAccount //: BankAccount
    {
        //[ForeignKey("Customer")]                    //No Need for [Required] a ForeignKey is "Required"
        //public int CustomerId { get; set; }

        //public override int BankAccountTypeId { get { return 1; } set { value = 1; } }
        //public virtual Customer Customer { get; set; }
    }
}
