using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;


namespace SportingEvents.Models
{
    public class InitialData
    {
        public static void EnsurePopulated(IApplicationBuilder app) 
        {
            ApplicationDBContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDBContext>();
            context.Database.Migrate();
            if (!context.Responses.Any())
            {
                context.Responses.AddRange(
                    new Responses
                    {
                        Name = "Juxhen",
                        DateOfBirth ="28/03/1996",
                        Gender = "Male",
                        Email = "k1651930@kingston.ac.uk",
                        Address = "123 abc drive",
                        PostCode =" kt1 2ht",
                        HomeTelephoneNumber = "0829493388404",
                        MobileTelephoneNumber = "108349751230",
                        Biography = "I Like all the sports",
                        SkillKeyWord =" fast,furious,smart",
                        WorkLocation =" London"
                    },
                    new Responses
                    {
                        Name = "Samir",
                        DateOfBirth ="08/07/1999",
                        Gender = "Male",
                        Email = "k1657670@kingston.ac.uk",
                        Address = "1666 abc drive",
                        PostCode =" kt1 2ht",
                        HomeTelephoneNumber = "4234234234",
                        MobileTelephoneNumber = "765756757445",
                        Biography = "I Like football",
                        SkillKeyWord =" slow, smart, steady",
                        WorkLocation =" London"
                    });
                context.SaveChanges();
            }        
        }
    }
}
