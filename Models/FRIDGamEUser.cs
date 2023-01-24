using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace FRIDGamE.Models;

// Add profile data for application users by adding properties to the FRIDGamEUser class
public class FRIDGamEUser : IdentityUser
{
    public Customer? customer { get; set; }
}

