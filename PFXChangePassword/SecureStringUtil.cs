using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace PFXChangePassword
{
    public static class SecureStringUtil
    {
        public static SecureString ToSecureString(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return null;

            SecureString res = new SecureString();
            foreach (char c in input.ToCharArray())
                res.AppendChar(c);
            return res;
        }
    }
}
