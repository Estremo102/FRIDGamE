using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FRIDGamE.Models;
using Microsoft.AspNetCore.Identity;

namespace FRIDGamE.Areas.Identity.Data;

// Add profile data for application users by adding properties to the FRIDGamEUser class
public class FRIDGamEUser : IdentityUser
{
    public ISet<News> News { get; set; } 
}

