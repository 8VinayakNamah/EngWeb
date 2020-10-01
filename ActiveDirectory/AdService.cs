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

        public static bool IsInGroup(string userGroups,string domain,string domaincontroller)
        {
            bool result =false;
            try
            {
                string username = Environment.UserName;

                PrincipalContext domainCtx = new PrincipalContext(ContextType.Domain, domain, domaincontroller);
                UserPrincipal userPrincipal = UserPrincipal.FindByIdentity(domainCtx, IdentityType.SamAccountName, username);

                string[] grps = userGroups.Split(',');
                foreach(string group in grps)
                {
                    if(userPrincipal.IsMemberOf(domainCtx, IdentityType.Name, group))
                    {
                        result = true;
                    }
                }               
                return result;
            }
            catch(Exception ex)
            {
                log.Error(ex.Message);
                return false;
            }            
        }




        public static bool IsMemberofGroup(string groups)
        {
            bool result=false; 
            try
            {
                char[] charSeparators = new char[] { ',' };

                PrincipalContext pc = new PrincipalContext((Environment.UserDomainName == Environment.MachineName ? ContextType.Machine : ContextType.Domain), Environment.UserDomainName);
                string[] grpArray = groups.Split(charSeparators, StringSplitOptions.None);

                foreach (string grp in grpArray)
                {
                    GroupPrincipal gp = GroupPrincipal.FindByIdentity(pc, grp);
                    UserPrincipal up = UserPrincipal.FindByIdentity(pc, Environment.UserName);
                    if (up.IsMemberOf(gp))
                    {
                        result = true;
                    }
                }               
                return result;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return false;
            }
        }

        public static bool IsValidUser(string userName , string password,string domain)
        {
            return true;
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
