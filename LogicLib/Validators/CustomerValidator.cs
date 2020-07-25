using DataAccessLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Entities.BusinessPartners;

namespace LogicLib.Validators
{
    class CustomerValidator : AbstractValidator<BusinessPartner>
    {
        public CustomerValidator(Func<int?,bool> isCardGroupValid, Func<int?, bool> isSalesmanValid)
        {
        

        }
        
    }


    
}
