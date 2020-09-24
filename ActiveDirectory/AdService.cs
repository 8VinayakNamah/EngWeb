using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices.AccountManagement;
using log4net;
using System.Reflection;

namespace ActiveDirectory
{
    public class AdService
    {
        static readonly ILog log;

        static AdService()
        {
            log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }

        public static bool IsInGroup(string group)
        {
            try
            {
                string username = Environment.UserName;
                PrincipalContext domainCtx = new PrincipalContext(ContextType.Domain, "Phononic", "DC=Phononic,DC=com");
                UserPrincipal userPrincipal = UserPrincipal.FindByIdentity(domainCtx, IdentityType.SamAccountName, username);
                bool isMember = userPrincipal.IsMemberOf(domainCtx, IdentityType.Name, group);
                return isMember;
            }
            catch(Exception ex)
            {
                log.Error(ex.Message);
                return false;
            }            
        }


        public static bool IsInGroup()
        {
            try
            {
                PrincipalContext pc = new PrincipalContext((Environment.UserDomainName == Environment.MachineName ? ContextType.Machine : ContextType.Domain), Environment.UserDomainName);

                GroupPrincipal gp = GroupPrincipal.FindByIdentity(pc, "Administrator,engineering");
                UserPrincipal up = UserPrincipal.FindByIdentity(pc, Environment.UserName);
                return up.IsMemberOf(gp);
            }
            catch(Exception ex) {
                log.Error(ex.Message);
                return false;
            }
        }

        public static bool IsValidUser(string userName , string password,string domain)
        {
           
            bool isValid = false;
            try
            {
                using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, domain))
                {
                    // validate the credentials
                    isValid = pc.ValidateCredentials(userName, userName);
                }
                return isValid;
            }
            catch (Exception ex) {

                log.Error(ex.Message);
                return false;
            }            
        }
    }
}
